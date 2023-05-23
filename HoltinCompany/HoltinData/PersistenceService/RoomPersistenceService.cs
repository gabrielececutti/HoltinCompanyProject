using HoltinModels.Entities;
using HoltinModels.Requests.RoomRequest;
using HoltinModels.Responses;
using HoltinRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinData.PersistenceService
{
    public class RoomPersistenceService : IRoomPersistenceService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomPersistenceService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public DefaultResponse<List<Room>> GetRoomsByFilter(RoomByFilterRequest request)
        {
            return _roomRepository.GetRoomsByFilter(request);
        }

        public DefaultResponse<List<Room>> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public DefaultResponse<Room> GetRoomById(RoomByIdRequest id)
        {
            return _roomRepository.GetRoomById(id);
        }

        public DefaultResponse<bool> Insert(Room room)
        {
            return _roomRepository.Insert(room);
        }

        public DefaultResponse<bool> Update(Room room)
        {
            return _roomRepository.Update(room);
        }

        public DefaultResponse<bool> Delete(RoomByIdRequest id)
        {
            return _roomRepository.Delete(id);
        }
    }
}
