using Bogus;
using Bogus.DataSets;
using HoltinConsoleApp.Factories;
using HoltinData.Repositories;
using HoltinModels.Entities;
using HoltinModels.Requests.RoomRequest;
using HoltinRepositories;

namespace HoltinModels.Factories
{
    public class RandomReservationFactory
    {
        private readonly Faker<Reservation> _faker;
        private readonly RandomClientFactory _randomClientFactory;
        private readonly IRoomRepository _roomRepository;
        private int _roomMaxId;
        private readonly Random _random = new Random();

        public RandomReservationFactory(Faker<Reservation> faker, RandomClientFactory randomClientFactory, IRoomRepository roomRepository, int roomIdMax)
        {
            _faker = faker;
            _randomClientFactory = randomClientFactory;
            _roomRepository = roomRepository;
            _roomMaxId = roomIdMax;
        }

        /// <summary>
        /// Returns a new reservation from a new client
        /// </summary>
        /// <returns></returns>
        public Reservation Create ()
        {
            // select a generic room of a hotel
            var room = GetRandomRoom();

            // create a new client
            var client = _randomClientFactory.Create();

            // create two random dates for checkIn and checkOut
            var dates = GetGenericDates();
            var checkIn = dates.Item1;
            var checkOut = dates.Item2;

            // calculate the price of the room
            var diff = Math.Abs((checkOut - checkIn).TotalDays);
            var roomPrice = room.NightPrice * (decimal)diff;

            // create the new reservation
            var reservation = _faker
                        .RuleFor(c => c.Id, f => f.IndexFaker)
                        .RuleFor(c => c.HotelId, f => room.HotelId) 
                        .RuleFor(c => c.RoomId, f => room.Id )
                        .RuleFor(c => c.RoomNumber, f => room.Number ) 
                        .RuleFor(c => c.ClientId, f => client.Id)
                        .RuleFor(c => c.Guests, f => f.Random.Number(1,(room.DoubleBeds * 2) + room.SingleBeds))
                        .RuleFor(c => c.CheckIn, checkIn)
                        .RuleFor(c => c.CheckOut, checkOut)
                        .RuleFor(c => c.TotalPrice, f => f.Random.Number((int) roomPrice, (int) roomPrice + 500))
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
            // select a generic room of a hotel
            var room = GetRandomRoom();

            // create two random dates for checkIn and checkOut
            var dates = GetGenericDates();
            var checkIn = dates.Item1;
            var checkOut = dates.Item2;

            // calculate the price of the room
            var diff = Math.Abs((checkOut - checkIn).TotalDays);
            var roomPrice = room.NightPrice * (decimal)diff;

            // create the new reservation
            var reservation = _faker
                        .RuleFor(c => c.Id, f => f.IndexFaker)
                        .RuleFor(c => c.HotelId, f => room.HotelId)
                        .RuleFor(c => c.RoomId, f => room.Id)
                        .RuleFor(c => c.RoomNumber, f => room.Number)
                        .RuleFor(c => c.ClientId, f => client.Id)
                        .RuleFor(c => c.Guests, f => f.Random.Number(1, (room.DoubleBeds * 2) + room.SingleBeds))
                        .RuleFor(c => c.CheckIn, checkIn)
                        .RuleFor(c => c.CheckOut, checkOut)
                        .RuleFor(c => c.TotalPrice, f => f.Random.Number((int)roomPrice, (int)roomPrice + 500))
                        .Generate();
            return reservation;
        }

        // returns a random Room from a Hotel
        private  Room GetRandomRoom ()
        {
            int n = _random.Next(1, _roomMaxId);
            var randomId = new RoomByIdRequest { Id = n };
            return _roomRepository.GetRoomById(randomId).Data;
        }

        // returns two generic dates with a difference <=20
        private (DateTime, DateTime) GetGenericDates ()
        {
            var faker = new Faker();
            DateTime date1, date2;
            TimeSpan difference;
            do
            {
                date1 = faker.Date.Past();
                date2 = faker.Date.Future();
                difference = date2 - date1;
            } while (Math.Abs(difference.TotalDays) > 20);
            return (date1, date2);
        }
    }
}
