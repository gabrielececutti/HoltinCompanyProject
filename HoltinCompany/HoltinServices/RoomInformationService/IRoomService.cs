using HoltinModels.DTO;
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
    public interface IRoomService
    { 
        public DefaultResponse<Room> GetRoomById (RoomByIdRequest request);
        public DefaultResponse<List<Room>> GetRoomsWithFilter (RoomByFilterRequest request); 
    }
}
