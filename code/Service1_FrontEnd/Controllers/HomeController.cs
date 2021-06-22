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

