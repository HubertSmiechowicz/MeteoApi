using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoApi.Models;
using Moq;

namespace MeteoApi.Tests.Models
{
    public class MainDateTests
    {

        [Theory]
        [InlineData(294.15, 21)]
        [InlineData(295.15, 22)]
        [InlineData(296.15, 23)]
        [InlineData(297.15, 24)]
        [InlineData(298.15, 25)]
        [InlineData(299.15, 26)]
        public void CalculateTemp_ForGivenData_ReturnsCorrectRoundedTemperature(double temp, double result)
        {
            // arrange

            MainDate mainDate = new MainDate(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>());

            // act 

            double temperature = mainDate.CalculateTemp(temp);

            // assert

            Assert.True(temperature == result);
        }
    }
}
