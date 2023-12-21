using Aut_O_Mat.Database;

namespace Aut_O_Mat_Test;

public class DatabaseTest
{
    public void Setup()
    {
        var dbname = "testDb1";
        if (File.Exists(dbname)) {
            File.Delete(dbname);
        }
        DatabaseFactory databaseFactory = new DatabaseFactory(dbname);
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}