using System;

namespace Bibliothek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Mitgliedskonto juergen = new Mitgliedskonto();

            //komposition
            juergen.MahnungEmpfangen(new Mahnung() { Summe = 3.85, ZahlungsStand = 0});

            //aggregation
            Mahnung x = new Mahnung() { Summe = 5.95, ZahlungsStand = 0 };
            juergen.MahnungEmpfangen(x);
            */
            Bibliothek stadtbibliothek = new Bibliothek();
            Angestellter mueller = new Angestellter() { arbeitsplatz = stadtbibliothek };
            
        }
    }
}
