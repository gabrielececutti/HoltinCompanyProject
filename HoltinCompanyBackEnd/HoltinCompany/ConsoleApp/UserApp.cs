using HoltinAdministratorsServices.AdministratorServicesOnRoom;
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
        private readonly IRoomUpdateService _roomUpdateService;

        public UserApp(IHotelService hotelService, IReservationService reservationService, IRoomService roomService, ILoginService loginService, ISignupService signupService, IClientService clientService, IBookingService bookingService, RandomClientFactory randomClientFactory, IRoomUpdateService roomUpdateService)
        {
            _hotelService = hotelService;
            _reservationService = reservationService;
            _roomService = roomService;
            _signupService = signupService;
            _loginService = loginService;
            _clientService = clientService;
            _bookingService = bookingService;
            _randomClientFactory = randomClientFactory;
            _roomUpdateService = roomUpdateService;
        }

        public void Run()
        {
            // nuovo account (con facotry)
            var client = _randomClientFactory.Create();
            client.Password = "Querty12345$";
            Console.WriteLine( client.ToString());

            // verifica con validatori 
            _signupService.SignUp(client);

            // log in account
            _loginService.Login(client);

            // vedere tutti gli hotel con il numero di stanze diponibili
            var result = _hotelService.GetHotelsWithRoomsDisponibility();
            result.Data.ForEach ( x => Console.WriteLine(x));

            // select di un hotel con filtro
            var hotels = _hotelService.GetHotelsWithFilter(new HotelByFilterRequest() { City = "Tokyo" });
            hotels.Data.ForEach( x => Console.WriteLine(x));

            // select room con filtro per quell'hotel 
            var roomFiletr = new RoomByFilterRequest() { WiFi = true, NigthPriceMax = 350, SingleBeds = 1, DoubleBeds = 1, Booked = false };
            var rooms = _roomService.GetRoomsWithFilter(roomFiletr);
            rooms.Data.ForEach( x => Console.WriteLine(x));


            // istanziare nuova reservation
            var room = rooms.Data.First(); 
            var userRequest = new UserReservationRequest()
            {
                Client = client,
                Hotel = _hotelService.GetHotelById( new HotelByIdRequest { Id = room.HotelId }).Data,
                Room = room,
                CheckIn = new DateTime(2023, 5, 10),
                CheckOut = new DateTime(2023, 5, 25),
                Guest = 10
            };
            var reservation = _reservationService.CreateNewReservation(userRequest);
            Console.WriteLine( "PRENOTAZIONE ISTANZIATA: ");
            Console.WriteLine(reservation.ToString());

            var filter2 = new RoomByFilterRequest() { WiFi = true, NigthPriceMax = 101, SingleBeds = 1, DoubleBeds = 1, Booked = true };

            // inserirla nel db e update tabella room (la resevation è già collegata al cliente) fare controllo disponibilità
            _bookingService.BookNewReservation(reservation); 

            _roomUpdateService.UpdateRoomAvailability();

            // ottenre reservation del cliente
            Console.WriteLine("PRENOTAZIONE DEL CLIENTE: ");
            var reservationsBooked = _clientService.GetReservationBooked(client).First();
            reservationsBooked.Hotel = userRequest.Hotel;
            reservationsBooked.Room = room;
            reservationsBooked.Client = client;
            Console.WriteLine(reservationsBooked.ToString());
        }
    }
}
