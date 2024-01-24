using Automat.Lib.Database.Data;
using Automat.Lib.Database.Model;

namespace Automat.Lib.Database;

public interface IAutoRepository
{
    public AutomatDbContext GetDbContext();
    public Automodell? FindById(int id);

    public ICollection<Automarke> GetAllAutomarken();
    public ICollection<Karosserieform> GetAllKarosserieformen();
}