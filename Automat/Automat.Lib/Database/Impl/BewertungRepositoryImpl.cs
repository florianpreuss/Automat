using Automat.Lib.Database.Data;
using Automat.Lib.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Impl;

public class BewertungRepositoryImpl : IBewertungRepository
{
    private AutomatDbContext AutomatDbContext;
    public BewertungRepositoryImpl(AutomatDbContext automatDbContext)
    {
        this.AutomatDbContext = automatDbContext;
    }
    public AutomatDbContext GetDbContext()
    {
        return AutomatDbContext;
    }

    public List<Bewertungskategorie> GetBewertungskategorien()
    {
        return AutomatDbContext.Bewertungskategorien.ToList();
    }

    public List<Automodell> GetRateableModels()
    {
        return AutomatDbContext.Autobewertungen.Include(abw => abw.Automodell)
            .Select(abw => abw.Automodell).Distinct().ToList();
    }

    public Autobewertung? FindBewertungByModelAndBewertungskategorie(Automodell automodell, Bewertungskategorie bewertungskategorie)
    {
        return AutomatDbContext.Autobewertungen.Include(abw => abw.Automodell)
            .Include(abw => abw.Bewertungskategorie).FirstOrDefault(abw =>
                abw.Automodell == automodell && abw.Bewertungskategorie == bewertungskategorie);
    }
}