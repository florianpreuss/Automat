using Automat.Lib.Database;
using Automat.Lib.Database.Model;


namespace Automat.Lib.Präferenzrechner.Impl;

public class PräferenzrechnerImpl: IPräferenzrechner
{
    private IBewertungRepository Repository;
    private IDictionary<Automodell,Dictionary<Bewertungskategorie,decimal>> BewertungsAutomodelle;
    private IDictionary<Automodell, int> FavoritenÜbereinstimmungen;
 
    
    public PräferenzrechnerImpl(IBewertungRepository bewertungsRepository)
    {
        Repository = bewertungsRepository;
        ResetRechner();
    }

    public IDictionary<Automodell, Dictionary<Bewertungskategorie, decimal>> GetBewertungsModelle()
    {
        return BewertungsAutomodelle;
    }

    public IDictionary<Automodell, int> GetFavoritenÜbereinstimmungen()
    {
        return FavoritenÜbereinstimmungen;
    }

    public void BewertungHinzufügen(Bewertungskategorie bewertungskategorie, decimal nutzerBewertung)
    {
        foreach (var (key, value) in BewertungsAutomodelle)
        {
            if (value.ContainsKey(bewertungskategorie))
            {
                value.Remove(bewertungskategorie);
            }
            var Bewertung = Repository.FindBewertungByModelAndBewertungskategorie(key, bewertungskategorie);
            if (Bewertung != null)
            {
                value.Add(bewertungskategorie, UebereinstimmungBerechnen(nutzerBewertung, Bewertung.Bewertung));
            }
        }
    }

    public void ResetRechner()
    {
        BewertungsAutomodelle = new Dictionary<Automodell, Dictionary<Bewertungskategorie, decimal>>();
        FavoritenÜbereinstimmungen = new Dictionary<Automodell, int>();
        
        foreach (var automodell in Repository.GetRateableModels())
        {
            BewertungsAutomodelle.Add(automodell, new Dictionary<Bewertungskategorie, decimal>());
            FavoritenÜbereinstimmungen.Add(automodell, 0);
        }
    }
    
    public void FavoritenHinzufügen(ICollection<Automarke> automarken, ICollection<Karosserieform> karosserieformen)
    {
        foreach (var keyValuePair in FavoritenÜbereinstimmungen)
        {
            if (automarken.Contains(keyValuePair.Key.Automarke))
            {
                FavoritenÜbereinstimmungen[keyValuePair.Key] = keyValuePair.Value + 1;
            }
            if (karosserieformen.Contains(keyValuePair.Key.Karosserieform))
            {
                FavoritenÜbereinstimmungen[keyValuePair.Key] = keyValuePair.Value + 1;
            }
        }
    }

    public decimal UebereinstimmungBerechnen(decimal bewertungUser, decimal bewertungDatenbank)
    {
        decimal abweichung = Math.Abs(Math.Abs(bewertungUser) - bewertungDatenbank);
        if (abweichung > 0.6m)
        {
            return 0;
        }
        return 1.0m - abweichung;
    }
    
    public IDictionary<Automodell, decimal> GetErgebnisAutosSorted()
    {
        IDictionary<Automodell, decimal> Uebereinstimmungsraten = new Dictionary<Automodell, decimal>();
        foreach (var entity in BewertungsAutomodelle)
        {
            var rate = entity.Value.Values.Count > 0 ? entity.Value.Values.Average() : 0.5m; 
            Uebereinstimmungsraten.Add(entity.Key, 0.6m * rate + 0.4m * 0.5m * FavoritenÜbereinstimmungen[entity.Key]);

        }
        var sorted = Uebereinstimmungsraten.OrderByDescending(entity => entity.Value);
        IDictionary<Automodell, decimal> UebereinstimmungsratenSortiert = new Dictionary<Automodell, decimal>();
        foreach (var keyValuePair in sorted)
        {
            UebereinstimmungsratenSortiert.Add(keyValuePair.Key, keyValuePair.Value);
        }
        return UebereinstimmungsratenSortiert;
    }
}
