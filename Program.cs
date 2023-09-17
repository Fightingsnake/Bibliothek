using System;
using System.Runtime.CompilerServices;

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
            Bibliothek stadtbibliothek = new Bibliothek() { name = "Stadtbibliothek" };
            Angestellter mueller = new Angestellter() { arbeitsplatz = stadtbibliothek, name = "Mueller", Loginname = "muli"};
            Angestellter wurst = new Angestellter() { arbeitsplatz = stadtbibliothek, name = "Hans Wurst", Loginname = "wr"};

            stadtbibliothek.AddAngestellten(mueller);
            stadtbibliothek.AddAngestellten(wurst);
            Mitgliedskonto hans = new Mitgliedskonto();
            stadtbibliothek.AddMitglieder(hans);
            while (true)
            {
                Console.WriteLine("Welche Seite? (1 Kunde ; 2 Angestellter)");
                int antwort = Convert.ToInt16(Console.ReadLine());
                if (antwort == 2)
                {
                    if (stadtbibliothek.GetAngemeldeterMitarbeiter() != null)
                    {
                        Console.WriteLine("[ 1 ] => Kunden verwalten");
                        Console.WriteLine("[ 2 ] => Buecher verwalten");
                        Console.WriteLine("[ 3 ] => Login/Logout");
                        Console.WriteLine("[ 4 ] => ");
                        Console.WriteLine("[ 5 ] => Seitenwechsel");
                        Console.WriteLine("[ 6 ] => Beenden");
                        //Console.WriteLine("[  ] => ");
                        //Console.WriteLine("[  ] => ");
                        Console.WriteLine("Was moechten Sie tun?");
                        int eingabe = Convert.ToInt32(Console.ReadLine());
                        switch (eingabe)
                        {
                            case 1:
                                Console.WriteLine("[ 1 ] : Kundenkonto anlegen");
                                Console.WriteLine("[ 2 ] : Kundenkonto sperren");
                                Console.WriteLine("[ 3 ] : Kunde mahnen");
                                Console.WriteLine("[ 4 ] : Mahnungen von Kunde anzeigen");
                                Console.WriteLine("[ 5 ] : Mitgliedschaft pruefen");
                                Console.WriteLine("[  ] : ");
                                Console.Write("Was moechten Sie tun?: ==>");
                                int wahl = Convert.ToInt32(Console.ReadLine());
                                switch (wahl)
                                {
                                    case 1:
                                        stadtbibliothek.GetAngemeldeterMitarbeiter().NeuesMitglied();
                                        break;
                                    case 2:
                                        stadtbibliothek.GetAngemeldeterMitarbeiter().SperrMitglied();
                                        break;
                                    case 3:
                                        stadtbibliothek.GetAngemeldeterMitarbeiter().MahnungErstellen();
                                        break;
                                    case 4:
                                        if (stadtbibliothek.GetEingelogterKunde() != null)
                                        {
                                            foreach (Mahnung item in stadtbibliothek.GetEingelogterKunde().GetMahnungen())
                                            {
                                                Console.WriteLine($"Mahnung bei Buch {item.buch.GetExemplarID()}" +
                                                                  $"Titel des Buchs: {item.buch.Buch.Titel}" +
                                                                  $"Summe der Mahnung: {item.Summe} EURO");
                                            }
                                        }
                                        else
                                            Console.WriteLine("Um welchen Kunden handelt es sich?");
                                        break;
                                    case 5:
                                        if (stadtbibliothek.GetEingelogterKunde() != null)
                                            stadtbibliothek.GetEingelogterKunde().KontoPruefung();
                                        else
                                        {
                                            Console.Write("Bitte gebe eine KundenID ein: ==> ");
                                            stadtbibliothek.GetMitglieder()[Convert.ToInt32(Console.ReadLine())].KontoPruefung();
                                        }
                                        break;
                                }
                                break;
                            case 2:
                                Console.WriteLine("[ 1 ] : Neue Buecher ins System einpflegen");
                                Console.WriteLine("[ 2 ] : Buch aus dem System entfernen");
                                Console.WriteLine("[ 3 ] : Buchstatus aendern");
                                Console.WriteLine("[ 4 ] : ");
                                Console.WriteLine("[  ] : ");
                                Console.WriteLine("[  ] : ");
                                Console.WriteLine("[ 7 ] : Buchinventar auflisten");
                                Console.WriteLine("[  ] : ");
                                Console.Write("Was moechten Sie tun?: ==>");
                                int auswahl = Convert.ToInt32(Console.ReadLine());
                                switch(auswahl)
                                {
                                    case 1:
                                        stadtbibliothek.GetAngemeldeterMitarbeiter().BuchDemBestandHinzufuegen();
                                        break;
                                    case 2:
                                        stadtbibliothek.GetAngemeldeterMitarbeiter().BuchDemBestandEntfernen();
                                        break;
                                    case 3:
                                        stadtbibliothek.GetAngemeldeterMitarbeiter().BuchstatusSetzen();
                                        break;
                                    case 7:
                                        foreach (Exemplar item in stadtbibliothek.GetBuecherregal())
                                            Console.WriteLine($"{item.Buch.Autor,20} : {item.Buch.Titel}");
                                        break;
                                }
                                
                                break;
                            case 3:
                                stadtbibliothek.MitarbeiterLogout();
                                break;
                            case 4:
                                break;
                            case 5:
                                continue;
                            case 6:
                                Console.WriteLine("Bis demnaechst");
                                Environment.Exit(0);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Es ist niemand eingeloggt.");
                        stadtbibliothek.MitarbeiterLogin();
                    }
                }
                else if (antwort == 1)
                {

                }
            }
        }
    }
}
