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
        private static int Id = 0;
        private static List<Player> players = new List<Player>() { new Player(++Id, "S1mple", "Александр", "Костылев"),
            new Player(++Id, "Electronic", "Денис", "Шарипов"),
             new Player(++Id, "Boombl4", "Кирилл", "Михайлов"),
              new Player(++Id, "Perfecto", "Илья", "Залуцкий"),
               new Player(++Id, "B1t", "Валерий", "Ваховский"),
                new Player(++Id, "B1ad3", "Андрей", "Городенский") };
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Player Get(int id)
        {
            if (id < players.Count && id > 0)
            {
                return players[id - 1];
            }
            return null;
        }
        [HttpPost]
        public string Post(string nickname, string firstName, string secondName)
        {
            players.Add(new Player(++Id, nickname, firstName, secondName));
            return $"{nickname} added!";
        }
        [HttpDelete]
        public StatusCodeResult Delete(int id)
        {
            int index = players.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return StatusCode(204);
            }
            players.RemoveAt(index);
            return StatusCode(200);
        }
        [HttpPatch]
        public StatusCodeResult Patch(int oldId, string nickname, string firstName, string secondName)
        {
            int index = players.FindIndex(x => x.Id == oldId);
            if (index == -1)
            {
                return StatusCode(204);
            }

            players[index] = new Player(oldId, nickname, firstName, secondName);
            return StatusCode(200);
        }
    }
}
