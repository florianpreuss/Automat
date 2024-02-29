using Automat.Lib;
using Automat.Lib.Autovergleich;
using Automat.Lib.Calculator;
using Automat.Lib.Comparison;
using Automat.Lib.Database;

namespace Automat.UI.Services;

public class AutomatService
{
    private IAutomat Automat;
    
    public AutomatService()
    {
        Console.WriteLine("Created new Service");
        DatabaseFactory df = new DatabaseFactory("AutomatDbSqlite.db");
        PreferenceCalculatorFactory pf = new PreferenceCalculatorFactory(df.GetRatingRepository());
        ComparisonFactory af = new ComparisonFactory(df.GetCarRepository(), df.GetRatingRepository(),
            df.GetFeedbackRepository(), pf.GetPreferenceCalculator());
        Automat = new DefaultAutomat(df, pf, af);
    }

    public IAutomat getAutomat()
    {
        return Automat;
    }
}