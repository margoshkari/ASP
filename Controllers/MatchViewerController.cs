using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication7.Controllers
{
    public partial class MatchController
    {
        [HttpGet]
        public IEnumerable<Match> Get()
        {
            return matches;
        }
    }
}
