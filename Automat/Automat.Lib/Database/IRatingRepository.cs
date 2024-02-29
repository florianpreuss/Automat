using Automat.Lib.Database.Data;
using Automat.Lib.Database.Model;

namespace Automat.Lib.Database;

public interface IRatingRepository
{
    public AutomatDbContext GetDbContext();
    public List<RatingCategory> GetRatingCategories();
    public List<Model.Model> GetRateableModels();

    public ModelRating? FindRatingByModelAndRatingCategory(Model.Model model,
        RatingCategory ratingCategory);
}