using Automat.Lib.Autovergleich.Impl;
using Automat.Lib.Database;
using Automat.Lib.Database.Impl;
using Automat.Lib.Präferenzrechner;

namespace Automat.Lib.Autovergleich;

public class AutovergleichFactory
{
    private IAutoRepository AutoRepository;
    private IBewertungRepository BewertungRepository;
    private IFeedbackRepository FeedbackRepository;
    private IPräferenzrechner Präferenzrechner;
    
    public AutovergleichFactory(IAutoRepository autoRepository, IBewertungRepository bewertungRepository, IFeedbackRepository feedbackRepository, IPräferenzrechner präferenzrechner)
    {
        this.AutoRepository = autoRepository;
        this.BewertungRepository = bewertungRepository;
        this.FeedbackRepository = feedbackRepository;
        this.Präferenzrechner = präferenzrechner;
    }

    public IFragenkatalog GetFragenkatalog()
    {
        return new FragenkatalogImpl(Präferenzrechner, BewertungRepository);
    }
    
    public IFavoritenauswahl GetFavoritenauswahl()
    {
        return new FavoritenauswahlImpl(Präferenzrechner, AutoRepository);
    }

    public IErgebnisanzeige GetErgebnisanzeige()
    {
        return new ErgebnisanzeigeImpl(Präferenzrechner, FeedbackRepository);
    }
}