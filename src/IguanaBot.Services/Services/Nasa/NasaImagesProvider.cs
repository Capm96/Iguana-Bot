using System;
using System.Drawing.Imaging;
using System.IO;
using Apod;
using IguanaBot.JsonHandler;
using IguanaBot.Services.Helpers;
using IguanaBot.Services.JsonHandler;

namespace IguanaBot.Services.Nasa
{
    public class NasaImagesProvider
    {
        public ApodClient ApodClient { get; set; }
        public JsonConfiguration JsonConfiguration { get; set; }
        public string LocalImagePath { get; set; }

        public NasaImagesProvider()
        {
            JsonConfiguration = MyJsonReader.GetJsonWithTokens();
            ApodClient = new ApodClient(JsonConfiguration.NasaToken);
            LocalImagePath = Path.GetTempPath() + $@"\today.jpeg";
        }

        public async void GetImageOfTheDayFromToday()
        {
            var result = await ApodClient.FetchApodAsync(DateTime.Today);

            if (result.StatusCode != ApodStatusCode.OK)
            {
                // Handle error.
                return;
            }

            var imageURL = result.Content.ContentUrl;
            ImageSaver.SaveImage(imageURL, LocalImagePath, ImageFormat.Jpeg);
        }

        public async void GetImageWithGivenDate(string selectedDate)
        {
            var date = DateTime.Parse(selectedDate);
            var result = await ApodClient.FetchApodAsync(date);

            if (result.StatusCode != ApodStatusCode.OK)
            {
                // Handle error.
                return;
            }

            var imageURL = result.Content.ContentUrl;
            ImageSaver.SaveImage(imageURL, LocalImagePath, ImageFormat.Jpeg);
        }
    }
}
