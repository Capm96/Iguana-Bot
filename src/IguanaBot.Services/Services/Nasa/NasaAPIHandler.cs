using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using Apod;
using IguanaBot.Services.JsonHandler;
using Newtonsoft.Json;

namespace IguanaBot.Services.Nasa
{
    public class NasaAPIHandler
    {
        public int MyProperty { get; set; }

        public NasaAPIHandler()
        {

        }

        public async void GetImageOfTheDayFromToday()
        {
            var configJason = await MyJsonReader.ReadJsonConfig();

            var nasaClient = new ApodClient(configJason.NasaToken);

            var date = DateTime.Today;

            var result = await nasaClient.FetchApodAsync(date);

            if (result.StatusCode != ApodStatusCode.OK)
            {
                Console.WriteLine("Someone's done an oopsie.");
                Console.WriteLine(result.Error.ErrorCode);
                Console.WriteLine(result.Error.ErrorMessage);
                return;
            }

            var apod = result.Content;

            var imageURL = apod.ContentUrl;

            SaveImage(imageURL, @"C:\Users\carlo\Desktop\Applications\nasa2.jpeg", ImageFormat.Jpeg);
        }

        public async void GetImageWithGivenDate(string dateAsString)
        {
            ApodClient client = new ApodClient("98ekpmHsclBJmCzovrohcO0bMftVVNN8gLIhhp8T");

            DateTime date = DateTime.Parse(dateAsString);

            var result = await client.FetchApodAsync(date);

            if (result.StatusCode != ApodStatusCode.OK)
            {
                Console.WriteLine("Someone's done an oopsie.");
                Console.WriteLine(result.Error.ErrorCode);
                Console.WriteLine(result.Error.ErrorMessage);
                return;
            }

            var apod = result.Content;

            var imageURL = apod.ContentUrl;

            SaveImage(imageURL, @"C:\Users\carlo\Desktop\Applications\nasa5.jpeg", ImageFormat.Jpeg);
        }

        public void SaveImage(string imageUrl, string filename, ImageFormat format)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(filename, format);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();
        }
    }
}
