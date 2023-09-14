using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Exemplar
    {
        public Buch Buch { get; set; }
        private int Zustand; // -1 = verloren; 0 = verliehen; 1 = auf lager;
        private string Exemplarzustand;
        private string ExemplarID;
        public Exemplar(Buch buch, int anzahl)
        {
            this.Buch = buch;
            this.SetZustand(1);
            this.SetExemplarzustand("neu");
            this.SetExemplarID($"{this.Buch.ISBN}-{anzahl}"); // 1523151358-15
        }
        public Exemplar() { }
        public void SetZustand(int zustand)
        { this.Zustand = zustand; }
        public int GetZustand()
        { return this.Zustand; }
        public void SetExemplarzustand(string zustand)
        { this.Exemplarzustand =  zustand; }
        public string GetExemplarzustand()
        { return this.Exemplarzustand;}
        public void SetExemplarID(string id)
        {
            this.ExemplarID = id;
        }
        public string GetExemplarID()
        { return this.ExemplarID;}
    }
}
