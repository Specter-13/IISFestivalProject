using FestivalProject.DAL;

namespace FestivalProject.Tests
{
    public class FestivalDbContextSetup
    {
        public InMemoryDbContextFactory DbContextFactory { get; }

        public FestivalDbContextSetup(string testDbName) => DbContextFactory = new InMemoryDbContextFactory(testDbName);

        public void PrepareDatabase()
        {
            using var dbx = DbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();
        }

        public void TearDownDatabase()
        {
            using var dbx = DbContextFactory.CreateDbContext();
            dbx.Database.EnsureDeleted();
        }

        public void Dispose()
        {
            TearDownDatabase();
        }
    }
}