using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Bibliothek
    {
        private List<Exemplar> buecherregal;
        private List<Angestellter> angestellter;
        private List<Mitgliedskonto> Mitglieger;
        
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
