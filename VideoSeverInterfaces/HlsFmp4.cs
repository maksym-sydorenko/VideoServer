using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Drawing;
using FFmpeg.AutoGen;
using Microsoft.SqlServer.Server;
using System.Drawing.Imaging;

namespace Interfaces
{


    namespace Interfaces
    {
        public unsafe class FFmpegHelper
        {
            public static void RegisterFFmpegBinaries()
            {
                ffmpeg.RootPath = @"ffmpeg"; // шлях до dll
            }

            public static void Initialize()
            {
                ffmpeg.avformat_network_init();
            }
        }
        class HlsFmp4 : SourceFormater
        {
            public override event CameraEventHandler NewFrame;

            public override void Start()
            {
                stopEvent = new ManualResetEvent(false);
                thread = new Thread(new ThreadStart(WorkerThread));
                thread.Name = "HLS fMP4";
                thread.Start();
            }

            public override void Stop()
            {
                if (thread != null)
                {
                    stopEvent.Set();
                    thread.Join();
                    thread = null;
                }
            }

            public override void WorkerThread()
            {
                FFmpegHelper.RegisterFFmpegBinaries();
                FFmpegHelper.Initialize();

                string playlistUrl = cameraAdapter.SourcePath;

                while (!stopEvent.WaitOne(0, true))
                {
                    try
                    {
                        // 1. Завантажуємо m3u8
                        string m3u8;
                        using (var wc = new WebClient())
                            m3u8 = wc.DownloadString(playlistUrl);

                        // 2. Парсимо сегменти
                        var lines = m3u8.Split('\n');
                        foreach (var line in lines)
                        {
                            if (line.StartsWith("#")) continue;
                            if (string.IsNullOrWhiteSpace(line)) continue;

                            string segmentUrl = new Uri(new Uri(playlistUrl), line.Trim()).ToString();

                            // 3. Відкриваємо сегмент через FFmpeg
                            unsafe
                            {
                                AVFormatContext* fmtCtx = ffmpeg.avformat_alloc_context();
                                if (ffmpeg.avformat_open_input(&fmtCtx, segmentUrl, null, null) != 0)
                                    continue;

                                if (ffmpeg.avformat_find_stream_info(fmtCtx, null) < 0)
                                    continue;

                                // шукаємо відео‑потік
                                int videoStreamIndex = -1;
                                for (int i = 0; i < fmtCtx->nb_streams; i++)
                                {
                                    if (fmtCtx->streams[i]->codecpar->codec_type == AVMediaType.AVMEDIA_TYPE_VIDEO)
                                    {
                                        videoStreamIndex = i;
                                        break;
                                    }
                                }
                                if (videoStreamIndex == -1) continue;

                                AVCodecParameters* codecParams = fmtCtx->streams[videoStreamIndex]->codecpar;
                                AVCodec* codec = ffmpeg.avcodec_find_decoder(codecParams->codec_id);
                                AVCodecContext* codecCtx = ffmpeg.avcodec_alloc_context3(codec);
                                ffmpeg.avcodec_parameters_to_context(codecCtx, codecParams);
                                ffmpeg.avcodec_open2(codecCtx, codec, null);

                                SwsContext* swsCtx = ffmpeg.sws_getContext(
                                    codecCtx->width, codecCtx->height, codecCtx->pix_fmt,
                                    codecCtx->width, codecCtx->height, AVPixelFormat.AV_PIX_FMT_BGR24,
                                    (int)SwsFlags.SWS_BICUBIC, null, null, null);

                                AVPacket* packet = ffmpeg.av_packet_alloc();
                                AVFrame* frame = ffmpeg.av_frame_alloc();

                                byte_ptrArray4 dstData;
                                int_array4 dstLinesize;
                                ffmpeg.av_image_alloc(ref dstData, ref dstLinesize,
                                    codecCtx->width, codecCtx->height, AVPixelFormat.AV_PIX_FMT_BGR24, 1);

                                while (ffmpeg.av_read_frame(fmtCtx, packet) >= 0)
                                {
                                    if (packet->stream_index == videoStreamIndex)
                                    {
                                        ffmpeg.avcodec_send_packet(codecCtx, packet);
                                        while (ffmpeg.avcodec_receive_frame(codecCtx, frame) == 0)
                                        {
                                            ffmpeg.sws_scale(
                                                swsCtx,
                                                frame->data, frame->linesize,
                                                0, codecCtx->height,
                                                dstData, dstLinesize);

                                            var bmp = new Bitmap(codecCtx->width, codecCtx->height,
                                                dstLinesize[0],
                                                System.Drawing.Imaging.PixelFormat.Format24bppRgb,
                                                (IntPtr)dstData[0]);

                                            NewFrame?.Invoke(this, new CameraEventArgs((Bitmap)bmp.Clone()));
                                            bmp.Dispose();
                                        }
                                    }
                                    ffmpeg.av_packet_unref(packet);
                                }

                                ffmpeg.av_frame_free(&frame);
                                ffmpeg.av_packet_free(&packet);
                                ffmpeg.avcodec_free_context(&codecCtx);
                                ffmpeg.avformat_close_input(&fmtCtx);
                            }

                            if (stopEvent.WaitOne(0, true)) break;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("HLS error: " + ex.Message);
                        Thread.Sleep(500);
                    }
                }
            }
        }
    }
}
