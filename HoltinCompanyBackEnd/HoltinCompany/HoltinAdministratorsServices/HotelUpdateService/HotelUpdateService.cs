using HoltinData.PersistenceService;
using HoltinModels.Entities;
using HoltinModels.Requests.HotelRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinAdministratorsServices.AdministratorServicesOnHotel
{
    public class HotelUpdateService : IHotelUpdateService
    {
        private readonly IHotelPersistenceService _hotelPersistenceService;

        public HotelUpdateService(IHotelPersistenceService hotelPersistenceService)
        {
            _hotelPersistenceService = hotelPersistenceService;
        }

        public void Insert(Hotel hotel)
        {
            _hotelPersistenceService.Insert(hotel);
        }

        public void Update(Hotel hotel)
        {
            _hotelPersistenceService.Update(hotel);
        }

        public void Delete(HotelByIdRequest id)
        {
            _hotelPersistenceService.Delete(id);
        }
    }
}
