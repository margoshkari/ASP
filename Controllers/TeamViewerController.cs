using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication7.Controllers
{
    public partial class TeamController
    {
        SqlOperation sqlOperation = new SqlOperation();
        [HttpGet]
        public IEnumerable<Team> Get(string token)
        {
            if(sqlOperation.CompareTokens(token))
                return teams;

            return null;
        }
    }
}
