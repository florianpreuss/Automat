using Automat.Lib.Database.Data;

namespace Automat.Lib.Database;

public class DatabaseFactory
{
    private AutomatDbContext _automatDbContext = new AutomatDbContext();

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