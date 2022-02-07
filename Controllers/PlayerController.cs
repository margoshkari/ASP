using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private List<string> players = new List<string>() { "S1mple", "Electronic", "Boombl4", "Perfecto", "B1t", "B1ad3" };
        private readonly ILogger<WeatherForecastController> _logger;

        public PlayerController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return players;
        }

        [HttpPost]
        public string Post(string item)
        {
            players.Add(item);
            return $"{item} added!";
        }
        [HttpDelete]
        public StatusCodeResult Delete(string item)
        {
            if(players.FindIndex(x => x == item) == -1)
            {
                return StatusCode(204);
            }

            return StatusCode(200);
        }
        [HttpPatch]
        public StatusCodeResult Patch(string _old, string _new)
        {
            if (players.FindIndex(x => x == _old) != -1)
            {
                players[players.FindIndex(x => x == _old)] = _new;
            }

            return StatusCode(200);
        }
    }
}
