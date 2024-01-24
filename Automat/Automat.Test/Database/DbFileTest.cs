using Automat.Lib.Database.Data;
using Automat.Lib.Database.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Automat.Test;

[TestClass]
public class DbFileTest
{
    private DbContextOptions<AutomatDbContext> _options;

    public DbFileTest()
    {
        using var connection = new SqliteConnection("DataSource=AutomatDbSqlite-test.db");
        connection.Open();
        _options = new DbContextOptionsBuilder<AutomatDbContext>()
            .UseSqlite(connection)                  
            .Options;
    } 
    
    [TestMethod]
    public void InitializeDatabaseAndReadData()
    {
        using (var context = new AutomatDbContext(_options))
        {
            Assert.AreEqual(context.Automarken.Find(1)?.Name, "BMW");
            Assert.AreEqual(context.Automarken.Find(2)?.Name, "Volkswagen");
            Assert.AreEqual(context.Automarken.Find(3)?.Name, "Audi");
            Assert.AreEqual(context.Autobewertungen.Find(1)?.AutomodellId, 1);
            Autobewertung autobewertung = context.Autobewertungen.Include(abw => abw.Automodell).First(abw => abw.AutobewertungId == 10);
            Assert.AreEqual(autobewertung.Automodell.Name, "BMW 318i Touring");
        }
    }
}