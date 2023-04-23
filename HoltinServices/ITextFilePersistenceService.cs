using HoltinModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices
{
    public interface ITextFilePersistenceService
    {
        public List<Reservation> GetAll();
        public void Save(Reservation reservation);
        public void Delete(string reservationId);
        public void Update (int oldReservationId , Reservation newReservation);
    }
}
