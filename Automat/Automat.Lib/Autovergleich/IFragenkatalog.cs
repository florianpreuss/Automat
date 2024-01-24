using Automat.Lib.Autovergleich.Model;
using Automat.Lib.Database;
using Automat.Lib.Database.Model;
using Automat.Lib.Präferenzrechner;

namespace Automat.Lib.Autovergleich;

public interface IFragenkatalog
{
    public IPräferenzrechner GetPräferenzrechner();
    
    public IBewertungRepository GetBewertungRepository();
    
    public IDictionary<Bewertungskategorie, FragestellungState?> GetFragestellungStates();
    
    public FragestellungState? GetFragestellungState(Bewertungskategorie bewertungskategorie);
    
    public void UpdateFragestellungState(Bewertungskategorie bewertungskategorie, FragestellungState? fragestellungState);
    
    public void RemoveFragestellungState(Bewertungskategorie bewertungskategorie);
    
    public void EmptyFragestellungStates();

    public ICollection<Bewertungskategorie> GetAlleBewertungskategorien();
    
    public void DatenAnPräferenzrechner();
}