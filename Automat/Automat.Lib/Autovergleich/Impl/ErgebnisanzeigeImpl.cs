using System.Collections.Specialized;
using Automat.Lib.Database;
using Automat.Lib.Database.Model;
using Automat.Lib.Präferenzrechner;

namespace Automat.Lib.Autovergleich.Impl;

public class ErgebnisanzeigeImpl : IErgebnisanzeige
{

    private IPräferenzrechner Präferenzrechner;
    private IFeedbackRepository FeedbackRepository;
    public ErgebnisanzeigeImpl(IPräferenzrechner präferenzrechner, IFeedbackRepository feedbackRepository)
    {
        Präferenzrechner = präferenzrechner;
        FeedbackRepository = feedbackRepository;
    }
    public IPräferenzrechner GetPräferenzrechner()
    {
        return Präferenzrechner;
    }

    public IFeedbackRepository GetFeedbackRepository()
    {
        return FeedbackRepository;
    }

    public bool SendFeedback(Feedback feedback)
    {
        return FeedbackRepository.AddFeedback(feedback);
    }

    public IDictionary<Automodell, int> GetErgebnisAutos(int anzahl)
    {
        IDictionary<Automodell, decimal> AlleErgebnisse = Präferenzrechner.GetErgebnisAutosSorted();
        IDictionary<Automodell, int> ErgebnisseCounted = new Dictionary<Automodell, int>(); 
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