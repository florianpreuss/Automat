using Automat.Lib;
using Automat.Lib.Autovergleich;
using Automat.Lib.Database;
using Automat.Lib.Präferenzrechner;

namespace Automat.UI.Services;

public class AutomatService
{
    private IAutomat Automat;
    
    public AutomatService()
    {
        Console.WriteLine("Neuer Service erstellt");
        DatabaseFactory df = new DatabaseFactory("AutomatDbSqlite.db");
        PräferenzrechnerFactory pf = new PräferenzrechnerFactory(df.GetBewertungRepository());
        AutovergleichFactory af = new AutovergleichFactory(df.GetAutoRepository(), df.GetBewertungRepository(),
            df.GetFeedbackRepository(), pf.GetPräferenzrechner());
        Automat = new DefaultAutomat(df, pf, af);
    }

    public IAutomat getAutomat()
    {
        return Automat;
    }
}