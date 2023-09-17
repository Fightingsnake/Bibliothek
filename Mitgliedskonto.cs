using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Mitgliedskonto
    {
        private bool aktiv = true;
        private string name;
        private int id = 0;
        private bool maennlich;
        private int geburtsjahr;
        private string adresse;
        private Exemplar[] AusgelieheneBuecher = new Exemplar[16];
        private List<Mahnung> mahnungen = new List<Mahnung>();

        public Mitgliedskonto(string name, int id, bool geschlecht, int jahr, string adresse)
        {
            this.name = name;
            this.id = id;
            this.geburtsjahr = jahr;
            this.adresse = adresse;
            this.maennlich = geschlecht;
        }
        public Mitgliedskonto() { }
        public int GetID()
        {
            return this.id;
        }
        public void AusgelieheneBuecherAuflisten()
        {
            int i = 1;
            foreach (Exemplar item in this.AusgelieheneBuecher)
            {
                Console.WriteLine($"[ {i} ]  {item.GetExemplarID()}");
                Console.WriteLine($"{item.Buch.Autor,20} : {item.Buch.Titel}");
                i++;
            }
        }
        public Exemplar[] Buchliste()
        {
            return this.AusgelieheneBuecher;
        }
        public void SetInaktiv()
        { this.aktiv = false; }
        public void SetAktiv()
        { this.aktiv = true; }
        public bool GetAktiv()
        {
            return this.aktiv;
        }
        public string GetGeschlecht()
        {
            if (maennlich)
                return "maennlich";
            else
                return "weiblich";
        }
        public int GetGeburtsjahr()
        {
            return this.geburtsjahr;
        }
        public string GetAdresse()
        { return this.adresse;}
        public void SetID(int id)
        { this.id = id; }
        public void SetGeschlecht(bool maennlich)
        { this.maennlich = maennlich; }
        public void SetGeburtsjahr(int geburtsjahr)
        {
            this.geburtsjahr = geburtsjahr;
        }
        public void SetAdresse(string adresse)
        { this.adresse = adresse; }
        public string GetName()
        { return this.name; }
        public void BuchLeihen(Exemplar buch)
        {
            for (int i = 0; i < AusgelieheneBuecher.Length; i++)
                if (AusgelieheneBuecher[i] == null)
                    AusgelieheneBuecher[i] = buch;
        }
        public void BuchZurueck(Exemplar buch)
        {
            for (int i = 0; i < AusgelieheneBuecher.Length; i++)
                if (AusgelieheneBuecher[i] == buch)
                    AusgelieheneBuecher[i] = null;
        }
        public void MahnungEmpfangen(Mahnung mahnung)
        {
            this.mahnungen.Add(mahnung);
        }
        public List<Mahnung> GetMahnungen()
        {
            return this.mahnungen;
        }
        public void MahnungAnzeigen()
        {
            foreach (Mahnung item in this.mahnungen)
                if (item.ZahlungsStand == 0)
                {
                    Console.WriteLine(item.Inhalt);
                    Console.WriteLine("Bezahlen Sie!");
                    Console.WriteLine($"Bezahlen Sie {item.Summe} innerhalbe der naechsten {item.Resttage} Tage!");
                    Console.WriteLine($"{item.buch.Buch.Titel} von {item.buch.Buch.Autor} wird von anderen gebraucht.");
                    Console.WriteLine("Ihr Benutzerkonto wird sonst gesperrt! UND SIE VERKLAGT!");
                }
        }
        
        public void KontoPruefung()
        {
            if (aktiv)
                Console.WriteLine($"{id,3}: {name}" +
                                  $"Wohnhaft: {adresse}" +
                                  $"Geboren: {geburtsjahr}");
            else
                Console.WriteLine("Dieses Konto ist gesperrt.");
        }
    }
}
