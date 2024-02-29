using Automat.Lib.Database.Data;
using Automat.Lib.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Impl;

public class RatingRepositoryImpl : IRatingRepository
{
    private AutomatDbContext AutomatDbContext;
    public RatingRepositoryImpl(AutomatDbContext automatDbContext)
    {
        this.AutomatDbContext = automatDbContext;
    }
    public AutomatDbContext GetDbContext()
    {
        return AutomatDbContext;
    }

    public List<RatingCategory> GetRatingCategories()
    {
        return AutomatDbContext.RatingCategories.ToList();
    }

    public List<Model.Model> GetRateableModels()
    {
        return AutomatDbContext.ModelRatings.Include(abw => abw.Model)
            .Select(abw => abw.Model).Distinct().ToList();
    }

    public ModelRating? FindRatingByModelAndRatingCategory(Model.Model model, RatingCategory ratingCategory)
    {
        return AutomatDbContext.ModelRatings.Include(abw => abw.Model)
            .Include(abw => abw.RatingCategory).FirstOrDefault(abw =>
                abw.Model == model && abw.RatingCategory == ratingCategory);
    }
}