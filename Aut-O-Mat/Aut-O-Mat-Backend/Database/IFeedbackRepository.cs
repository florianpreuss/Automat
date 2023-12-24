using Aut_O_Mat_Backend.Database.Impl;
using Aut_O_Mat_Backend.Database.Model;

namespace Aut_O_Mat_Backend.Database;

public interface IFeedbackRepository
{
    public void AddFeedback(Feedback feedback);
    public AutomatDbContext GetDbContext();
}