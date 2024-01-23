using Automat.Lib;
using Automat.Lib.Autovergleich;
using Automat.Lib.Database;
using Automat.Lib.Database.Model;
using Automat.Lib.Präferenzrechner;

namespace Automat.UI.Services;

public class AutomatService
{
    private IAutomat Automat;
    
    public AutomatService()
    {
        DatabaseFactory df = new DatabaseFactory();
        PräferenzrechnerFactory pf = new PräferenzrechnerFactory();
        AutovergleichFactory af = new AutovergleichFactory(df.GetAutoRepository(), df.GetBewertungRepository(),
            df.GetFeedbackRepository(), pf.GetPräferenzrechner());
        Automat = new DefaultAutomat(df, pf, af);
    }

    public List<Bewertungskategorie> GetBewertungskategorien()
    {
        return Automat.GetBewertungRepository().GetBewertungskategorien();
    }

}