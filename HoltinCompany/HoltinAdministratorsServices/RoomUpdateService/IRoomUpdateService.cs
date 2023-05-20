using HoltinModels.Entities;
using HoltinModels.Requests.RoomRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinAdministratorsServices.AdministratorServicesOnRoom
{
    public interface IRoomUpdateService
    {
        public void Insert(Room room);
        public void Update(Room room);
        public void AutoRoomsUpdating();
        public void Delete(RoomByIdRequest id);
    }
}
