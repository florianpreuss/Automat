using Aut_O_Mat_Lib.Autovergleich;
using Aut_O_Mat_Lib.Database;
using Aut_O_Mat_Lib.Präferenzrechner;

namespace Aut_O_Mat_Lib;

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