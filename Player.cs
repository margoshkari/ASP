namespace WebApplication7
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondNme { get; set; }
        public string Nickname { get; set; }
        public Team team { get; set; }
        public Player()
        {
            Id = 0;
            Nickname = string.Empty;
            FirstName = string.Empty;
            SecondNme = string.Empty;
            team = new Team();
        }
        public Player(int id, string nickname, string firstname, string secondname, Team team)
        {
            Id = id;
            Nickname = nickname;
            FirstName = firstname;
            SecondNme = secondname;
            this.team = team;
        }
    }
}
