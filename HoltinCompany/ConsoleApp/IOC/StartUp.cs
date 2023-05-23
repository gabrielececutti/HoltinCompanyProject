using System;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using HoltinData;
using HoltinRepositories;
using HoltinData.Repositories;
using HoltinData.PersistenceService;
using HoltinModels.DiscountCalculator;
using HoltinServices.Helpers;
using HoltinServices.HotelService;
using HoltinServices.RoomService;
using HoltinServices.ClientService;
using HoltinServices.ReservationService;
using HoltinConsoleApp.Factories;
using HoltinModels.Entities;
using Bogus;
using HoltinModels.Factories;
using Validators.EmailValidator;
using Validators.PasswordValidator;
using HoltinServices.SignupService;
using HoltinServices.LogInService;
using HoltinAdministratorsServices.AdministratorServicesOnRoom;

namespace ConsoleApp.IOC
{
    public static class StartUp
    {
        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, service) =>
                {
                    string fileName = "appsettings.json";
                    string json = File.ReadAllText(fileName);
                    var appSettings = JsonConvert.DeserializeObject<AppSettings>(json);
                    service.AddSingleton(appSettings);

                    var databaseOption = new DatabaseOption(appSettings.ConnectionStrings.MyConnectionString);
                    service.AddSingleton<IHotelRepository>(new HotelRepository(databaseOption));
                    service.AddSingleton<IRoomRepository>(new RoomRepository(databaseOption));
                    service.AddSingleton<IClientRepository>(new ClientRepository(databaseOption));  
                    service.AddSingleton<IReservationRepository>(new ReservationRepository(databaseOption));

                    service.AddSingleton<IHotelPersistenceService, HotelPersistenceService>();
                    service.AddSingleton<IRoomPersistenceService, RoomPersistenceService>();
                    service.AddSingleton<IClientPersistenceService, ClientPersistenceService>();
                    service.AddSingleton<IReservationPersistenceService, ReservationPersistenceService>();

                    var discountCalculator = new SetDiscountCalculator(appSettings.DiscountPolicies).GetCalculator();
                    service.AddSingleton(new ReservationPriceCalculator(discountCalculator));

                    service.AddSingleton<IEmailValidator>(new EmailValidator(appSettings.EmailPattern));
                    service.AddSingleton(SetUpPasswordChain.SetUpChain());

                    service.AddSingleton<IHotelService, HotelService>();
                    service.AddSingleton<IRoomService, RoomService>();
                    service.AddSingleton<IClientService, ClientService>();
                    service.AddSingleton<IReservationService, ReservationService>();
                    service.AddSingleton<IBookingService, BookingServices>();
                    service.AddSingleton<ISignupService, SignupService>();
                    service.AddSingleton<ILoginService, LoginService>();
                    service.AddSingleton<IRoomUpdateService, RoomUpdateService>();
                });
        }

    }
}

