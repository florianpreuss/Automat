using Automat.Lib.Database.Data;
using Automat.Lib.Database.Model;

namespace Automat.Lib.Database;

public interface IBewertungRepository
{
    public AutomatDbContext GetDbContext();
    public List<Bewertungskategorie> GetBewertungskategorien();
    public List<Automodell> GetRateableModels();

    public Autobewertung? FindBewertungByModelAndBewertungskategorie(Automodell automodell,
        Bewertungskategorie bewertungskategorie);
}