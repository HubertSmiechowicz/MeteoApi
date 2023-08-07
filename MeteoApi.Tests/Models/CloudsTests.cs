using MeteoApi.Models;
using MeteoApi.Models.daily;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MeteoApi.Tests.Models
{
    public class CloudsTests
    {

        [Theory]
        [InlineData("0", "src/assets/sunny.png")]
        [InlineData("10", "src/assets/sunny.png")]
        [InlineData("16", "src/assets/sunny.png")]
        [InlineData("19", "src/assets/sunny.png")]
        [InlineData("20", "src/assets/littleClouds.png")]
        [InlineData("29", "src/assets/littleClouds.png")]
        [InlineData("35", "src/assets/littleClouds.png")]
        [InlineData("39", "src/assets/littleClouds.png")]
        [InlineData("40", "src/assets/moreClouds.png")]
        [InlineData("48", "src/assets/moreClouds.png")]
        [InlineData("54", "src/assets/moreClouds.png")]
        [InlineData("59", "src/assets/moreClouds.png")]
        [InlineData("60", "src/assets/bigClouds.png")]
        [InlineData("67", "src/assets/bigClouds.png")]
        [InlineData("76", "src/assets/bigClouds.png")]
        [InlineData("79", "src/assets/bigClouds.png")]
        [InlineData("80", "src/assets/hardClouds.png")]
        [InlineData("89", "src/assets/hardClouds.png")]
        [InlineData("91", "src/assets/hardClouds.png")]
        [InlineData("100", "src/assets/hardClouds.png")]
        [InlineData("101", "")]
        [InlineData("110", "")]
        [InlineData("200", "")]
        [InlineData("300", "")]
        public void GetCloudImage_ForDifferentsAllAndRainEquals0_ReturnCorrectImage(string all, string imageUrl)
        {
            // arrange

            Clouds clouds = new Clouds(all);
            Rain rain = new Rain("0");

            // act

            string image = clouds.GetCloudImage(rain);

            // assert

            Assert.Equal(imageUrl, image);
        }

        [Theory]
        [InlineData("0.1")]
        [InlineData("0.5")]
        [InlineData("1")]
        [InlineData("1.2")]
        public void GetCloudImage_ForAllBetween0And100AndRainAbove_ReturnRainImage(string rainArg)
        {
            // arrange

            Clouds clouds = new Clouds("39");
            Rain rain = new Rain(rainArg);

            // act

            string image = clouds.GetCloudImage(rain);

            // assert

            Assert.Equal("src/assets/rain.png", image);
        }
    }
}
