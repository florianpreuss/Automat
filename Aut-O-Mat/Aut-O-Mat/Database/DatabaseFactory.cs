using Aut_O_Mat.Database.Impl;

namespace Aut_O_Mat.Database;

public class DatabaseFactory
{
    private DbContext DbContext = new DbContext();
    public DatabaseFactory(string databaseFile)
    {
        DbContext.Database.EnsureCreatedAsync();
    }
}