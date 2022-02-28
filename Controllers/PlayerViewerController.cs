using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication7.Controllers
{
    public partial class PlayerController
    {
        SqlOperation sqlOperation = new SqlOperation();
        [HttpGet]
        public IEnumerable<Player> Get(string token)
        {
            if (sqlOperation.CompareTokens(token))
                return players;

            return null;
        }
    }
}
