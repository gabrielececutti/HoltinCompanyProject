using HoltinModels.Entities;
using HoltinModels.Requests.RoomRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinAdministratorsServices.AdministratorServicesOnRoom
{
    public interface IAdministratorServiceOnRoom
    {
        public void Insert(Room room);
        public void Update(Room room);
        public void Delete(RoomByIdRequest id);
    }
}
