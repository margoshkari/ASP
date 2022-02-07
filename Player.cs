namespace WebApplication7
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondNme { get; set; }
        public string Nickname { get; set; }
        public Player()
        {
            Id = 0;
        }
        public Player(string nickname, string firstname, string secondname)
        {
            Nickname = nickname;
            FirstName = firstname;
            SecondNme = secondname;
        }
    }
}
