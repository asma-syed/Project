using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service4_NamesandSurnames.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    //public class NamesandSurnamesController : ControllerBase
    //{
    //    //private IConfiguration Configuration;
    //    //public NamesandSurnamesController(IConfiguration configuration)
    //    //{
    //    //    Configuration = configuration;
    //    //}

    //    private AppSettings Configuration;
    //    public NamesandSurnamesController(IOptions<AppSettings> settings)
    //    {
    //        Configuration = settings.Value;
    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> Get()
    //    {
    //        //var namesService = "https://localhost:44384/names";
    //        var namesService = $"{Configuration.namesServiceURL}/names";
    //        var serviceTwo = await new HttpClient().GetStringAsync(namesService);

    //        //var surnameService = "https://localhost:44377/surnames";
    //        var surnamesService = $"{Configuration.surnamesServiceURL}/surnames";
    //        var serviceThree = await new HttpClient().GetStringAsync(surnamesService);

    //        var mergedServices = serviceTwo + serviceThree;
    //        return Ok(mergedServices);
    //    }
    //}

    [ApiController]
    [Route("[controller]")]
    public class NamesandSurnamesController : ControllerBase
    {
        private HttpClient _client;
        private AppSettings Configuration;


        public NamesandSurnamesController(IOptions<AppSettings> settings, HttpClient client)
        {
            _client = client;
            Configuration = settings.Value;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //string namesService = "https://localhost:44384/names";
            var namesService = $"{Configuration.namesServiceURL}/names";
            var serviceTwo = await _client.GetStringAsync(namesService);

            //string surnamesService = "https://localhost:44377/surnames";
            var surnamesService = $"{Configuration.surnamesServiceURL}/surnames";
            var serviceThree = await _client.GetStringAsync(surnamesService);

            var mergedServices = serviceTwo +" " + serviceThree;
            return Ok(mergedServices);
        }
    }
}

