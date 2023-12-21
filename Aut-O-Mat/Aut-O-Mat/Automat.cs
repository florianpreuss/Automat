namespace Aut_O_Mat;

using GUI;
using Präferenzrechner;
using Autovergleich;
using Database;

public class Automat
{
    private IGui gui;
    private IPräferenzrechner präferenzrechner;
    private IErgebnisausgabe ergebnisausgabe;
    private IFavoritenauswahl favoritenauswahl;
    private IFragenkatalog fragenkatalog;
    private IAutoRepository autoRepository;
    private IBewertungRepository bewertungRepository;
    private IFeedbackRepository feedbackRepository;
         
    public Automat(IGui gui, IPräferenzrechner präferenzrechner, 
        IErgebnisausgabe ergebnisausgabe, IFavoritenauswahl favoritenauswahl, IFragenkatalog fragenkatalog, 
       IAutoRepository autoRepository, IBewertungRepository bewertungRepository, IFeedbackRepository feedbackRepository)
    {
        this.gui = gui;
        this.präferenzrechner = präferenzrechner;
        this.ergebnisausgabe = ergebnisausgabe;
        this.favoritenauswahl = favoritenauswahl;
        this.fragenkatalog = fragenkatalog;
        this.autoRepository = autoRepository;
        this.bewertungRepository = bewertungRepository;
        this.feedbackRepository = feedbackRepository;
    }
}