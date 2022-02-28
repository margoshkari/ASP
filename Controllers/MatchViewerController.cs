using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication7.Controllers
{
    public partial class MatchController
    {
        SqlOperation sqlOperation = new SqlOperation();
        [HttpGet]
        public IEnumerable<Match> Get(string token)
        {
            if (sqlOperation.CompareTokens(token))
                return matches;

            return null;
        }
    }
}
