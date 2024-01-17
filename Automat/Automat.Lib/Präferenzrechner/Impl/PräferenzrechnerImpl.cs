using Automat.Lib.Database.Model;

namespace Automat.Lib.Präferenzrechner.Impl;

public class PräferenzrechnerImpl: IPräferenzrechner
{

    public IDictionary<int, Dictionary<int, double>> GetBewertungsModelle()
    {
        throw new NotImplementedException();
    }

    public void BewertungEinpflegen(int bewertungsKategorie, double nutzerBewertung)
    {
        throw new NotImplementedException();
    }

    public IDictionary<int, double> GetModelsSortedByPreferences()
    {
        throw new NotImplementedException();
    }
}
