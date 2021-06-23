using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using RichardSzalay.MockHttp;
using Service4_NamesandSurnames;
using Service4_NamesandSurnames.Controllers;
using System.Net.Http;
using Xunit;

//Referencing my collegues' Aaron's demo on testing

namespace TEST
{
    public class MergedTEST
    {
        private NamesandSurnamesController namesandSurnamesController;

        private AppSettings appSettings = new AppSettings()
        {
            namesServiceURL = "https://asma-alias-names.azurewebsites.net",
            surnamesServiceURL = "https://asma-alias-surnames2.azurewebsites.net"
        };

        public MergedTEST()
        {

        }

        [Fact]
        public async void GetTest()
        {
            //Arrange
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://asma-alias-names.azurewebsites.net/names")
                .Respond("text/plain", "Federico");

            mockHttp.When("https://asma-alias-surnames2.azurewebsites.net/surnames")
                .Respond("text/plain", "Pentola");

            var client = new HttpClient(mockHttp);
            namesandSurnamesController = new NamesandSurnamesController(options.Object, client);

            //Act
            var response = await namesandSurnamesController.Get();
            string result = (string)((OkObjectResult)response).Value;

            //Assert
            Assert.Equal("Federico Pentola", result);
        }
        
        [Fact]
        public async void GetTestRandom()
        {
            //Arrange
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://asma-alias-names.azurewebsites.net/names")
                .Respond("text/plain", "Random");

            mockHttp.When("https://asma-alias-surnames2.azurewebsites.net/surnames")
                .Respond("text/plain", "Random");

            var client = new HttpClient(mockHttp);
            namesandSurnamesController = new NamesandSurnamesController(options.Object, client);

            //Act
            var response = await namesandSurnamesController.Get();
            string result = (string)((OkObjectResult)response).Value;

            //Assert
            Assert.Equal("Random Random", result);
        }
        
    }
}
