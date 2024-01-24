using Automat.Lib.Database;
using Automat.Lib.Database.Model;
using Automat.Lib.Präferenzrechner;

namespace Automat.Lib.Autovergleich;

public interface IErgebnisanzeige
{
    public IPräferenzrechner GetPräferenzrechner();
    public IFeedbackRepository GetFeedbackRepository();

    public bool SendFeedback(Feedback feedback);
    public IDictionary<Automodell, int> GetErgebnisAutos(int anzahl);
}