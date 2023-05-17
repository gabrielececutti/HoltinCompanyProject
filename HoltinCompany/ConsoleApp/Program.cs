using Bogus;
using ConsoleApp;
using ConsoleApp.IOC;
using HoltinConsoleApp.Factories;
using HoltinData;
using HoltinModels.DiscountCalculator;
using HoltinModels.Entities;
using HoltinModels.Requests;
using HoltinServices.ClientService;
using HoltinServices.HotelService;
using HoltinServices.LogInService;
using HoltinServices.ReservationService;
using HoltinServices.RoomService;
using HoltinServices.SignupService;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Channels;


var host = StartUp.CreateHostBuilder().Build();

var hotelService = host.Services.GetRequiredService<IHotelService>();
var roomService = host.Services.GetRequiredService<IRoomService>();
var clientService = host.Services.GetRequiredService<IClientService>();
var reservstionService = host.Services.GetRequiredService<IReservationService>();
var bookingService = host.Services.GetService<IBookingService>();
var loginService = host.Services.GetRequiredService<ILoginService>();
var signupService = host.Services.GetRequiredService<ISignupService>();
var randomClientFactory = new RandomClientFactory(new Faker<Client>());

var app = new UserApp(hotelService, reservstionService, roomService,loginService, signupService, clientService, bookingService, randomClientFactory);
app.Run();