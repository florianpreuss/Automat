using Aut_O_Mat_Lib.Database.Model;

namespace Aut_O_Mat_Lib.Präferenzrechner.Impl;

public class PräferenzrechnerImpl
{
    public void bewertungenEinpflegen(Dictionary<int, Dictionary<int, Autobewertung>> autobewertungen, int bewertung)
    {
        foreach (var bew in autobewertungen)
        {
           bew.Value.Values
        }
    }
}