using HoltinModels.Entities;
using HoltinModels.Requests.HotelRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinAdministratorsServices.AdministratorServicesOnHotel
{
    public interface IHotelUpdateService
    {
        public void Insert(Hotel hotel);
        public void Update(Hotel hotel);
        public void Delete(HotelByIdRequest id);
    }
}
