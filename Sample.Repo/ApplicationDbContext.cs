using Microsoft.EntityFrameworkCore;
using Sample.Repo.Entities;

namespace Sample.Repo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client>? Clients { get; set; }
        
    }
}
