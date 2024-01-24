using Automat.Lib.Database.Data;
using Automat.Lib.Database.Model;

namespace Automat.Lib.Database.Impl;

public class FeedbackRepositoryImpl : IFeedbackRepository
{

    public AutomatDbContext AutomatDbContext;

    public FeedbackRepositoryImpl(AutomatDbContext automatDbContext)
    {
        AutomatDbContext = automatDbContext;
    }

    public bool AddFeedback(Feedback feedback)
    {
        AutomatDbContext.Feedbacks.Add(feedback);
        AutomatDbContext.SaveChanges();
        return AutomatDbContext.Feedbacks.Find(feedback.FeedbackId) != null;
    }

    public AutomatDbContext GetDbContext()
    {
        return AutomatDbContext;
    }
}