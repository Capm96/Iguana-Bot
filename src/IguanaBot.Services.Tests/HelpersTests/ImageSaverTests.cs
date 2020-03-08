using IguanaBot.Services.Helpers;
using NUnit.Framework;
using System.Drawing.Imaging;
using System.IO;

namespace IguanaBot.Services.Tests.HelpersTests
{
    [TestFixture]
    public class ImageSaverTests
    {
        [Test]
        public void SaveImage_WorksAsExpected()
        {
            // Arrange - 
            var testSavingPath = Path.GetTempPath() + $@"\saveImageTest.jpeg";

            if (File.Exists(testSavingPath))
                File.Delete(testSavingPath);

            Assert.False(File.Exists(testSavingPath));

            // Act - 
            ImageSaver.SaveImage("https://apod.nasa.gov/apod/image/2003/wr124_hubbleschmidt_960.jpg",
                testSavingPath, ImageFormat.Jpeg);

            // Assert -
            Assert.True(File.Exists(testSavingPath));
        }
    }
}
