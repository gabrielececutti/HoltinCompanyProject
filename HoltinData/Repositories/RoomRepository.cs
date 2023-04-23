using HoltinModels.Entities;
using HoltinModels.Requests.RoomRequest;
using HoltinModels.Responses;
using HoltinRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinData.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public DefaultResponse<Room> GetRoomById(RoomByIdRequest id)
        {
            throw new NotImplementedException();
        }

        public DefaultResponse<List<Room>> GetRoomsByFilter(RoomByFilterRequest filter)
        {
            throw new NotImplementedException();
        }
    }
}
