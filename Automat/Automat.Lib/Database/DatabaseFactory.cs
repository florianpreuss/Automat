using Automat.Lib.Database.Data;

namespace Automat.Lib.Database;

public class DatabaseFactory
{
    private SqliteDbContext sqliteDbContext = new SqliteDbContext();

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