using Automat.Lib.Database.Data;

namespace Automat.Lib.Database;

public interface IBewertungRepository
{
    public AutomatDbContext GetDbContext();
}