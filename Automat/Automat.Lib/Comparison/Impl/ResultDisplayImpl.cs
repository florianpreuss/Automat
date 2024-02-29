using System.Collections.Specialized;
using Automat.Lib.Database;
using Automat.Lib.Database.Model;
using Automat.Lib.Calculator;

namespace Automat.Lib.Comparison.Impl;

public class ResultDisplayImpl : IResultDisplay
{

    private IPreferenceCalculator PreferenceCalculator;
    private IFeedbackRepository FeedbackRepository;
    public ResultDisplayImpl(IPreferenceCalculator preferenceCalculator, IFeedbackRepository feedbackRepository)
    {
        PreferenceCalculator = preferenceCalculator;
        FeedbackRepository = feedbackRepository;
    }
    public IPreferenceCalculator GetPreferenceCalculator()
    {
        return PreferenceCalculator;
    }

    public IFeedbackRepository GetFeedbackRepository()
    {
        return FeedbackRepository;
    }

    public bool SendFeedback(Feedback feedback)
    {
        return FeedbackRepository.AddFeedback(feedback);
    }

    public IDictionary<Database.Model.Model, int> GetResultCars(int anzahl)
    {
        IDictionary<Database.Model.Model, decimal> AlleErgebnisse = PreferenceCalculator.GetResultCarsSorted();
        IDictionary<Database.Model.Model, int> ErgebnisseCounted = new Dictionary<Database.Model.Model, int>(); 
        int counter = 0;
        foreach (var entity in AlleErgebnisse)
        {
            if (counter < anzahl)
            {
                ErgebnisseCounted.Add(entity.Key, Convert.ToInt32(entity.Value*100));
            }
            else
            {
                break;
            }

            counter++;
        }
        return ErgebnisseCounted;
    }
}