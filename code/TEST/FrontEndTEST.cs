using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using RichardSzalay.MockHttp;
using Service1_FrontEnd;
using Service1_FrontEnd.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TEST
{
    public class FrontEndTEST
    {
        private HomeController homeController;

        //private readonly ILogger<HomeController> _logger;
        public FrontEndTEST()
        {

        }
        private AppSettings appSettings = new AppSettings()
           {
              serviceFourURL = "https://asma-alias-namesandsurnames3.azurewebsites.net"
           };

        [Fact]
        public async void Test4()
        {
            //Arrange
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://asma-alias-namesandsurnames3.azurewebsites.net/namesandsurnames")
                .Respond("text/plain", "Federico Pentola");

            var client = new HttpClient(mockHttp);
            homeController = new HomeController(options.Object, client);

            //Act
            var response = homeController.Index();

            //Assert
            Assert.NotNull(response);
            //Assert.IsType<ViewResult>(response);
        }
       
        [Fact]
        public async void Test4Random()
        {
            //Arrange
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://asma-alias-namesandsurnames3.azurewebsites.net/namesandsurnames")
                .Respond("text/plain", "Random");


            var client = new HttpClient(mockHttp);
            homeController = new HomeController(options.Object, client);

            //Act
            var response = await homeController.Index();
            //string result = ((ViewResult)response) as string;

            //Assert

            Assert.IsType<ViewResult>(response);
            Assert.NotNull(response);

        }
        
    }
}

