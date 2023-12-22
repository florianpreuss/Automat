using Aut_O_Mat_Backend.Database.Impl;

namespace Aut_O_Mat_Backend.Database;

public class DatabaseFactory
{
    private DbContext DbContext = new DbContext();
    public DatabaseFactory(string databaseFile)
    {
        DbContext.Database.EnsureCreatedAsync();
    }
}