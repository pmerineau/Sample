using Microsoft.EntityFrameworkCore;
using Sample.Repo;

namespace Sample.Test.Repository
{
    public abstract class FakeRepository
    {
        protected DbContextOptions<ApplicationDbContext> CreateInMemoryDatabase(string databaseName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;
            return options;
        }
    }
}
