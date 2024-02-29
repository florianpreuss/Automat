using Automat.Lib.Comparison;
using Automat.Lib.Database;
using Automat.Lib.Calculator;

namespace Automat.Lib;

public class DefaultAutomat : IAutomat
{
    private IQuestionDisplay QuestionDisplay;
    private IFavoritesDisplay FavoritesDisplay;
    private IResultDisplay ResultDisplay;
    private IPreferenceCalculator PreferenceCalculator;
    private ICarRepository CarRepository;
    private IRatingRepository RatingRepository;
    private IFeedbackRepository FeedbackRepository;
    
    public DefaultAutomat(DatabaseFactory databaseFactory, PreferenceCalculatorFactory preferenceCalculatorFactory, ComparisonFactory comparisonFactory)
    {
        QuestionDisplay = comparisonFactory.GetQuestionDisplay();
        FavoritesDisplay = comparisonFactory.GetFavoritesDisplay();
        ResultDisplay = comparisonFactory.GetResultDisplay();
        PreferenceCalculator = preferenceCalculatorFactory.GetPreferenceCalculator();
        CarRepository = databaseFactory.GetCarRepository();
        RatingRepository = databaseFactory.GetRatingRepository();
        FeedbackRepository = databaseFactory.GetFeedbackRepository();
    }
    
    public IQuestionDisplay GetQuestionDisplay()
    {
        return QuestionDisplay;
    }

    public IFavoritesDisplay GetFavoritesDisplay()
    {
        return FavoritesDisplay;
    }

    public IResultDisplay GetResultDisplay()
    {
        return ResultDisplay;
    }

    public IPreferenceCalculator GetPreferenceCalculator()
    {
        return PreferenceCalculator;
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
}