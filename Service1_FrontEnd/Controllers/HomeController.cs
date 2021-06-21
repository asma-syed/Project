using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service1_FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //private IConfiguration Configuration;

        /*public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {

             Configuration = configuration;
        } */

        private AppSettings Configuration;
        private HttpClient _client;
        public HomeController(IOptions<AppSettings> settings, HttpClient client)
        {

            Configuration = settings.Value;
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var serviceFour = $"{Configuration["serviceFourURL"]}/namesandsurnames";
            //var serviceFour = "https://localhost:44322/namesandsurnames";

            var serviceFour = $"{Configuration.serviceFourURL}/namesandsurnames";
            var merged_serviceFour = await _client.GetStringAsync(serviceFour);
            ViewBag.responseCall = merged_serviceFour;
            return View();
        }
    }
}
/*
[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private HttpClient _client;

    public HomeController(ILogger<HomeController> logger, HttpClient client)
    {
        _logger = logger;
        _client = client;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        string serviceFour = "https://localhost:44322/namesandsurnames";
        var merged_serviceFour = await _client.GetStringAsync(serviceFour);
        return Ok(merged_serviceFour);
    }
}
}
*/

