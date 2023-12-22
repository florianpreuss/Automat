using Aut_O_Mat_Backend.Autovergleich;
using Aut_O_Mat_Backend.Database;
using Aut_O_Mat_Backend.Präferenzrechner;

namespace Aut_O_Mat_Backend;

public interface IAutomat
{
    public IFragenkatalog GetFragenkatalog();
    public IFavoritenauswahl GetFavoritenauswahl();
    public IErgebnisanzeige GetErgebnisanzeige();
    public IPräferenzrechner GetPräferenzrechner();
    public IAutoRepository GetAutoRepository();
    public IBewertungRepository GetBewertungRepository();
    public IFeedbackRepository GetFeedbackRepository();
}