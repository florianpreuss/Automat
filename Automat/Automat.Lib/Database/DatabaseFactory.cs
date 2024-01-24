using Automat.Lib.Database.Data;
using Automat.Lib.Database.Impl;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database;

public class DatabaseFactory
{
    private AutomatDbContext AutomatDbContext;
    private IAutoRepository AutoRepository;
    private IBewertungRepository BewertungRepository;
    private IFeedbackRepository FeedbackRepository;
    
    public DatabaseFactory(string filename)
    {
        SqliteConnection connection = new SqliteConnection("DataSource=" + filename);
        connection.Open();
        DbContextOptions<AutomatDbContext> options = new DbContextOptionsBuilder<AutomatDbContext>()
            .UseSqlite(connection)
            .Options;
        connection.Close();
        Initialize(options);
    }
    
    public DatabaseFactory(DbContextOptions<AutomatDbContext> options)
    {
        Initialize(options);
    }

    private void Initialize(DbContextOptions<AutomatDbContext> options)
    {
        AutomatDbContext = new AutomatDbContext(options);
        AutoRepository = new AutoRepositoryImpl(AutomatDbContext);
        BewertungRepository = new BewertungRepositoryImpl(AutomatDbContext);
        FeedbackRepository = new FeedbackRepositoryImpl(AutomatDbContext);
    }
    
    public IAutoRepository GetAutoRepository()
    {
        return AutoRepository;
    }

    public IBewertungRepository GetBewertungRepository()
    {
        return BewertungRepository;
    }

    public IFeedbackRepository GetFeedbackRepository()
    {
        return FeedbackRepository;
    }

    public AutomatDbContext GetAutomatDbContext()
    {
        return AutomatDbContext;
    }
}