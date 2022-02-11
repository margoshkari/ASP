using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class TeamController : ControllerBase
    {
        private static int Id = 0;
        public static List<Team> teams { get; private set; } = new List<Team>() { new Team(++Id, "Na'Vi"), new Team(++Id, "Ninjas In Pyjamas") };
        private readonly ILogger<TeamController> _logger;

        public TeamController(ILogger<TeamController> logger)
        {
            _logger = logger;
        } 

        [HttpPost]
        public StatusCodeResult Post(string teamname)
        {
            if(teams.Any(item => item.Name == teamname) || teamname == null)
            {
                return StatusCode(204);
            }
            teams.Add(new Team(++Id, teamname));
            return StatusCode(200);
        }
        [HttpDelete]
        public StatusCodeResult Delete(int id)
        {
            int index = teams.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return StatusCode(204);
            }
            teams.RemoveAt(index);
            return StatusCode(200);
        }
        [HttpPatch]
        public StatusCodeResult Patch(int oldId, string teamname)
        {
            int index = teams.FindIndex(x => x.Id == oldId);
            if (index == -1 || teamname == null)
            {
                return StatusCode(204);
            }

            teams[index] = new Team(oldId, teamname);
            return StatusCode(200);
        }
    }
}
