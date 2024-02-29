using Automat.Lib.Database;
using Automat.Lib.Database.Data;
using Automat.Lib.Calculator.Impl;

namespace Automat.Lib.Calculator;

public class PreferenceCalculatorFactory
{
    private IRatingRepository Repository;
    private IPreferenceCalculator PreferenceCalculator;
    
    public PreferenceCalculatorFactory(IRatingRepository ratingRepository)
    {
        Repository = ratingRepository;
        PreferenceCalculator = new PreferenceCalculatorImpl(Repository);
    }

    public IPreferenceCalculator GetPreferenceCalculator()
    {
        return PreferenceCalculator;
    }
}
