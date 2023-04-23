using HoltinModels.Entities;
using HoltinModels.Requests.RoomRequest;
using HoltinModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices
{
    public interface IRoomService
    {
        public DefaultResponse<Room> GetRoomById (RoomByIdRequest id);
        public DefaultResponse<List<Room>> GetRoomByFilter(RoomByFilterRequest request);
    }
}
