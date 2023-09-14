using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Mitgliedskonto
    {
        private string name;
        private int id;
        private bool maennlich;
        private int geburtsjahr;
        private string adresse;
        private Exemplar[] AusgelieheneBuecher;
        private List<Mahnung> mahnungen;

        public int GetID()
        {
            return this.id;
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
    }
}
