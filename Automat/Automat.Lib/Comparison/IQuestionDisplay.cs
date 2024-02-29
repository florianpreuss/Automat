using Automat.Lib.Autovergleich.Model;
using Automat.Lib.Calculator;
using Automat.Lib.Database;
using Automat.Lib.Database.Model;
using Automat.Lib.Calculator;

namespace Automat.Lib.Comparison;

public interface IQuestionDisplay
{
    public IPreferenceCalculator GetPreferenceCalculator();
    
    public IRatingRepository GetRatingRepository();
    
    public IDictionary<RatingCategory, QuestionState?> GetQuestionStates();
    
    public QuestionState? GetQuestionState(RatingCategory ratingCategory);
    
    public void UpdateQuestionState(RatingCategory ratingCategory, QuestionState? questionState);
    
    public void RemoveQuestionState(RatingCategory ratingCategory);
    
    public void EmptyQuestionStates();

    public ICollection<RatingCategory> GetAllRatingCategories();
    
    public void DataToPreferenceCalculator();
}