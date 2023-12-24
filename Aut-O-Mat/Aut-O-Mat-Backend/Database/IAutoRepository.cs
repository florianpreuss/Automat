using Aut_O_Mat_Backend.Database.Impl;

namespace Aut_O_Mat_Backend.Database;

public interface IAutoRepository
{
    public AutomatDbContext GetDbContext();
}