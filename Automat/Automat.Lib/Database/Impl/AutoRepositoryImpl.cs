using Automat.Lib.Database.Data;
using Automat.Lib.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Impl;

public class AutoRepositoryImpl : IAutoRepository
{
    private AutomatDbContext AutomatDbContext;
    public AutoRepositoryImpl(AutomatDbContext automatDbContext)
    {
        AutomatDbContext = automatDbContext;
    }
    public AutomatDbContext GetDbContext()
    {
        return AutomatDbContext;
    }

    public Automodell? FindById(int id)
    {
        return AutomatDbContext.Automodelle.Include(automodell => automodell.Automarke)
            .Include(automodell => automodell.Karosserieform).First(automodell => automodell.AutomodellId == id);
    }

    public ICollection<Automarke> GetAllAutomarken()
    {
        return AutomatDbContext.Automarken.ToList();
    }

    public ICollection<Karosserieform> GetAllKarosserieformen()
    {
        return AutomatDbContext.Karosserieformen.ToList();
    }
}