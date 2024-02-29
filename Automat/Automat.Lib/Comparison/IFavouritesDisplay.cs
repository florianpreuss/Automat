using Automat.Lib.Database;
using Automat.Lib.Database.Model;
using Automat.Lib.Calculator;

namespace Automat.Lib.Comparison;

public interface IFavoritesDisplay
{
    public IPreferenceCalculator GetPreferenceCalculator();
    public ICarRepository GetCarRepository();

    public ICollection<Brand> GetUserBrands();
    public ICollection<BodyStyle> GetUserBodyStyles();

    public void AddUserBrand(Brand brand);
    public void AddUserBodyStyle(BodyStyle bodyStyle);
    public void RemoveUserBrand(Brand brand);
    public void RemoveUserBodyStyle(BodyStyle bodyStyle);

    public void EmptyUserBrands();
    public void EmptyUserBodyStyles();
    public ICollection<Brand> GetAllBrands();
    public ICollection<BodyStyle> GetAllBodyStyles();

    public void DataToPreferenceCalculator();
}