using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication7.Controllers
{
    public partial class PlayerController
    {
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return players;
        }
    }
}
