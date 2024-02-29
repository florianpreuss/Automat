using Automat.Lib.Database.Data;
using Automat.Lib.Database.Model;

namespace Automat.Lib.Database;

public interface ICarRepository
{
    public AutomatDbContext GetDbContext();
    public Model.Model? FindById(int id);

    public ICollection<Brand> GetAllBrands();
    public ICollection<BodyStyle> GetAllBodyStyles();
}