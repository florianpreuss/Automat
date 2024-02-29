using System.Collections.Specialized;
using Automat.Lib.Database.Model;

namespace Automat.Lib.Calculator;

public interface IPreferenceCalculator
{
    public IDictionary<Model, Dictionary<RatingCategory, decimal>> GetRatingModels();
    public IDictionary<Model, int> GetFavoriteMatches();

    public void AddRating(RatingCategory ratingCategory, decimal rating);
    public void AddFavorites(ICollection<Brand> brands, ICollection<BodyStyle> bodyStyles);
    
    public IDictionary<Model, decimal>  GetResultCarsSorted();

    public void ResetCalculator();
}