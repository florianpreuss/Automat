using Aut_O_Mat_Lib.Database.Data;
using Aut_O_Mat_Lib.Database.Model;

namespace Aut_O_Mat_Lib.Database;

public interface IFeedbackRepository
{
    public void AddFeedback(Feedback feedback);
    public SqliteDbContext GetDbContext();
}