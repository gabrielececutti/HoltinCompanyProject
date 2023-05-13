﻿using HoltinData.PersistenceService;
using HoltinModels.Entities;
using HoltinModels.Requests.ReservationRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinAdministratorsServices.AdministratorServicesOnReservation
{
    public class AdministratorServiceOnReservation : IAdministratorServiceOnReservation
    {
        private readonly IReservationPersistenceService _reservationPersistenceService;

        public AdministratorServiceOnReservation(IReservationPersistenceService reservationPersistenceService)
        {
            _reservationPersistenceService = reservationPersistenceService;
        }

        public void Delete(ReservationByIdRequest id)
        {
            _reservationPersistenceService.Delete(id);
        }
    }
}
