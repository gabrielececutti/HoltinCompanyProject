using HoltinData.PersistenceService;
using HoltinModels.Entities;
using HoltinModels.Requests.RoomRequest;
using HoltinModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices.RoomService
{
    public class RoomService : IRoomService
    {
        private readonly IRoomPersistenceService _roomPersistenceService;

        public RoomService(IRoomPersistenceService roomPersistenceService)
        {
            _roomPersistenceService = roomPersistenceService;
        }

        public DefaultResponse<Room> GetRoomById(RoomByIdRequest request)
        {
            return _roomPersistenceService.GetRoomById(request);
        }

        public DefaultResponse<List<Room>> GetRoomsWithFilter(RoomByFilterRequest request)
        {
            return _roomPersistenceService.GetRoomsByFilter(request);
        }
    }
}
