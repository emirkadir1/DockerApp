namespace DockerApp.Models
{
    public class Debts
    {
            public int Id { get; set; }
            public int UsersDebt { get; set; }
            public User User { get; set; }
            public int UserId { get; set; }
    }
}
