using HoltinModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices.ClientService
{
    public interface IBookingService
    {
        // prenotata una nuova reservation (inserimento nel db e nell'account del cliente)
        // devo fare update del database!
        public bool BookNewReservation(Reservation reservation);

    }
}
