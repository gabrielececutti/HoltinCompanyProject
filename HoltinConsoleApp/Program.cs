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

        var repo = new HotelRepository(dbOptions);
        var service = new HotelService(repo);
        var hotelId = new HotelByIdRequest { Id = 1 };

        var response = service.GetHotelById(hotelId);

        // gestione errori test
        if (response.Errors != null) Console.WriteLine(response.Errors.Length);
        else if (response.Data == default(Hotel)) Console.WriteLine("non è stato trovato hotel");
        else Console.WriteLine(response.Data.Name);

        // popolare tabella Client con una Factory
        var repoClient = new ClientRepository(dbOptions);
        var serviceClient = new ClientService(repoClient);
        var clientFactory = new RandomClientFactory(new Faker<Client>());
        //int i = 0;
        //while (i<1000)
        //{
        //    var client = clientFactory.Create();
        //    serviceClient.Insert(client);
        //    i++;

        //}
        var roomRepository = new RoomRepository(dbOptions);
        var factoryReservations = new RandomReservationFactory (new Faker<Reservation>(), clientFactory, roomRepository, 7, 500, 3000);
        var reservation = factoryReservations.Create();
        Console.WriteLine($"reservationId:{reservation.Id} HotelId:{reservation.HotelId} RoomId:{reservation.RoomId} RoomNumber:{reservation.RoomNumber} ClientId:{reservation.ClientId} Guests:{reservation.Guests} CheckIn:{reservation.CheckIn} CheckOut:{reservation.CheckOut} TotalPrice:{reservation.TotalPrice}");

    }
}