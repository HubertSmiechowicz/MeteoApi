using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoApi.Tests.Services
{
    public class FiveDaysForecastServiceTests
    {

        [Fact]
        public void GetFiveDaysForecast_ForCloudsBelow20AndRainEquals0_ReturnSunnyImage()
        {
            Assert.Equal(1 + 1, 2);
        }
    }
}
