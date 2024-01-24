using Automat.Lib.Database;
using Automat.Lib.Database.Model;
using Automat.Lib.Präferenzrechner;

namespace Automat.Lib.Autovergleich.Impl;

public class FavoritenauswahlImpl : IFavoritenauswahl
{

    private IPräferenzrechner Präferenzrechner;
    private IAutoRepository AutoRepository;
    private ICollection<Automarke> BenutzerMarken;
    private ICollection<Karosserieform> BenutzerKarosserieformen;

    public FavoritenauswahlImpl(IPräferenzrechner präferenzrechner, IAutoRepository autoRepository)
    {
        Präferenzrechner = präferenzrechner;
        AutoRepository = autoRepository;
        BenutzerMarken = new List<Automarke>();
        BenutzerKarosserieformen = new List<Karosserieform>();
    }
    public IPräferenzrechner GetPräferenzrechner()
    {
        return Präferenzrechner;
    }

    public IAutoRepository GetAutoRepository()
    {
        return AutoRepository;
    }

    public ICollection<Automarke> GetBenutzerMarken()
    {
        return BenutzerMarken;
    }

    public ICollection<Karosserieform> GetBenutzerKarosserieformen()
    {
        return BenutzerKarosserieformen;
    }

    public void AddBenutzerMarke(Automarke automarke)
    {
        if (!BenutzerMarken.Contains(automarke))
        {
            BenutzerMarken.Add(automarke);
        }
    }

    public void AddBenutzerKarosserieform(Karosserieform karosserieform)
    {
        if (!BenutzerKarosserieformen.Contains(karosserieform))
        {
            BenutzerKarosserieformen.Add(karosserieform);
        }
    }

    public void RemoveBenutzerMarke(Automarke automarke)
    {
        if (BenutzerMarken.Contains(automarke))
        {
            BenutzerMarken.Remove(automarke);
        }
    }

    public void RemoveBenutzerKarosserieform(Karosserieform karosserieform)
    {
        if (BenutzerKarosserieformen.Contains(karosserieform))
        {
            BenutzerKarosserieformen.Remove(karosserieform);
        }
    }

    public void EmptyBenutzerMarken()
    {
        BenutzerMarken.Clear();
    }
    

    public void EmptyBenutzerKarosserieformen()
    {
        BenutzerKarosserieformen.Clear();
    }

    public ICollection<Automarke> GetAllAutomarken()
    {
        return AutoRepository.GetAllAutomarken();
    }

    public ICollection<Karosserieform> GetAllKarosserieformen()
    {
        return AutoRepository.GetAllKarosserieformen();
    }

    public void DatenAnPräferenzrechner()
    {
        Präferenzrechner.FavoritenHinzufügen(BenutzerMarken, BenutzerKarosserieformen);
    }
}