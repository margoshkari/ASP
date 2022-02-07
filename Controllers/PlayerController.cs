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
        private static List<Player> players = new List<Player>() { new Player("S1mple", "Александр", "Костылев"),
            new Player("Electronic", "Денис", "Шарипов"),
             new Player("Boombl4", "Кирилл", "Михайлов"),
              new Player("Perfecto", "Илья", "Залуцкий"),
               new Player("B1t", "Валерий", "Ваховский"),
                new Player("B1ad3", "Андрей", "Городенский") };
        private readonly ILogger<WeatherForecastController> _logger;

        public PlayerController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return players;
        }
        [HttpPost]
        public string Post(string nickname, string firstName, string secondName)
        {
            players.Add(new Player(nickname, firstName, secondName));
            return $"{nickname} added!";
        }
        [HttpDelete]
        public StatusCodeResult Delete(string nickname)
        {
            if (players.FindIndex(x => x.Nickname == nickname) == -1)
            {
                return StatusCode(204);
            }
            players.RemoveAt(players.FindIndex(x => x.Nickname == nickname));
            return StatusCode(200);
        }
        [HttpPatch]
        public StatusCodeResult Patch(string oldNickname, string newNickname)
        {
            if (players.FindIndex(x => x.Nickname == oldNickname) == -1)
            {
                return StatusCode(204);
            }

            players[players.FindIndex(x => x.Nickname == oldNickname)].Nickname = newNickname;
            return StatusCode(200);
        }
    }
}
