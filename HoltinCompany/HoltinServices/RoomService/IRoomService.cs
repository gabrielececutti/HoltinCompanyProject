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
        /// <summary>
        /// Riotrna tutte le stanze che soddifano la richiesta. Se l'hotelId non è specificato, riotrna tutte le stanze di tutti gli hotel che soddisfano la richiesta.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DefaultResponse<List<Room>> GetRoomsWithFilter (RoomByFilterRequest request); 
    }
}
