using System.Collections.Specialized;
using Automat.Lib.Database.Model;

namespace Automat.Lib.Präferenzrechner;

public interface IPräferenzrechner
{
    public IDictionary<Automodell, Dictionary<Bewertungskategorie, decimal>> GetBewertungsModelle();
    public IDictionary<Automodell, int> GetFavoritenÜbereinstimmungen();

    public void BewertungHinzufügen(Bewertungskategorie bewertungskategorie, decimal nutzerBewertung);
    public void FavoritenHinzufügen(ICollection<Automarke> automarken, ICollection<Karosserieform> karosserieformen);
    
    public IDictionary<Automodell, decimal>  GetErgebnisAutosSorted();

    public void ResetRechner();
}