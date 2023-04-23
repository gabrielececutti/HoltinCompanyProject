using HoltinModels.Entities;
using HoltinModels.Requests.RoomRequest;
using HoltinModels.Responses;
using HoltinRepositories;
using HoltinServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinBusinessLogic
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public DefaultResponse<List<Room>> GetRoomByFilter(RoomByFilterRequest request)
        {
            throw new NotImplementedException();
        }

        public DefaultResponse<Room> GetRoomById(RoomByIdRequest id)
        {
            throw new NotImplementedException();
        }
    }
}
