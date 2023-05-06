using Bogus;
using HoltinBusinessLogic;
using HoltinConsoleApp.Factories;
using HoltinData;
using HoltinData.Repositories;
using HoltinModels.Entities;
using HoltinModels.Factories;
using HoltinModels.Requests.ClientRequest;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Requests.ReservationRequest;

namespace HoltinCompany;
public class Program
{
    public static void Main(string[] args)
    {

        var connectionString = @"Server=DESKTOP-476F63V\SQLEXPRESS; Database=HoltinCompany; Integrated Security=true; TrustServerCertificate=True";
        var dbOptions = new DatabaseOption(connectionString);


        // popolare tabella Client con una Factory
        var repoClient = new ClientRepository(dbOptions);
        var serviceClient = new ClientService(repoClient);
        var clientFactory = new RandomClientFactory(new Faker<Client>());
        //int count = 0;
        //while (count <1000)
        //{
        //    var client = clientFactory.Create();
        //    serviceClient.Insert(client);
        //    count++;
        //}


        // popolare tabella reservation
        var roomRepository = new RoomRepository(dbOptions);
        var factoryReservations = new RandomReservationFactory(new Faker<Reservation>(), clientFactory, roomRepository, 3000);
        var reservationRepo = new ReservationRepository(dbOptions);
        var reservationService = new ReservationService(reservationRepo);
        int i = 0;
        //while (i< 200) 
        //{
        //        var reservation = factoryReservations.Create();
        //        reservationService.Insert(reservation);
        //        Console.WriteLine($"reservationId:{reservation.Id} HotelId:{reservation.HotelId} RoomId:{reservation.RoomId} RoomNumber:{reservation.RoomNumber} ClientId:{reservation.ClientId} Guests:{reservation.Guests} CheckIn:{reservation.CheckIn} CheckOut:{reservation.CheckOut} TotalPrice:{reservation.TotalPrice}");
        //    i++;
        //}


        // clienti solo risotrante
        var clientOnlyRestaurant = new Client
        {
            Id = 2,
            Name = "Mario",
            Surname = "Rossi",
            BirthDate = new DateTime(2000, 5, 1),
            PhoneNumber = "248.535.6119"
        };
    }
}