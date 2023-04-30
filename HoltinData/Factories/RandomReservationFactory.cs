using Bogus;
using HoltinConsoleApp.Factories;
using HoltinData.Repositories;
using HoltinModels.Entities;
using HoltinModels.Requests.RoomRequest;

namespace HoltinModels.Factories
{
    public class RandomReservationFactory
    {
        private readonly Faker<Reservation> _faker;
        private readonly RandomClientFactory _randomClientFactory;
        private readonly RoomRepository _roomRepository;
        private int _guestMax;
        private int _MaxPriceAddedToNightPrice;
        private int _roomMaxId;
        private readonly Random _random = new Random();

        public RandomReservationFactory(Faker<Reservation> faker, RandomClientFactory randomClientFactory, RoomRepository roomRepository, int guestMax, int maxPriceAddedToNightPrice, int roomMax)
        {
            _faker = faker;
            _randomClientFactory = randomClientFactory;
            _roomRepository = roomRepository;
            _guestMax = guestMax;
            _MaxPriceAddedToNightPrice = maxPriceAddedToNightPrice;
            _roomMaxId = roomMax;
        }

        /// <summary>
        /// Returns a new reservation from a new client
        /// </summary>
        /// <returns></returns>
        public Reservation Create ()
        {
            // seleziono una random stanza di un hotel
            var room = GetRandomRoom();

            // genero un nuovo ciente
            var client = _randomClientFactory.Create();

            // genero la nuova Reservation
            var reservation = _faker
                        .RuleFor(c => c.Id, f => f.IndexFaker)
                        .RuleFor(c => c.HotelId, f => room.HotelId) 
                        .RuleFor(c => c.RoomId, f => room.Id )
                        .RuleFor(c => c.RoomNumber, f => room.Number ) 
                        .RuleFor(c => c.ClientId, f => client.Id)
                        .RuleFor(c => c.Guests, f => f.Random.Number(1,_guestMax))
                        .RuleFor(c => c.CheckIn, f => f.Date.Past(0))
                        .RuleFor(c => c.CheckOut, f => f.Date.Future(1))
                        .RuleFor(c => c.TotalPrice, f => f.Random.Number((int)room.NightPrice, (int)room.NightPrice + _MaxPriceAddedToNightPrice))
                        .Generate();
            return reservation;
        }

        /// <summary>
        /// Returns a new reservation from an existing client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public Reservation Create (Client client)
        {
            // seleziono una random stanza di un hotel
            var room = GetRandomRoom();

            // genero la nuova Reservation 
            var reservation = _faker
                        .RuleFor(c => c.Id, f => f.IndexFaker)
                        .RuleFor(c => c.HotelId, f => room.HotelId)
                        .RuleFor(c => c.RoomId, f => room.Id)
                        .RuleFor(c => c.RoomNumber, f => room.Number)
                        .RuleFor(c => c.ClientId, f => client.Id)
                        .RuleFor(c => c.Guests, f => f.Random.Number(1, _guestMax))
                        .RuleFor(c => c.CheckIn, f => f.Date.Past(1))
                        .RuleFor(c => c.CheckOut, f => f.Date.Future(1))
                        .RuleFor(c => c.TotalPrice, f => f.Random.Number((int)room.NightPrice, (int)room.NightPrice + _MaxPriceAddedToNightPrice))
                        .Generate();
            return reservation;
        }

        // return a random Room from a Hotel
        private  Room GetRandomRoom ()
        {
            int n = _random.Next(1, _roomMaxId);
            var randomId = new RoomByIdRequest { Id = n };
            return _roomRepository.GetRoomById(randomId).Data;
        }
    }
}
