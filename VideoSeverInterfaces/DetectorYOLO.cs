using System;
using System.Drawing;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Security.Policy;

namespace Interfaces
{
    public class DetectorYOLO
    {

        Bitmap localBitmap;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        string path = "";
        string fileName = "";
        private string fullUrl = "";
        private string[] obj2detect = null;
        private Thread thread = null;
        bool thread_started = false;
        bool next_image = false;

        public DetectorYOLO(string cameraName)
        {
            thread = new Thread(DetectRequestTask);
            thread.Name = String.Format("YOLO[{0}]", cameraName);
            thread.Start();
        }

        private void DetectRequestTask()
        {
            thread_started = true;
            while (thread_started)
            {
                if (!next_image)
                {
                    continue;
                }
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        localBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        ms.Seek(0, SeekOrigin.Begin);

                        using (HttpClient client = new HttpClient())
                        using (MultipartFormDataContent form = new MultipartFormDataContent())
                        {
                            var fileContent = new StreamContent(ms);
                            fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

                            form.Add(fileContent, "file", $"{fileName}.jpg");
                            var response = client.PostAsync(fullUrl, form).Result;
                            var result = response.Content.ReadAsStringAsync().Result;

                            using (JsonDocument doc = JsonDocument.Parse(result))
                            {
                                if (doc.RootElement.TryGetProperty("detections", out JsonElement detections))
                                {
                                    foreach (var detection in detections.EnumerateArray())
                                    {
                                        string label = detection.GetProperty("label").GetString();
                                        float confidence = detection.GetProperty("confidence").GetSingle();

                                        var box = detection.GetProperty("box").EnumerateArray().ToArray();
                                        float x1 = box[0].GetSingle();
                                        float y1 = box[1].GetSingle();
                                        float x2 = box[2].GetSingle();
                                        float y2 = box[3].GetSingle();

                                        float w = x2 - x1;
                                        float h = y2 - y1;

                                        if (obj2detect.Any(o => string.Equals(o, label, StringComparison.OrdinalIgnoreCase)))
                                        {
                                            Console.WriteLine($"Found {label} with confidence {confidence}");

                                            using (Graphics g = Graphics.FromImage(localBitmap))
                                            using (Pen pen = new Pen(Color.Red, 1))
                                            using (Font font = new Font("Arial", 10))
                                            using (SolidBrush brush = new SolidBrush(Color.Yellow))
                                            {
                                                g.DrawRectangle(pen, x1, y1, w, h);
                                                g.DrawString($"{label} ({confidence:P1})", font, brush, new PointF(x1, y1 - 20));
                                            }

                                            string filePath = Path.Combine(path, $"{fileName}.jpg");
                                            localBitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    _semaphore.Release();
                    next_image = false;
                }
            }
        }

        public void DetectObjects(Bitmap bitmap, string path, string fileName, string[] obj2detect, string url = "http://localhost:7007/upload")
        {
            if (!_semaphore.Wait(0))
            {
                return;
            }

            if (fullUrl =="")
            {
                fullUrl = string.Format("http://{0}/upload", url);
                this.path = path;
                this.obj2detect = obj2detect.ToArray();
            }

            this.fileName = fileName;
            //lock (bitmap)
            {
                localBitmap = bitmap;
            }
            next_image = true;
        }
    }
}
