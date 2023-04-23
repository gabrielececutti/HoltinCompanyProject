using HoltinCompanyDomain.StrutturaAlberghiera.Servizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinCompanyDomain.Struttura
{
    public class Albergo
    {
        public string Nome { get; } // PRIMARY KEY
        public string Città { get; } // PRIMARY KEY
        public List<Stanza> Stanze { get; }
        public List<IServizioCompleto> ServiziCompleti { get; }
        public List<IServizioGiornaliero> ServiziGiornalieri { get; }
        public List<Ristorante> Ristoranti { get; }


    }
}
