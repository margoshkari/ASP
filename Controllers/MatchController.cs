using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class MatchController : ControllerBase
    {
        private static int Id = 0;
        public static List<Match> matches { get; private set; } = new List<Match>() { new Match(++Id, new DateTime(2020, 02, 06), TeamController.teams[0], TeamController.teams[1]) };
        private readonly ILogger<MatchController> _logger;

        public MatchController(ILogger<MatchController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public StatusCodeResult Post(DateTime? dateTime, string firstTeam, string secondTeam)
        {
            (int first, int second) = getIndexes(firstTeam, secondTeam);
            if (first == -1 || second == -1 || dateTime == null)
            {
                return StatusCode(204);
            }
            matches.Add(new Match(++Id, (DateTime)dateTime, TeamController.teams[first], TeamController.teams[second]));
            return StatusCode(200);
        }
        [HttpDelete]
        public StatusCodeResult Delete(int id)
        {
            int index = matches.FindIndex(x => x.ID == id);
            if (index == -1)
            {
                return StatusCode(204);
            }
            matches.RemoveAt(index);
            return StatusCode(200);
        }
        [HttpPatch]
        public StatusCodeResult Patch(int oldId, DateTime? dateTime, string firstTeam, string secondTeam)
        {
            int index = matches.FindIndex(x => x.ID == oldId);
            (int first, int second) = getIndexes(firstTeam, secondTeam);
            if (index == -1 || first == -1 || second == -1 || dateTime == null)
            {
                return StatusCode(204);
            }

            matches[index] = new Match(oldId, (DateTime)dateTime, TeamController.teams[first], TeamController.teams[second]);
            return StatusCode(200);
        }
        private (int, int) getIndexes(string firstTeam, string secondTeam)
        {
            int first = TeamController.teams.FindIndex(x => x.Name == firstTeam);
            int second = TeamController.teams.FindIndex(x => x.Name == secondTeam);
            return (first, second);
        }
    }
}
