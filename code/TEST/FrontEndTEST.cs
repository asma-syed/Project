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

//Referencing my collegues' Aaron's demo on testing

namespace TEST
{
    public class FrontEndTEST
    {
        private HomeController homeController;
        public FrontEndTEST()
        {

        }
        private AppSettings appSettings = new AppSettings()
        {
              serviceFourURL = "https://asma-alias-merge.azurewebsites.net"
        };

        [Fact]
        public async void Test4()
        {
            //Arrange
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://asma-alias-merge.azurewebsites.net/namesandsurnames")
                .Respond("text/plain", "Federico Pentola");

            var client = new HttpClient(mockHttp);
            homeController = new HomeController(options.Object, client);

            //Act
            var response = homeController.Index();

            //Assert
            Assert.NotNull(response);
        }
       
        [Fact]
        public async void Test4Random()
        {
            //Arrange
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://asma-alias-merge.azurewebsites.net/namesandsurnames")
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

