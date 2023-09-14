using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek
{
    internal class Mahnung
    {
        public int ZahlungsStand { get; set; } = 0; // 0 = offen; 1 = bezahlt;
        public double Summe { get; set; }
    }
}
