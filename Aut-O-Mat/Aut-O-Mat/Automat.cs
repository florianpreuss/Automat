namespace Aut_O_Mat;

using GUI;
using Präferenzrechner;
using Autovergleich;
using Database;

public class Automat
{
    private IGUI gui;
    private IPräferenzrechner präferenzrechner;
    private IErgebnisausgabe ergebnisausgabe;
    private IFavoritenauswahl favoritenauswahl;
    private IFragenkatalog fragenkatalog;
    private IAutomarke automarke;
    private IKarosserieform karosserieform;
    private IAutomodell automodell;
    private IBewertungskategorie bewertungskategorie;
    private IAutobewertung autobewertung;
    private IFeedback feedback;
         
    public Automat(IGUI gui, IPräferenzrechner präferenzrechner, 
        IErgebnisausgabe ergebnisausgabe, IFavoritenauswahl favoritenauswahl, IFragenkatalog fragenkatalog, 
        IAutomarke automarke, IKarosserieform karosserieform, IAutomodell automodell, 
        IBewertungskategorie bewertungskategorie, IAutobewertung autobewertung, IFeedback feedback)
    {
        this.gui = gui;
        this.präferenzrechner = präferenzrechner;
        this.ergebnisausgabe = ergebnisausgabe;
        this.favoritenauswahl = favoritenauswahl;
        this.fragenkatalog = fragenkatalog;
        this.automarke = automarke;
        this.karosserieform = karosserieform;
        this.automodell = automodell;
        this.bewertungskategorie = bewertungskategorie;
        this.autobewertung = autobewertung;
        this.feedback = feedback;
    }
}