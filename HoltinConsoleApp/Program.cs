/*
L’azienda “Holtin” dispone di vari alberghi in varie città. Ogni albergo offre stanze e servizi diversi. Le stanze sono singole, doppie o triple. Le Stanze hanno dei servizi.
Ogni albergo è a 3, 4 o 5 stelle, offre 1 o più ristoranti al suo interno ( può prenotare un tavolo anche un cliente non dell'hotel, i clienti dell'hotel hanno i tavoli automaticmanete riservati), 0 o più sale convegno, eventuale piscina,
eventuale palestra, eventuali massaggi, eventuali saune. Ovviamente l’albergo è sito in una certa località, che può essere di campagna, città, al mare o in montagna.

Si necessita di un'APP che consenta di implementare queste operazioni principali: 

• vedere tutti gli hotel della compagnia (quelli che hanno stanze libere e quelli già tutti al completo).

• prenotazione di un tavolo al ristorante da un cliente non dell'hotel.

• poter cercare quali alberghi di certe caratteristiche hanno disponibilità di stanze con certe caratteristiche.

• per gli alberghi trovati occorre sapere il prezzo previsto per la prenotazione, tenendo conto del numero di ospiti dell’eventuale prenotazione 
  (es. un singolo o una famiglia di 5 persone), della stanza, dai servizi scelti e da eventuali sconti.

• Confermare la prenotazione restituendo un file testo i dettagli della prenotazione.


NOTE:
    - tutti gli hotel, clienti e le prenotazioni sono salvate su un database locale.
    - politche sconti:
                      fedeltà cliente: dalla quinta prenotazione sconto del 4%.
                      periodo dell'anno: da settembre a fine maggio sconto del 40%.
                      durata prenotazione: >= di 5 giorni, sconto del 6%.

*/
using Bogus;
using HoltinBusinessLogic;
using HoltinData;
using HoltinData.Repositories;
using HoltinModels.Entities;
using HoltinModels.Requests.HotelRequest;
using HoltinServices;
using System.Security.Cryptography.X509Certificates;

namespace HoltinCompany;
public class Program
{
    public static void Main(string[] args)
    {
        //Console.WriteLine("Hello world");
        //Client clienteProva = new Client("gabri", "cec", new DateOnly(2001, 9, 4), "CCTGR4503VGAE43G", "012.345.1234567", "gabrielececutti@gmail.com"); // cliente valido

        // generazione di 1000 clienti random da inserire nel database

        //var faker = new Faker("it");
        //var clienti = new Faker<Client>()
        //    .RuleFor(c => c.Id, f => f.IndexFaker + 1)
        //    .RuleFor(c => c.Nome, f => f.Name.FirstName())
        //    .RuleFor(c => c.Cognome, f => f.Name.LastName())
        //    .RuleFor(c => c.DataDiNascita, f => DateOnly.FromDateTime(f.Person.DateOfBirth))
        //    .RuleFor(c => c.CodiceFiscale, f => f.Random.AlphaNumeric(16))
        //    .RuleFor(c => c.NumeroDiCellulare, f => f.Person.Phone)
        //    .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome, c.Cognome))
        //    .RuleFor(c => c.Fedeltà, f => f.Random.Bool(0.3f))
        //    .Generate(1000);
        //Console.WriteLine(clienti);

        //foreach (var client in clienti)
        //{
        //    Console.WriteLine($"id: {client.Id}\n" +
        //        $"nome: {client.Nome}\n" +
        //        $"cognome: {client.Cognome}\n" +
        //        $"data di nascita: {client.DataDiNascita}\n" +
        //        $"codice fiscale: {client.CodiceFiscale}\n" +
        //        $"numero di cellulare: {client.NumeroDiCellulare}\n" +
        //        $"email: {client.Email}\n" +
        //        $"fedeltà: {client.Fedeltà}\n" + 
        //        $"Prenotazioni: {client.Prenotazioni.Count}");
        //}
        var connectionString = @"Server=DESKTOP-476F63V\SQLEXPRESS; Database=HoltinCompany; Integrated Security=true; TrustServerCertificate=True";
        var dbOptions = new DatabaseOption(connectionString);
        var repo = new HotelRepository();
        var servizio = new HotelService(repo);
        var id = new HotelByIdRequest () { Id = 1 };
        var result = servizio.GetHotelById(id);
        Console.WriteLine($"{result.Data.Id} {result.Data.Name} {result.Data.City}");
    }
}