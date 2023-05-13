using HoltinData.PersistenceService;
using HoltinModels.Entities;
using HoltinModels.Requests.RoomRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinAdministratorsServices.AdministratorServicesOnRoom
{
    public class AdministratorServiceOnRoom : IAdministratorServiceOnRoom
    {
        private readonly IRoomPersistenceService _roomPersistenceService;

        public AdministratorServiceOnRoom(IRoomPersistenceService roomPersistenceService)
        {
            _roomPersistenceService = roomPersistenceService;
        }

        public void Delete(RoomByIdRequest id)
        {
            _roomPersistenceService.Delete(id);
        }

        public void Insert(Room room)
        {
            _roomPersistenceService.Insert(room);
        }

        public void Update(Room room)
        {
            _roomPersistenceService.Update(room);
        }
    }
}
