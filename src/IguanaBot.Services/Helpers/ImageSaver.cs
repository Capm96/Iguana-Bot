using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace IguanaBot.Services.Helpers
{
    public static class ImageSaver
    {
        public static void SaveImage(string imageUrl, string filename, ImageFormat format)
        {
            if (File.Exists(filename))
                File.Delete(filename);

            var client = new WebClient();
            var stream = client.OpenRead(imageUrl);
            var bitmap = new Bitmap(stream);

            if (bitmap != null)
                bitmap.Save(filename, format);

            stream.Flush();
            stream.Close();
            client.Dispose();
        }
    }
}
