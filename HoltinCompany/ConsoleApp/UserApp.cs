using HoltinConsoleApp.Factories;
using HoltinModels.Entities;
using HoltinModels.Requests;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Requests.RoomRequest;
using HoltinServices.ClientService;
using HoltinServices.HotelService;
using HoltinServices.LogInService;
using HoltinServices.ReservationService;
using HoltinServices.RoomService;
using HoltinServices.SignupService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class UserApp 
    {
        private readonly IHotelService _hotelService;
        private readonly IReservationService _reservationService;
        private readonly IRoomService _roomService;
        private readonly ILoginService _loginService;
        private readonly ISignupService _signupService;
        private readonly IClientService _clientService;
        private readonly IBookingService _bookingService;
        private readonly RandomClientFactory _randomClientFactory;

        public UserApp(IHotelService hotelService, IReservationService reservationService, IRoomService roomService, ILoginService loginService, ISignupService signupService, IClientService clientService, IBookingService bookingService, RandomClientFactory randomClientFactory)
        {
            _hotelService = hotelService;
            _reservationService = reservationService;
            _roomService = roomService;
            _signupService = signupService;
            _loginService = loginService;
            _clientService = clientService;
            _bookingService = bookingService;
            _randomClientFactory = randomClientFactory;
        }

        public void Run()
        {
            // nuovo account (con facotry)
            var client = _randomClientFactory.Create();

            // verifica con validatori 
            _signupService.SignUp(client);

            // log in account
            _loginService.Login(client);

            // vedere tutti gli hotel con il numero di stanze diponibili
            var result = _hotelService.GetHotelsWithRoomsDisponibility();
            result.Data.ForEach(h => Console.WriteLine(h.ToString()));

            // select di un hotel con filtro
            var hotels = _hotelService.GetHotelsWithFilter(new HotelByFilterRequest() { City = "Tokyo" });
            hotels.Data.ForEach(h => Console.WriteLine(h));

            // select room con filtro per quell'hotel 
            var roomFiletr = new RoomByFilterRequest() { WiFi = true, NigthPriceMax = 350, SingleBeds = 1, DoubleBeds = 1 };
            var rooms = _roomService.GetRoomsWithFilter(roomFiletr);
            rooms.Data.ForEach( r => Console.WriteLine(r.ToString()));
            Console.WriteLine(  );
            // istanziare nuova reservation
            var userRequest = new UserReservationRequest()
            {
                Client = client, 
                Room = rooms.Data.First(),
                CheckIn = new DateTime(2023, 7, 10),
                CheckOut = new DateTime(2023, 7, 15),
                Guest = 10
            };
            Console.WriteLine(  userRequest.Room);
            var reservation = _reservationService.CreateNewReservation(userRequest);
            Console.WriteLine(reservation.ToString());

            // inserirla nel db e nell'account cliente
        }
    }
}
