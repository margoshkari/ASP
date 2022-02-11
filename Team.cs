namespace WebApplication7
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Team()
        {
            Id = 0;
            Name = string.Empty;
        }
        public Team(int id, string name)
        {
            Name = name;
            Id = id;
        }
    }
}
