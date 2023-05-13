using HoltinModels.Entities;
using HoltinModels.Requests.ReservationRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinAdministratorsServices.AdministratorServicesOnReservation
{
    public interface IAdministratorServiceOnReservation
    {
        public void Delete (ReservationByIdRequest id);
    }
}
