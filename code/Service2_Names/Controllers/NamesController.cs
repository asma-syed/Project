using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Referencing Dara's Code

namespace Service2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NamesController : ControllerBase
    {
        public string[] Names = new[]
        {
            "Federico", "Massimo", "Andrea", "Joel", "Hamza", "Janis", "Ioana", "Dragomir", "Noela", "Melissa", "John", "Ottavio", "italo", "Giacinto", "Marco", "Lello", "Pippo", "Badr", "Donato", "Flor"
        };

        [HttpGet]
        public ActionResult<string> Get()
        {
            var random = new Random();
            var returnIndex = random.Next(0, 20);
            return Names[returnIndex].ToString();
        }
    }
}
