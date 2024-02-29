using Automat.Lib.Database.Data;
using Automat.Lib.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Automat.Lib.Database.Impl;

public class CarRepositoryImpl : ICarRepository
{
    private AutomatDbContext AutomatDbContext;
    public CarRepositoryImpl(AutomatDbContext automatDbContext)
    {
        AutomatDbContext = automatDbContext;
    }
    public AutomatDbContext GetDbContext()
    {
        return AutomatDbContext;
    }

    public Model.Model? FindById(int id)
    {
        return AutomatDbContext.Models.Include(model => model.Brand)
            .Include(model => model.BodyStyle).First(model => model.ModelId == id);
    }

    public ICollection<Brand> GetAllBrands()
    {
        return AutomatDbContext.Brands.ToList();
    }

    public ICollection<BodyStyle> GetAllBodyStyles()
    {
        return AutomatDbContext.BodyStyles.ToList();
    }
}