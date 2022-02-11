using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class PlayerController : ControllerBase
    {
        private static int Id = 0;
        private static List<Player> players = new List<Player>() { new Player(++Id, "S1mple", "Александр", "Костылев", TeamController.teams[0]),
                                                                    new Player(++Id, "Electronic", "Денис", "Шарипов", TeamController.teams[0]),
                                                                     new Player(++Id, "Boombl4", "Кирилл", "Михайлов", TeamController.teams[0]),
                                                                      new Player(++Id, "Perfecto", "Илья", "Залуцкий", TeamController.teams[0]),
                                                                       new Player(++Id, "B1t", "Валерий", "Ваховский", TeamController.teams[0]),
                                                                        new Player(++Id, "B1ad3", "Андрей", "Городенский", TeamController.teams[0]) };
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public StatusCodeResult Post(string nickname, string firstName, string secondName, string teamName)
        {
            int index = TeamController.teams.FindIndex(x => x.Name == teamName);
            if (index == -1 || nickname == null || firstName == null || secondName == null)
            {
                return StatusCode(204);
            }
            players.Add(new Player(++Id, nickname, firstName, secondName, TeamController.teams[index]));
            return StatusCode(200);
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
        public StatusCodeResult Patch(int oldId, string nickname, string firstName, string secondName, string teamName)
        {
            int index = players.FindIndex(x => x.Id == oldId);
            int teamIndex = TeamController.teams.FindIndex(x => x.Name == teamName);
            if (index == -1 || teamIndex == -1 || nickname == null || firstName == null || secondName == null)
            {
                return StatusCode(204);
            }

            players[index] = new Player(oldId, nickname, firstName, secondName, TeamController.teams[teamIndex]);
            return StatusCode(200);
        }
    }
}
