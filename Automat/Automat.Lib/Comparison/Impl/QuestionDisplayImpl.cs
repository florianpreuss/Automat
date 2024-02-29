using Automat.Lib.Autovergleich.Model;
using Automat.Lib.Database;
using Automat.Lib.Database.Model;
using Automat.Lib.Calculator;

namespace Automat.Lib.Comparison.Impl;

public class QuestionDisplayImpl : IQuestionDisplay
{

    private IPreferenceCalculator PreferenceCalculator;
    private IRatingRepository RatingRepository;
    private IDictionary<RatingCategory, QuestionState?> QuestionStates;
    

    public QuestionDisplayImpl(IPreferenceCalculator preferenceCalculator, IRatingRepository ratingRepository)
    {
        PreferenceCalculator = preferenceCalculator;
        RatingRepository = ratingRepository;
        QuestionStates = new Dictionary<RatingCategory, QuestionState?>();
    }
    
    public IPreferenceCalculator GetPreferenceCalculator()
    {
        return PreferenceCalculator;
    }

    public IRatingRepository GetRatingRepository()
    {
        return RatingRepository;
    }

    public IDictionary<RatingCategory, QuestionState?> GetQuestionStates()
    {
        return QuestionStates;
    }

    public QuestionState? GetQuestionState(RatingCategory ratingCategory)
    {
        return QuestionStates.TryGetValue(ratingCategory, out var value) ? value : null;
    }

    public void UpdateQuestionState(RatingCategory ratingCategory, QuestionState? questionState)
    {
        QuestionStates[ratingCategory] = questionState;
    }

    public void RemoveQuestionState(RatingCategory ratingCategory)
    {
        if (QuestionStates.ContainsKey(ratingCategory))
        {
            QuestionStates.Remove(ratingCategory);
        }
    }

    public void EmptyQuestionStates()
    { 
        QuestionStates.Clear();
    }

    public ICollection<RatingCategory> GetAllRatingCategories()
    {
        return RatingRepository.GetRatingCategories();
    }

    public void DataToPreferenceCalculator()
    {
        foreach (var entity in QuestionStates)
        {
            if (entity.Value != null && !entity.Value.Disabled)
            {
                PreferenceCalculator.AddRating(entity.Key, Convert.ToDecimal(entity.Value.Value)/10m);
            }

        }
    }
}