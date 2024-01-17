using Automat.Lib.Database.Data;
using Automat.Lib.Database.Model;

namespace Automat.Lib.Database;

public interface IFeedbackRepository
{
    public void AddFeedback(Feedback feedback);
    public AutomatDbContext GetDbContext();
}