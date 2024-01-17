using Automat.Lib.Database.Data;

namespace Automat.Lib.Database;

public interface IAutoRepository
{
    public SqliteDbContext GetDbContext();
}