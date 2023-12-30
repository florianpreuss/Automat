using Aut_O_Mat_Lib.Database;
using Microsoft.Extensions.Configuration;

namespace Aut_O_Mat_Test;

[TestFixture]
public class DatabaseTest
{
    private DatabaseFactory DatabaseFactory;
    private string DbName = ".\\testDb1";
    
    [SetUp]
    public void Setup()
    {
        if (File.Exists(DbName)) {
            File.Delete(DbName);
        }
        Console.Write("Database Factory created!");
    }

    [Test]
    public void CreateFactoryTest()
    {
        DatabaseFactory = new DatabaseFactory();
        Console.Write("Database Factory created!");
        Assert.Pass();
    }
    
    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}