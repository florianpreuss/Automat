using Automat.Lib.Database;
using Automat.Lib.Database.Model;
using Automat.Lib.Calculator;

namespace Automat.Lib.Comparison.Impl;

public class FavoritesDisplayImpl : IFavoritesDisplay
{

    private IPreferenceCalculator PreferenceCalculator;
    private ICarRepository CarRepository;
    private ICollection<Brand> BenutzerMarken;
    private ICollection<BodyStyle> BenutzerKarosserieformen;

    public FavoritesDisplayImpl(IPreferenceCalculator preferenceCalculator, ICarRepository carRepository)
    {
        PreferenceCalculator = preferenceCalculator;
        CarRepository = carRepository;
        BenutzerMarken = new List<Brand>();
        BenutzerKarosserieformen = new List<BodyStyle>();
    }
    public IPreferenceCalculator GetPreferenceCalculator()
    {
        return PreferenceCalculator;
    }

    public ICarRepository GetCarRepository()
    {
        return CarRepository;
    }

    public ICollection<Brand> GetUserBrands()
    {
        return BenutzerMarken;
    }

    public ICollection<BodyStyle> GetUserBodyStyles()
    {
        return BenutzerKarosserieformen;
    }

    public void AddUserBrand(Brand brand)
    {
        if (!BenutzerMarken.Contains(brand))
        {
            BenutzerMarken.Add(brand);
        }
    }

    public void AddUserBodyStyle(BodyStyle bodyStyle)
    {
        if (!BenutzerKarosserieformen.Contains(bodyStyle))
        {
            BenutzerKarosserieformen.Add(bodyStyle);
        }
    }

    public void RemoveUserBrand(Brand brand)
    {
        if (BenutzerMarken.Contains(brand))
        {
            BenutzerMarken.Remove(brand);
        }
    }

    public void RemoveUserBodyStyle(BodyStyle bodyStyle)
    {
        if (BenutzerKarosserieformen.Contains(bodyStyle))
        {
            BenutzerKarosserieformen.Remove(bodyStyle);
        }
    }

    public void EmptyUserBrands()
    {
        BenutzerMarken.Clear();
    }
    

    public void EmptyUserBodyStyles()
    {
        BenutzerKarosserieformen.Clear();
    }

    public ICollection<Brand> GetAllBrands()
    {
        return CarRepository.GetAllBrands();
    }

    public ICollection<BodyStyle> GetAllBodyStyles()
    {
        return CarRepository.GetAllBodyStyles();
    }

    public void DataToPreferenceCalculator()
    {
        PreferenceCalculator.AddFavorites(BenutzerMarken, BenutzerKarosserieformen);
    }
}