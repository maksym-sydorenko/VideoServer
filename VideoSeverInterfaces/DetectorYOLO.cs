using System;
using System.Drawing;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;

namespace Interfaces
{
    public class DetectorYOLO
    {
        public static async Task DetectObjects(Bitmap bitmap,string bitmap_name, string url = "http://localhost:7007/upload")
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Seek(0, SeekOrigin.Begin);

                using (HttpClient client = new HttpClient())
                {
                    using (MultipartFormDataContent form = new MultipartFormDataContent())
                    {

                        var fileContent = new StreamContent(ms);
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

                        form.Add(fileContent, "file", String.Format("{0}.jpg", bitmap_name));
                        var response = await client.PostAsync(url, form);
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(result);
                    }
                }
            }
        }
    }
}
