using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service3_Surnames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurnamesController : ControllerBase
    {
        private static readonly string[] Surnames = new[]
         {
            "Pentola", "Padella", "Tegola", "Rabi", "Doh", "Rokok", "Marme", "Atanas", "Darwhis", "Rossini", "Borghi", "Max", "Ragnez", "Nuvola", "Barco", "Giaccio", "Poggia", "Neve", "Giuggiola", "Santi"
        };

        [HttpGet]
        public ActionResult<string> Get()
        {
            var random = new Random();
            var returnIndex = random.Next(0, 20);
            return Surnames[returnIndex].ToString();
        }
    }
}
