using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Bibliothek
    {
        public string name { get; set; }
        private List<Exemplar> buecherregal;
        private List<Angestellter> angestellter;
        private List<Mitgliedskonto> Mitglieger;
        private Mitgliedskonto aktiverKunde;
        private Angestellter angemeldeterMitarbeiter;
        public Exemplar BuchAufDemTisch { get; set; } // noch einfuegen
        public Bibliothek()
        {
            buecherregal = new List<Exemplar>();
            angestellter = new List<Angestellter>();
            Mitglieger = new List<Mitgliedskonto>();
        }
        public Angestellter GetAngemeldeterMitarbeiter()
        {
            return this.angemeldeterMitarbeiter;
        }
        public void MitarbeiterLogout()
        {
            this.angemeldeterMitarbeiter = null;
        }
        public void MitarbeiterLogin()
        {
            Console.WriteLine("Wie lautet ihr login-name? ==> ");
            string logger = Console.ReadLine();
            for (int i = 0; i < angestellter.Count; i++)
            {
                if (this.angestellter[i].Loginname == null)
                {
                    Console.Write($"Bitte gebe einen Loginname fuer {this.angestellter[i].name} ein: ==> ");
                    this.angestellter[i].Loginname = Console.ReadLine();
                }
                if (logger == this.angestellter[i].Loginname)
                {
                    this.angemeldeterMitarbeiter = this.angestellter[i];
                    break;
                }

            }
        }
        public void SetEingelogt(Mitgliedskonto eingelogt)
        {
            this.aktiverKunde = eingelogt;
        }
        public void KundeRaus()
        {
            this.aktiverKunde = null;
        }
        public Mitgliedskonto GetEingelogterKunde()
        {
            return this.aktiverKunde;
        }
        public void AddBuecher(Exemplar buecher)
        {
            this.buecherregal.Add(buecher);
        }
        public void AddAngestellten(Angestellter arbeiter)
        {
            this.angestellter.Add(arbeiter);
        }
        public void AddMitglieder(Mitgliedskonto mitglied)
        {
            this.Mitglieger.Add(mitglied);
        }
        public List<Exemplar> GetBuecherregal()
        {
            return this.buecherregal;
        }
        public List<Angestellter> GetMitarbeiter()
        {
            return this.angestellter;
        }
        public List<Mitgliedskonto> GetMitglieder()
        {
            return this.Mitglieger;
        }
    }
}
