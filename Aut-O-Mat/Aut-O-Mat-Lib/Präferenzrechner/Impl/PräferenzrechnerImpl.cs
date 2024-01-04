using Aut_O_Mat_Lib.Database.Model;

namespace Aut_O_Mat_Lib.Präferenzrechner.Impl;

public class PräferenzrechnerImpl
{
    public void FindePerfektesAuto(Autobewertung, Dictionary<string, int> kundenBewertungen)
    {
        // Iteriere durch die Bewertungsschritte
        for (int schritt = 1; schritt <= 10; schritt++)
        {
            // Sortiere die Autos basierend auf den aktuellen Kundenbewertungen
            Autobewertung = SortiereAutos(Autobewertung, kundenBewertungen);

            // Aktualisiere die Kundenbewertungen basierend auf dem aktuellen Schritt
            AktualisiereKundenBewertungen(kundenBewertungen, schritt);
        }

        // Das Auto mit dem höchsten Prozentwert steht jetzt oben in der Liste
    }

    public void SortiereAutos(Dictionary<string, int> kundenBewertungen)
    {
        // Sortiere die Autos basierend auf den aktuellen Kundenbewertungen
        return Autobewertung.OrderByDescending(auto => BerechneProzentwert(auto.Bewertungen, kundenBewertungen)).ToList();
    }

    public void AktualisiereKundenBewertungen(Dictionary<string, int> kundenBewertungen, int schritt)
    {
        //brauchma evtl im Nachhinein falls was geändert werden soll
    }

    public double BerechneProzentwert(Dictionary<string, int> autoBewertungen, Dictionary<string, int> kundenBewertungen)
    {
        // da werden Prozentsätze basierend auf den Bewertungen berechnet
        
        double gesamtDifferenz = 0;

        foreach (var bew in autoBewertungen)
        {
            string kriterium = bew.Key;
            int autoBewertung = bew.Value;

            if (kundenBewertungen.TryGetValue(kriterium, out int kundenBewertung))
            {
                gesamtDifferenz += Math.Pow(autoBewertung - kundenBewertung, 2);
            }
        }

        return 100 - Math.Sqrt(gesamtDifferenz);
    }
}
