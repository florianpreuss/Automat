using Automat.Lib.Database;
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
        throw new NotImplementedException();
    }
    
    public IFavoritenauswahl GetFavoritenauswahl()
    {
        throw new NotImplementedException();
    }

    public IErgebnisanzeige GetErgebnisanzeige()
    {
        throw new NotImplementedException();
    }
}