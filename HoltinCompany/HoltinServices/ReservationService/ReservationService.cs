using HoltinModels.Entities;
using HoltinModels.Requests;
using HoltinServices.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly ReservationPriceCalculator _reservationPriceCalculator;

        public ReservationService(ReservationPriceCalculator reservationPriceCalculator)
        {
            _reservationPriceCalculator = reservationPriceCalculator;
        }

        public Reservation CreateNewReservation(UserReservationRequest userReservationRequest)
        {
            var hotel = userReservationRequest.Hotel;
            var room = userReservationRequest.Room;
            var client = userReservationRequest.Client;

            var reservation = new Reservation
            {
                Hotel = hotel,
                HotelId = hotel.Id,
                RoomId = room.Id,
                RoomNumber = room.Number,
                Room = room,
                Client = client,
                ClientId = client.Id,
                Guests = userReservationRequest.Guest,
                CheckIn = userReservationRequest.CheckIn,
                CheckOut = userReservationRequest.CheckOut,
                TotalPrice = _reservationPriceCalculator.Calculate(userReservationRequest)
            };
            return reservation;
        }
    }
}
