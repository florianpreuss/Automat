namespace Automat.Lib.Präferenzrechner;

public interface IPräferenzrechner
{
    public IDictionary<int, IDictionary<int, double>> GetBewertungsModelle();
    public void BewertungEinpflegen(int bewertungskategorie, double nutzerBewertung);
    public IDictionary<int, double> GetModelsSortedByPreferences();

}