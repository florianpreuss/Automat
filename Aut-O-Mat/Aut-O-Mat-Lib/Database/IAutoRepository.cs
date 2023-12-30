using Aut_O_Mat_Lib.Database.Data;

namespace Aut_O_Mat_Lib.Database;

public interface IAutoRepository
{
    public SqliteDbContext GetDbContext();
}