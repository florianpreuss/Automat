using Automat.Lib.Database;
using Automat.Lib.Database.Model;
using Automat.Lib.Präferenzrechner;

namespace Automat.Lib.Autovergleich;

public interface IFavoritenauswahl
{
    public IPräferenzrechner GetPräferenzrechner();
    public IAutoRepository GetAutoRepository();

    public ICollection<Automarke> GetBenutzerMarken();
    public ICollection<Karosserieform> GetBenutzerKarosserieformen();

    public void AddBenutzerMarke(Automarke automarke);
    public void AddBenutzerKarosserieform(Karosserieform karosserieform);
    public void RemoveBenutzerMarke(Automarke automarke);
    public void RemoveBenutzerKarosserieform(Karosserieform karosserieform);

    public void EmptyBenutzerMarken();
    public void EmptyBenutzerKarosserieformen();
    public ICollection<Automarke> GetAllAutomarken();
    public ICollection<Karosserieform> GetAllKarosserieformen();

    public void DatenAnPräferenzrechner();
}