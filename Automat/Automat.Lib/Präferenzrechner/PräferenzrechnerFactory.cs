using Automat.Lib.Database;
using Automat.Lib.Database.Data;
using Automat.Lib.Präferenzrechner.Impl;

namespace Automat.Lib.Präferenzrechner;

public class PräferenzrechnerFactory
{
    private IBewertungRepository Repository;
    private IPräferenzrechner Präferenzrechner;
    
    public PräferenzrechnerFactory(IBewertungRepository bewertungRepository)
    {
        Repository = bewertungRepository;
        Präferenzrechner = new PräferenzrechnerImpl(Repository);
    }

    public IPräferenzrechner GetPräferenzrechner()
    {
        return Präferenzrechner;
    }
}
