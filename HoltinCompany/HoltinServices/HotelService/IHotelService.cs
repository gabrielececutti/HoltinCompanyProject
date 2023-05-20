using HoltinModels.DTO;
using HoltinModels.Entities;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Requests.RoomRequest;
using HoltinModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices.HotelService
{
    public interface IHotelService
    {
        /// <summary>
        /// Ritorna gli hotel con numero di stanze disponibili al momento
        /// </summary>
        /// <returns></returns>
        public DefaultResponse<List<HotelRoomNumber>> GetHotelsWithRoomsDisponibility();

        public DefaultResponse<Hotel> GetHotelById(HotelByIdRequest request);
        /// <summary>
        /// Riotrna gli hotel che soddisfano la richiesta
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DefaultResponse<List<Hotel>> GetHotelsWithFilter (HotelByFilterRequest request);
    }
}
