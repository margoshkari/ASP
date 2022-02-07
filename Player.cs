namespace WebApplication7
{
    public class Player
    {
        public string FirstName { get; set; }
        public string SecondNme { get; set; }
        public string Nickname { get; set; }
        public Player(string nickname, string firstname, string secondname)
        {
            Nickname = nickname;
            FirstName = firstname;
            SecondNme = secondname;
        }
    }
}
