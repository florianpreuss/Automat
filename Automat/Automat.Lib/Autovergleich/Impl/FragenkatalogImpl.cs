using Automat.Lib.Autovergleich.Model;
using Automat.Lib.Database;
using Automat.Lib.Database.Model;
using Automat.Lib.Präferenzrechner;

namespace Automat.Lib.Autovergleich.Impl;

public class FragenkatalogImpl : IFragenkatalog
{

    private IPräferenzrechner Präferenzrechner;
    private IBewertungRepository BewertungRepository;
    private IDictionary<Bewertungskategorie, FragestellungState?> FragestellungStates;
    

    public FragenkatalogImpl(IPräferenzrechner präferenzrechner, IBewertungRepository bewertungRepository)
    {
        Präferenzrechner = präferenzrechner;
        BewertungRepository = bewertungRepository;
        FragestellungStates = new Dictionary<Bewertungskategorie, FragestellungState?>();
    }
    
    public IPräferenzrechner GetPräferenzrechner()
    {
        return Präferenzrechner;
    }

    public IBewertungRepository GetBewertungRepository()
    {
        return BewertungRepository;
    }

    public IDictionary<Bewertungskategorie, FragestellungState?> GetFragestellungStates()
    {
        return FragestellungStates;
    }

    public FragestellungState? GetFragestellungState(Bewertungskategorie bewertungskategorie)
    {
        return FragestellungStates.TryGetValue(bewertungskategorie, out var value) ? value : null;
    }

    public void UpdateFragestellungState(Bewertungskategorie bewertungskategorie, FragestellungState? fragestellungState)
    {
        FragestellungStates[bewertungskategorie] = fragestellungState;
    }

    public void RemoveFragestellungState(Bewertungskategorie bewertungskategorie)
    {
        if (FragestellungStates.ContainsKey(bewertungskategorie))
        {
            FragestellungStates.Remove(bewertungskategorie);
        }
    }

    public void EmptyFragestellungStates()
    { 
        FragestellungStates.Clear();
    }

    public ICollection<Bewertungskategorie> GetAlleBewertungskategorien()
    {
        return BewertungRepository.GetBewertungskategorien();
    }

    public void DatenAnPräferenzrechner()
    {
        foreach (var entity in FragestellungStates)
        {
            if (entity.Value != null && !entity.Value.Disabled)
            {
                Präferenzrechner.BewertungHinzufügen(entity.Key, Convert.ToDecimal(entity.Value.Value)/10m);
            }

        }
    }
}