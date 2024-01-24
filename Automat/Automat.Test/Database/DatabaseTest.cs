using Automat.Lib.Database;
using Automat.Lib.Database.Data;
using Automat.Lib.Database.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Automat.Test.Database;

[TestClass]
public class DatabaseTest
{
    private DbContextOptions<AutomatDbContext> _options;
    private AutomatDbContext AutomatDbContext;
    private IAutoRepository AutoRepository;
    private IBewertungRepository BewertungRepository;
    private IFeedbackRepository FeedbackRepository;

    public DatabaseTest()
    {
        using var connection = new SqliteConnection("DataSource=file::memory:?cache=shared");
        connection.Open();
        _options = new DbContextOptionsBuilder<AutomatDbContext>()
            .UseSqlite(connection)
            .Options;
        InitializeDatabaseWithDataTest();
    }

    public void InitializeDatabaseWithDataTest()
    {
        var factory = new DatabaseFactory(_options);
        AutomatDbContext = factory.GetAutomatDbContext();
        AutoRepository = factory.GetAutoRepository();
        BewertungRepository = factory.GetBewertungRepository();
        FeedbackRepository = factory.GetFeedbackRepository();
        
        AutomatDbContext.Database.EnsureDeleted();
        AutomatDbContext.Database.EnsureCreated();

        var MarkeBMW = new Automarke()
        {
            AutomarkeId = 1,
            Name = "BMW",
            LogoUrl = "https://example.com/bmw_logo.png"
        };

        var MarkeVolkswagen = new Automarke()
        {
            AutomarkeId = 2,
            Name = "Volkswagen",
            LogoUrl = "https://example.com/bmw_logo.png"
        };

        var SUV = new Karosserieform()
        {
            KarosserieformId = 1,
            Name = "SUV",
        };
        var Kleinwagen = new Karosserieform()
        {
            KarosserieformId = 2,
            Name = "Kleinwagen",
        };
        var BMW118D = new Automodell()
        {
            AutomodellId = 1,
            AutomarkeId = 1,
            KarosserieformId = 1,
            Name = "BMW 118d"
        };
        var Personen = new Bewertungskategorie()
        {
            BewertungskategorieId = 1,
            Name = "Personenanzahl",
            Fragestellung = "Wie viele Personen möchten Sie befördern?",
            TagMin = "2",
            TagMax = "7",
            Gewichtung = 1.0m
        };
        AutomatDbContext.Automarken.AddRange(MarkeBMW, MarkeVolkswagen);
        AutomatDbContext.Karosserieformen.AddRange(SUV, Kleinwagen);
        AutomatDbContext.Automodelle.AddRange(BMW118D);
        AutomatDbContext.Bewertungskategorien.AddRange(Personen);
        
        AutomatDbContext.Autobewertungen.Add(new Autobewertung()
        {
            AutobewertungId = 1,
            BewertungskategorieId = 1,
            AutomodellId = 1,
            Bewertung = 0.6m
        });
        
        AutomatDbContext.SaveChanges();
        Assert.AreEqual(AutomatDbContext.Automarken.Find(1)?.Name, "BMW");
        Assert.AreEqual(AutomatDbContext.Automarken.Find(2)?.Name, "Volkswagen");
    }

    [TestMethod]
    public void testRepositories()
    {
        
        var automarken = AutoRepository.GetAllAutomarken();
        var karosserieformen = AutoRepository.GetAllKarosserieformen();
        
        Assert.AreEqual(automarken.Count, 2);
        Assert.AreEqual(karosserieformen.Count, 2);
        
        Assert.AreEqual(BewertungRepository.GetBewertungskategorien().Count, 1);
        Assert.AreEqual(BewertungRepository.GetRateableModels().Count, 1);
        
        FeedbackRepository.AddFeedback(new Feedback()
        {
            FeedbackId = 1,
            Bewertung = 5
        });
        FeedbackRepository.AddFeedback(new Feedback()
        {
            FeedbackId = 2,
            Bewertung = 5
        });

        Assert.AreEqual(AutomatDbContext.Feedbacks.ToList().Count, 2);
    }
}