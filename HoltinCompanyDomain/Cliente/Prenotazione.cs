using HoltinCompanyDomain.Struttura;
using HoltinCompanyDomain.StrutturaAlberghiera.Servizi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinCompanyDomain.Cliente
{
    public class Prenotazione
    {
        public string CodiceIdentificativo { get;} 
        public string NomeHotel { get; }   // informazione da stanza   
        public Stanza Stanza { get; }
        public List<IServizioGiornaliero> ServiziGiornalieri { get; }
        public List<IServizioCompleto> ServiziCompleti { get; }
        public int NumeroPersone { get; }
        public DateTime CheckIn { get; }
        public DateTime CheckOut { get; }
        public decimal CostoTotale { get; }

    }
}
