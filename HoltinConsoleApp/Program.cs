using Bogus;
using HoltinBusinessLogic;
using HoltinConsoleApp.Factories;
using HoltinData;
using HoltinData.Repositories;
using HoltinModels.Entities;

namespace HoltinCompany;
public class Program
{
    public static void Main(string[] args)
    {

        //var client = factory.Create();


        //    Console.WriteLine($"id: {client.Id}\n" +
        //        $"nome: {client.Name}\n" +
        //        $"cognome: {client.Surname}\n" +
        //        $"data di nascita: {client.BirthDate}\n" +
        //        $"codice fiscale: {client.TaxIdCode}\n" +
        //        $"numero di cellulare: {client.PhoneNumber}\n" +
        //        $"email: {client.Email}\n" +
        //        $"fedeltà: {client.Fidelity}\n");

        var faker = new Faker<Client>();
        var factory = new RandomClientFactory(faker);

        var connectionString = @"Server=DESKTOP-476F63V\SQLEXPRESS; Database=HoltinCompany; Integrated Security=true; TrustServerCertificate=True";
        var dbOptions = new DatabaseOption(connectionString);

        var repository = new ClientRepository(dbOptions);
        var servizio = new ClientService(repository);

        //INSERITI NEL DB
        //var i = 0;
        //while (i < 1000)
        //{
        //    servizio.Insert(factory.Create());
        //    i++;
        //}


    }
}