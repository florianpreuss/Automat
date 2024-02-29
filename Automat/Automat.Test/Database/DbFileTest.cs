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
            Assert.AreEqual(context.Brands.Find(1)?.Name, "BMW");
            Assert.AreEqual(context.Brands.Find(2)?.Name, "Volkswagen");
            Assert.AreEqual(context.Brands.Find(3)?.Name, "Audi");
            Assert.AreEqual(context.ModelRatings.Find(1)?.ModelId, 1);
            ModelRating modelRating = context.ModelRatings.Include(abw => abw.Model).First(abw => abw.ModelRatingId == 10);
            Assert.AreEqual(modelRating.Model.Name, "BMW 318i Touring");
        }
    }
}