using Automat.Lib.Database;
using Automat.Lib.Database.Model;
using Automat.Lib.Calculator;

namespace Automat.Lib.Comparison;

public interface IResultDisplay
{
    public IPreferenceCalculator GetPreferenceCalculator();
    public IFeedbackRepository GetFeedbackRepository();

    public bool SendFeedback(Feedback feedback);
    public IDictionary<Model, int> GetResultCars(int amount);
}