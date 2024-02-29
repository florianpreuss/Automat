using Automat.Lib.Database;
using Automat.Lib.Database.Model;


namespace Automat.Lib.Calculator.Impl;

public class PreferenceCalculatorImpl: IPreferenceCalculator
{
    private IRatingRepository Repository;
    private IDictionary<Model,Dictionary<RatingCategory,decimal>> RatingModels;
    private IDictionary<Model, int> FavoriteMatches;
 
    
    public PreferenceCalculatorImpl(IRatingRepository ratingRepository)
    {
        Repository = ratingRepository;
        ResetCalculator();
    }

    public IDictionary<Model, Dictionary<RatingCategory, decimal>> GetRatingModels()
    {
        return RatingModels;
    }

    public IDictionary<Model, int> GetFavoriteMatches()
    {
        return FavoriteMatches;
    }

    public void AddRating(RatingCategory ratingCategory, decimal userRating)
    {
        foreach (var (key, value) in RatingModels)
        {
            if (value.ContainsKey(ratingCategory))
            {
                value.Remove(ratingCategory);
            }
            var Rating = Repository.FindRatingByModelAndRatingCategory(key, ratingCategory);
            if (Rating != null)
            {
                value.Add(ratingCategory, CalculateMatches(userRating, Rating.Rating));
            }
        }
    }

    public void ResetCalculator()
    {
        RatingModels = new Dictionary<Model, Dictionary<RatingCategory, decimal>>();
        FavoriteMatches = new Dictionary<Model, int>();
        
        foreach (var model in Repository.GetRateableModels())
        {
            RatingModels.Add(model, new Dictionary<RatingCategory, decimal>());
            FavoriteMatches.Add(model, 0);
        }
    }
    
    public void AddFavorites(ICollection<Brand> brands, ICollection<BodyStyle> bodyStyles)
    {
        foreach (var keyValuePair in FavoriteMatches)
        {
            if (brands.Contains(keyValuePair.Key.Brand))
            {
                FavoriteMatches[keyValuePair.Key] = keyValuePair.Value + 1;
            }
            if (bodyStyles.Contains(keyValuePair.Key.BodyStyle))
            {
                FavoriteMatches[keyValuePair.Key] = keyValuePair.Value + 1;
            }
        }
    }

    public decimal CalculateMatches(decimal bewertungUser, decimal bewertungDatenbank)
    {
        decimal difference = Math.Abs(Math.Abs(bewertungUser) - bewertungDatenbank);
        if (difference > 0.6m)
        {
            return 0;
        }
        return 1.0m - difference;
    }
    
    public IDictionary<Model, decimal> GetResultCarsSorted()
    {
        IDictionary<Model, decimal> matchRates = new Dictionary<Model, decimal>();
        foreach (var entity in RatingModels)
        {
            var rate = entity.Value.Values.Count > 0 ? entity.Value.Values.Average() : 0.5m; 
            matchRates.Add(entity.Key, 0.6m * rate + 0.4m * 0.5m * FavoriteMatches[entity.Key]);

        }
        var sorted = matchRates.OrderByDescending(entity => entity.Value);
        IDictionary<Model, decimal> matchRatesSorted = new Dictionary<Model, decimal>();
        foreach (var keyValuePair in sorted)
        {
            matchRatesSorted.Add(keyValuePair.Key, keyValuePair.Value);
        }
        return matchRatesSorted;
    }
}
