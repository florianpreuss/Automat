using Automat.Lib.Database.Data;
using Automat.Lib.Database.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Automat.Test;

[TestClass]
public class DbContextInitTests
{
    private DbContextOptions<AutomatDbContext> _options;

    public DbContextInitTests()
    {
        using var connection = new SqliteConnection("DataSource=file::memory:?cache=shared");
        connection.Open();
        _options = new DbContextOptionsBuilder<AutomatDbContext>()
            .UseSqlite(connection)                  
            .Options;
    }
    
    [TestMethod]
    public void InitializeDatabaseWithDataTest()
    {
        using (var context = new AutomatDbContext(_options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var MarkeBMW = new Automarke()
            {
                AutomarkeId = 1,
                Name = "BMW",
                LogoUrl = "https://example.com/bmw_logo.png"
            };
            
            var MarkeVolkswagen = new Automarke()
            {
                AutomarkeId = 2,
                Name = "Volkswagen",
                LogoUrl = "https://example.com/bmw_logo.png"
            };
            
            context.Automarken.AddRange(MarkeBMW, MarkeVolkswagen);
            
            context.SaveChanges();

            Assert.AreEqual(context.Automarken.Find(1)?.Name, "BMW");
            Assert.AreEqual(context.Automarken.Find(2)?.Name, "Volkswagen");
        }
    }
}