using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Angestellter
    {
        public Bibliothek arbeitsplatz { get; set; }
        public string Loginname { get; set; }
        public string name { get; set; }
        public void BuchDemBestandHinzufuegen() // neue Kiste Buecher ins Regal raeumen
        {
            Console.WriteLine();
            Console.WriteLine("Geben Sie den Titel ein:");
            Console.Write("==> ");
            string titelneu = Console.ReadLine();
            Console.WriteLine("Geben Sie den Autor ein:");
            Console.Write("==> ");
            string autorneu = Console.ReadLine();
            Console.WriteLine("Geben Sie die ISBN-Nummer ein:");
            Console.Write("==> ");
            string isbnneu = Console.ReadLine();
            Console.WriteLine("Wie viele Exemplare wurden bestellt?");
            Console.Write("==> ");
            int anzahl = Convert.ToInt16(Console.ReadLine());
            Buch buch = new Buch() { Autor = autorneu, ISBN = isbnneu, Titel = titelneu };
            for (int i = 0; i < anzahl; i++)
            {
                this.arbeitsplatz.AddBuecher(new Exemplar(buch, i));
            }
        }
        public void BuchDemBestandEntfernen()
        {
            Console.WriteLine("Bitte gebe die Buch-ID ein, die du entfernen moechtest.");
            Console.Write("==> ");
            string id = Console.ReadLine();
            for (int i = 0; i < this.arbeitsplatz.GetBuecherregal().Count; i++)
                if (this.arbeitsplatz.GetBuecherregal()[i].GetExemplarID() == id)
                    this.arbeitsplatz.GetBuecherregal()[i] = null;
        } // kaputtes buch aus dem sortiment entnehmen
        public void BuchDemBestandEntfernen(string id)
        {
            for (int i = 0; i < this.arbeitsplatz.GetBuecherregal().Count; i++)
                if (this.arbeitsplatz.GetBuecherregal()[i].GetExemplarID() == id)
                    this.arbeitsplatz.GetBuecherregal()[i] = null;
        }
        public void NeuesMitglied()
        {
            Console.Write("Name des neuen Kunden: ");
            string name = Console.ReadLine();
            Console.Write("Das Geburtsjahr des Kunden? : ");
            int jahr = Convert.ToInt32(Console.ReadLine());
            Console.Write("Die Adresse des Kunden? : ");
            string adressse = Console.ReadLine();
            Console.Write("Ist der Kunde maennlich? ( y / n): ");
            char x = Convert.ToChar(Console.ReadLine());
            bool geschlecht;
            if (x == 'y')
                geschlecht = true;
            else
                geschlecht = false;
            Mitgliedskonto neu = new Mitgliedskonto(name, this.arbeitsplatz.GetMitglieder().Count + 1, geschlecht, jahr, adressse);
            this.arbeitsplatz.AddMitglieder(neu);
        } // kunde registrieren
        public void SperrMitglied()
        {
            Console.Write("Moechten Sie die ID (1) oder den Namen (2) eingeben? ==> ");
            int wahl = Convert.ToInt32(Console.ReadLine());
            if (wahl == 1)
            {
                Console.Write("Gebe die zu sperrende ID ein: ==>");
                int sperren = Convert.ToInt32(Console.ReadLine());
                if (sperren < 0 || sperren > this.arbeitsplatz.GetMitglieder().Count)
                    Console.WriteLine("Die ID wurde nicht gefunden");
                else
                    this.arbeitsplatz.GetMitglieder()[sperren].SetInaktiv();
            }
            else if (wahl == 2)
            {
                Console.Write("Gebe den zu sperrenden Namen ein: ==> ");
                bool found = false;
                string sperren = Console.ReadLine();
                for (int i = 0; i < this.arbeitsplatz.GetMitglieder().Count; i++)
                {
                    if (this.arbeitsplatz.GetMitglieder()[i].GetName() == sperren)
                    {
                        this.arbeitsplatz.GetMitglieder()[i].SetInaktiv();
                        found = true;
                        break;
                    }
                }
                if (!found)
                    Console.WriteLine("Der Name wurde nicht gefunden.");
            }
            else
                Console.WriteLine("Das war eine falsche eingabe...");
        } // kunde inaktiv schalten
        public void BuchstatusSetzen()
        {
            Console.Write("Gebe die Buch-ID an: ");
            string id = Console.ReadLine();
            for (int i = 0; i < this.arbeitsplatz.GetBuecherregal().Count; i++)
            {
                if (this.arbeitsplatz.GetBuecherregal()[i].GetExemplarID() == id)
                {
                    Console.WriteLine("-1 = verloren ; 0 = verliehen ; 1 = auf lager");
                    Console.WriteLine("Welchen Zustand soll es bekommen?");
                    int zustand = Convert.ToInt32(Console.ReadLine());
                    this.arbeitsplatz.GetBuecherregal()[i].SetZustand(zustand);
                    if (zustand == -1)
                    {
                        this.BuchDemBestandEntfernen(id);
                    }
                }
                else
                    Console.WriteLine("Dieses Exemplar wurde nicht gefunden.");
            }
        }
        public void PruefeBuecherListe()
        {
            foreach (Exemplar item in this.arbeitsplatz.GetBuecherregal())
            {
                if (item.GetZustand() == 1)
                    Console.WriteLine($"{item.Buch.Autor,20} : {item.Buch.Titel}");
            }
        }
        public void MahnungErstellen()
        {
            Console.Write("Geben Sie die ID des Kunden ein: ==> ");
            int id = Convert.ToInt32(Console.ReadLine());
            Mitgliedskonto kunde = this.arbeitsplatz.GetMitglieder()[id];
            kunde.AusgelieheneBuecherAuflisten();
            Console.Write("Um welches Buch handelt es sich? ==>");
            Exemplar problem = kunde.Buchliste()[Convert.ToInt32(Console.ReadLine())];
            Console.Write("Wie hoch sind die Kosten? ==> ");
            double kosten = Convert.ToDouble(Console.ReadLine());
            Mahnung m = new Mahnung() { Summe = kosten, buch = problem, Resttage = 6 };
            MahnungVersenden(m, kunde);
        }
        public void MahnungVersenden(Mahnung mahne, Mitgliedskonto empfaenger)
        {
            empfaenger.MahnungEmpfangen(mahne);
        }
        public void MahnungAendern()
        {
            for (int i = 1; i < this.arbeitsplatz.GetEingelogterKunde().GetMahnungen().Count; i++)
            {
                if (this.arbeitsplatz.GetEingelogterKunde().GetMahnungen()[i].ZahlungsStand == 0)
                    Console.WriteLine($"[ {i} ] > {this.arbeitsplatz.GetEingelogterKunde().GetMahnungen()[i].Summe} EUR < : {this.arbeitsplatz.GetEingelogterKunde().GetMahnungen()[i].buch.Buch.Titel} ");
            }
            Console.Write("Welche moechtest du aendern?");
            int wahl = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("[ 1 ] Betrag\n[ 2 ] Frist\n[ 3 ] Zahlungsstand");
            Console.Write("Was moechtest du aendern?");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("alt " + this.arbeitsplatz.GetEingelogterKunde().GetMahnungen()[wahl].Summe);
                    Console.Write("Gebe den neuen Betrag ein: ==> ");
                    this.arbeitsplatz.GetEingelogterKunde().GetMahnungen()[wahl].Summe = Convert.ToDouble(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("alt " + this.arbeitsplatz.GetEingelogterKunde().GetMahnungen()[wahl].Resttage);
                    Console.WriteLine("Gebe die neue Frist ein: ==> ");
                    this.arbeitsplatz.GetEingelogterKunde().GetMahnungen()[wahl].Resttage = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("alt " + this.arbeitsplatz.GetEingelogterKunde().GetMahnungen()[wahl].ZahlungsStand);
                    Console.WriteLine("Gebe den neuen Zahlungsstand ein: ==> ");
                    this.arbeitsplatz.GetEingelogterKunde().GetMahnungen()[wahl].ZahlungsStand = Convert.ToInt32(Console.ReadLine());
                    break;
            }
        }
       
    }
    /*
    Angestellter - Buch für die Ausleihe entgegennehmen
    Angestellter - Vom Besucher zurückgegebenes Buch entgegennehmen !
    Angestellter - Buchstatus prüfen (verliehen, vorhanden, fehlt, Zustand)
    Angestellter - Bücher der besucherspezifischen Verleihliste hinzugefügt
    Angestellter - Mahnung löschen
    Angestellter, Admin - Buchinformationen abrufen (Autor, ISBN, Name, etc.)
    Angestellter - Neue Bücher beantragen
    Angestellter - Besucher informieren (Hinweis - keine Mahung)
    Angestellte -  Mahngebühr von Besucher entgegennehmen/Verbuchung
    Angestellter - Ausstellung Quittung Ausleihe
    Angestellter - Ausstellung Quittung Mahnung


    Angestellter - Buch dem Bestand hinzufügen
    Angestellter - Buch aus dem Bestand entfernen
    Angestellter - Buch als verliehen vermerken
    Angestellter - Buch für Verleih freigeben
    Angestellter - Buchstatus setzen (verliehen, vorhanden, fehlt, Zustand)
    Angestellter - Prüfung Inventar (Bücher)

    Angestellter - Mahnung einsehen
    Angestellter - Besucher sperren (nach Mahnung)
    Angestellter - Mitgliedschaft prüfen
    Angestellter - Mahnung ändern
    Angestellter - Mahnung erstellen
    Angestellter - Mahnung versenden
    Angestellter - Besucher anlegen

    Angestellter - Login/Logout

     */
}
