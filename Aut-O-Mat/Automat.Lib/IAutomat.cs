using Automat.Lib.Autovergleich;
using Automat.Lib.Database;
using Automat.Lib.Präferenzrechner;

namespace Automat.Lib;

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