using Microsoft.EntityFrameworkCore;

namespace DockerApp.Models
{
    public class UserDbContext:DbContext

    {
        public UserDbContext(DbContextOptions<UserDbContext> options): base(options)
        {

        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Debts> Debts => Set<Debts>();
    }
}
