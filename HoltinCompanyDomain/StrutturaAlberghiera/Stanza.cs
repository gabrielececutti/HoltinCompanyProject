using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinCompanyDomain.Struttura
{
    public class Stanza
    {
        public bool Occupata { get; }
        public string NomeHotel { get; } 
        public string NumeroStanza { get; } 
        public int NumeroLettiSingoli { get; }
        public int NumeroLettiMatrimoniali { get; }
        public bool ConnessioneWiFi { get; }
        public bool ServizioInCamera { get; }
        public bool AriaCondizionata { get; }
        public bool Televisione { get; }
        public decimal PrezzoNotte { get; }
    }
}
