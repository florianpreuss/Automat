using Automat.Lib.Comparison.Impl;
using Automat.Lib.Database;
using Automat.Lib.Database.Impl;
using Automat.Lib.Calculator;

namespace Automat.Lib.Comparison;

public class ComparisonFactory
{
    private ICarRepository CarRepository;
    private IRatingRepository RatingRepository;
    private IFeedbackRepository FeedbackRepository;
    private IPreferenceCalculator PreferenceCalculator;
    
    public ComparisonFactory(ICarRepository carRepository, IRatingRepository ratingRepository, IFeedbackRepository feedbackRepository, IPreferenceCalculator preferenceCalculator)
    {
        this.CarRepository = carRepository;
        this.RatingRepository = ratingRepository;
        this.FeedbackRepository = feedbackRepository;
        this.PreferenceCalculator = preferenceCalculator;
    }

    public IQuestionDisplay GetQuestionDisplay()
    {
        return new QuestionDisplayImpl(PreferenceCalculator, RatingRepository);
    }
    
    public IFavoritesDisplay GetFavoritesDisplay()
    {
        return new FavoritesDisplayImpl(PreferenceCalculator, CarRepository);
    }

    public IResultDisplay GetResultDisplay()
    {
        return new ResultDisplayImpl(PreferenceCalculator, FeedbackRepository);
    }
}