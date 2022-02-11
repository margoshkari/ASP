using System;

namespace WebApplication7
{
    public class Match
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public Team FirstTeam { get; set; }
        public Team SecondTeam { get; set; }
        public Match()
        {
            ID = 0;
            DateTime = DateTime.MinValue;
            FirstTeam = new Team();
            SecondTeam = new Team();
        }
        public Match(int id, DateTime dateTime, Team firstTeam, Team secondTeam)
        {
            ID = id;
            DateTime = dateTime;
            FirstTeam = firstTeam;
            SecondTeam = secondTeam;
        }
    }
}
