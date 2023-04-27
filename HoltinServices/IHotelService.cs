﻿using HoltinModels.Entities;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Responses;

namespace HoltinServices
{
    public interface IHotelService
    {
        public DefaultResponse<Hotel> GetHotelById (HotelByIdRequest request);
        public DefaultResponse<List<Hotel>> GetHotelByFilter(HotelByFilterRequest request);
        public bool Insert (Hotel hotel);
        public bool Update (Hotel hotel);
        public bool Delete (HotelByIdRequest id);
    }
}
