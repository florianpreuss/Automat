using Automat.Lib.Database.Data;
using Automat.Lib.Database.Impl;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database;

public class DatabaseFactory
{
    private AutomatDbContext AutomatDbContext;
    private ICarRepository CarRepository;
    private IRatingRepository RatingRepository;
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
        CarRepository = new CarRepositoryImpl(AutomatDbContext);
        RatingRepository = new RatingRepositoryImpl(AutomatDbContext);
        FeedbackRepository = new FeedbackRepositoryImpl(AutomatDbContext);
    }
    
    public ICarRepository GetCarRepository()
    {
        return CarRepository;
    }

    public IRatingRepository GetRatingRepository()
    {
        return RatingRepository;
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