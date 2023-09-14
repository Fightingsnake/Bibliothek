using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Angestellter
    {
        public Bibliothek arbeitsplatz { get; set; }
        public void BuchDemBestandHinzufuegen() // neue Kiste Buecher ins Regal raeumen
        {
            Console.WriteLine();
            
            Console.WriteLine("Geben Sie den Titel ein:");
            Console.Write("==>");
            string titelneu = Console.ReadLine();
            Console.WriteLine("Geben Sie den Autor ein:");
            Console.Write("==>");
            string autorneu = Console.ReadLine();
            Console.WriteLine("Geben Sie die ISBN-Nummer ein:");
            Console.Write("==>");
            string isbnneu = Console.ReadLine();
            Console.WriteLine("Wie viele Exemplare wurden bestellt?");
            Console.Write("==>");
            int anzahl = Convert.ToInt16(Console.ReadLine());
            Buch buch = new Buch() { Autor = autorneu, ISBN = isbnneu, Titel = titelneu };
            for(int i = 0; i < anzahl; i++)
            {
                this.arbeitsplatz.AddBuecher(new Exemplar(buch, i));
            }
        }
    }
    /*
    Angestellter - Buch für die Ausleihe entgegennehmen
    Angestellter - Vom Besucher zurückgegebenes Buch eingegennehmen !
    Angestellter - Besucher anlegen
    Angestellter - Buch dem Bestand hinzufügen
    Angestellter - Buch aus dem Bestand entfernen
    Angestellter - Buch als verliehen vermerken
    Angestellter - Buch für Verleih freigeben
    Angestellter - Besucher sperren (nach Mahnung)
    Angestellter - Buchstatus prüfen (verliehen, vorhanden, fehlt, Zustand)
    Angestellter - Buchstatus setzen (verliehen, vorhanden, fehlt, Zustand)
    Angestellter - Bücher der besucherspezifischen Verleihliste hinzugefügt
    Angestellter - Mahnung erstellen
    Angestellter - Mahnung ändern
    Angestellter - Mahnung löschen
    Angestellter - Mahnung einsehen
    Angestellter - Mahnung versenden
    Angestellter - Mitgliedschaft prüfen
    Angestellter, Admin - Buchinformationen abrufen (Autor, ISBN, Name, etc.)
    Angestellter - Neue Bücher beantragen
    Angestellter - Besucher informieren (Hinweis - keine Mahung)
    Angestellte -  Mahngebühr von Besucher entgegennehmen/Verbuchung
    Angestellter - Login/Logout
    Angestellter - Prüfung Inventar (Bücher)
    Angestellter - Ausstellung Quittung Ausleihe
    Angestellter - Ausstellung Quittung Mahnung
     */
}
