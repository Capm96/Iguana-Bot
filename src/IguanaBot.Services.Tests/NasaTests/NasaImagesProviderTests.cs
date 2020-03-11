using DSharpPlus.Entities;
using IguanaBot.Services.Nasa;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IguanaBot.Services.Tests.NasaTests
{
    [TestFixture]
    public class NasaImagesProviderTests
    {
        private NasaImagesProvider _nasaImagesProvider;

        [SetUp]
        public void InitializeNasaImagesProvider()
        {
            _nasaImagesProvider = new NasaImagesProvider();
        }

        [Test]
        public async Task GetImageFromToday_WorksAsExpected()
        {
            // Arrange - 
            var embed = new DiscordEmbedBuilder()
            {
                Title = "",
                ImageUrl = ""
            };

            // Act -
            embed = await _nasaImagesProvider.GetImageFromToday();

            // Assert -
            Assert.IsTrue(embed.Title.Length > 0);
            Assert.IsTrue(embed.ImageUrl.Length > 0);
        }

        [Test]
        public async Task GetImageFromGivenDate_WorksAsExpected()
        {
            // Arrange - 
            var embed = new DiscordEmbedBuilder()
            {
                Title = "",
                ImageUrl = ""
            };

            // Act -
            embed = await _nasaImagesProvider.GetImageWithGivenDate("2020-03-11");

            // Assert -
            Assert.IsTrue(embed.Title.Length > 0);
            Assert.IsTrue(embed.ImageUrl.Length > 0);
        }
    }
}
