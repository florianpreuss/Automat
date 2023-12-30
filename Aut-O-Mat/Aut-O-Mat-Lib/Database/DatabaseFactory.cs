using Aut_O_Mat_Lib.Database.Data;

namespace Aut_O_Mat_Lib.Database;

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