using Automat.Lib.Comparison;
using Automat.Lib.Database;
using Automat.Lib.Calculator;

namespace Automat.Lib;

public interface IAutomat
{
    public IQuestionDisplay GetQuestionDisplay();
    public IFavoritesDisplay GetFavoritesDisplay();
    public IResultDisplay GetResultDisplay();
    public IPreferenceCalculator GetPreferenceCalculator();
    public ICarRepository GetCarRepository();
    public IRatingRepository GetRatingRepository();
    public IFeedbackRepository GetFeedbackRepository();
}