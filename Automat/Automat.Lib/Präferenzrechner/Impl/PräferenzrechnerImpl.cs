using Automat.Lib.Database.Data;


namespace Automat.Lib.Präferenzrechner.Impl;

public class PräferenzrechnerImpl: IPräferenzrechner
{
    private AutomatDbContext AutomatDbContext;
    private IDictionary<int,Dictionary<int,double>> BewertungsAutomodell;
 
    
    public PräferenzrechnerImpl(AutomatDbContext dbContext)
    {
        AutomatDbContext = dbContext;
        
        foreach (var automodell in dbContext.Automodelle)
        {
            BewertungsAutomodell.Add(automodell.AutomodellId,null);
        }
        
    }

    public IDictionary<int, Dictionary<int, double>> GetBewertungsModelle()
    {
        
        throw new NotImplementedException();
    }

    public void BewertungEinpflegen(int bewertungsKategorie, double nutzerBewertung)
    {
        throw new NotImplementedException();
    }

    public IDictionary<int, Dictionary<int, double>> GetModelsSortedByPreferences()
    {
        // Dictionary nach den berechneten Bewertungen(double Werten) der inneren Dictionaries sortieren
        var sortierteListe = BewertungsAutomodell.ToList();
        sortierteListe.Sort((pair1, pair2) => pair1.Value.Values.Sum().CompareTo(pair2.Value.Values.Sum()));

        // Ein neues Dictionary erstellen, basierend auf der sortierten Liste
        IDictionary<int, Dictionary<int, double>> sortiertesDictionary = sortierteListe.ToDictionary(pair => pair.Key, pair => pair.Value);

        return sortiertesDictionary;
    }
}
