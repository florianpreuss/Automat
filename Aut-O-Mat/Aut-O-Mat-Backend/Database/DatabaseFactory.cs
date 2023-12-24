using Aut_O_Mat_Backend.Database.Impl;      

namespace Aut_O_Mat_Backend.Database;

public class DatabaseFactory
{
    private AutomatDbContext _automatDbContext = new AutomatDbContext();
    public DatabaseFactory(string databaseFile)
    {
        _automatDbContext.Database.EnsureCreatedAsync();
    }

    public IAutoRepository GetAutoRepository()
    {
        throw new InvalidOperationException();
    }

    public IBewertungRepository GetBewertungRepository()
    {
        throw new InvalidOperationException();
    }

    public IFeedbackRepository GetFeedbackRepository()
    {
        throw new InvalidOperationException();
    }
}