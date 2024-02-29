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
    private ICarRepository CarRepository;
    private IRatingRepository RatingRepository;
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
        CarRepository = factory.GetCarRepository();
        RatingRepository = factory.GetRatingRepository();
        FeedbackRepository = factory.GetFeedbackRepository();
        
        AutomatDbContext.Database.EnsureDeleted();
        AutomatDbContext.Database.EnsureCreated();

        var BrandBMW = new Brand()
        {
            BrandId = 1,
            Name = "BMW",
            IconUrl = "https://example.com/bmw_logo.png"
        };

        var BrandVolkswagen = new Brand()
        {
            BrandId = 2,
            Name = "Volkswagen",
            IconUrl = "https://example.com/bmw_logo.png"
        };

        var SUV = new BodyStyle()
        {
            BodyStyleId = 1,
            Name = "SUV",
        };
        var Compact = new BodyStyle()
        {
            BodyStyleId = 2,
            Name = "Kleinwagen",
        };
        var BMW118D = new Model()
        {
            ModelId = 1,
            BrandId = 1,
            BodyStyleId = 1,
            Name = "BMW 118d"
        };
        var PersonAmount = new RatingCategory()
        {
            RatingCategoryId = 1,
            Name = "Personenanzahl",
            Question = "Wie viele Personen möchten Sie befördern?",
            TagMin = "2",
            TagMax = "7",
            Weighting = 1.0m
        };
        AutomatDbContext.Brands.AddRange(BrandBMW, BrandVolkswagen);
        AutomatDbContext.BodyStyles.AddRange(SUV, Compact);
        AutomatDbContext.Models.AddRange(BMW118D);
        AutomatDbContext.RatingCategories.AddRange(PersonAmount);

        AutomatDbContext.ModelRatings.Add(new ModelRating()
        {
            ModelRatingId = 1,
            RatingCategoryId = 1,
            ModelId = 1,
            Rating = 0.6m
        });
        
        AutomatDbContext.SaveChanges();
        Assert.AreEqual(AutomatDbContext.Brands.Find(1)?.Name, "BMW");
        Assert.AreEqual(AutomatDbContext.Brands.Find(2)?.Name, "Volkswagen");
    }

    [TestMethod]
    public void testRepositories()
    {
        var brands = CarRepository.GetAllBrands();
        var bodyStyles = CarRepository.GetAllBodyStyles();

        Assert.AreEqual(brands.Count, 2);
        Assert.AreEqual(bodyStyles.Count, 2);

        Assert.AreEqual(RatingRepository.GetRatingCategories().Count, 1);
        Assert.AreEqual(RatingRepository.GetRateableModels().Count, 1);

        FeedbackRepository.AddFeedback(new Feedback()
        {
            FeedbackId = 1,
            Rating = 5
        });
        FeedbackRepository.AddFeedback(new Feedback()
        {
            FeedbackId = 2,
            Rating = 5
        });

        Assert.AreEqual(AutomatDbContext.Feedbacks.ToList().Count, 2);
    }
}