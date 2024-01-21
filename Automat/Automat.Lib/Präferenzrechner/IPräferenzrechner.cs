namespace Automat.Lib.Präferenzrechner;

public interface IPräferenzrechner
{
    public IDictionary<int, Dictionary<int, Double>> GetBewertungsModelle();

    public void BewertungEinpflegen(int bewertungsKategorie, double nutzerBewertung);
    
    public IDictionary<int, Dictionary<int, double>> GetModelsSortedByPreferences();
        
}