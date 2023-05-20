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
        public bool BookNewReservation(Reservation reservation);
    }
}
