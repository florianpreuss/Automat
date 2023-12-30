using Aut_O_Mat_Lib.Autovergleich;
using Aut_O_Mat_Lib.Database;
using Aut_O_Mat_Lib.Präferenzrechner;

namespace Aut_O_Mat_Lib;

public class DefaultAutomat : IAutomat
{
    private IFragenkatalog Fragenkatalog;
    private IFavoritenauswahl Favoritenauswahl;
    private IErgebnisanzeige Ergebnisanzeige;
    private IPräferenzrechner Präferenzrechner;
    private IAutoRepository AutoRepository;
    private IBewertungRepository BewertungRepository;
    private IFeedbackRepository FeedbackRepository;
    
    public DefaultAutomat(DatabaseFactory databaseFactory, PräferenzrechnerFactory präferenzrechnerFactory, AutovergleichFactory autovergleichFactory)
    {
        Fragenkatalog = autovergleichFactory.GetFragenkatalog();
        Favoritenauswahl = autovergleichFactory.GetFavoritenauswahl();
        Ergebnisanzeige = autovergleichFactory.GetErgebnisanzeige();
        Präferenzrechner = präferenzrechnerFactory.GetPräferenzrechner();
        AutoRepository = databaseFactory.GetAutoRepository();
        BewertungRepository = databaseFactory.GetBewertungRepository();
        FeedbackRepository = databaseFactory.GetFeedbackRepository();
    }
    
    public IFragenkatalog GetFragenkatalog()
    {
        return Fragenkatalog;
    }

    public IFavoritenauswahl GetFavoritenauswahl()
    {
        return Favoritenauswahl;
    }

    public IErgebnisanzeige GetErgebnisanzeige()
    {
        return Ergebnisanzeige;
    }

    public IPräferenzrechner GetPräferenzrechner()
    {
        return Präferenzrechner;
    }

    public IAutoRepository GetAutoRepository()
    {
        return AutoRepository;
    }

    public IBewertungRepository GetBewertungRepository()
    {
        return BewertungRepository;
    }

    public IFeedbackRepository GetFeedbackRepository()
    {
        return FeedbackRepository;
    }
}