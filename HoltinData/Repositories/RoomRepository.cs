using HoltinData.QueriesBuilders;
using HoltinModels.Entities;
using HoltinModels.Requests.RoomRequest;
using HoltinModels.Responses;
using HoltinRepositories;
using System.Data;
using System.Data.SqlClient;

namespace HoltinData.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DatabaseOption _databaseOptions;

        public RoomRepository (DatabaseOption databaseOptions)
        {
            _databaseOptions = databaseOptions;
        }

        public DefaultResponse<Room> GetRoomById(RoomByIdRequest id)
        {
            var query = "SELECT * FROM Room WHERE Id = @id";
            var parameter = new Dictionary<string, object> { { "@id", id.Id } };
            var result = GetRooms(query, parameter);
            return new DefaultResponse<Room>
            {
                Data = result.Data.FirstOrDefault(),
                Errors = result.Errors
            };
        }

        public DefaultResponse<List<Room>> GetRoomsByFilter(RoomByFilterRequest filter)
        {
            var result = RoomQueryBuilder
                .Create()
                .WithHotelId (filter.HotelId)
                .WithGuests (filter.Guests)
                .WithSingleBeds (filter.SingleBeds)
                .WithDoubleBeds (filter.DoubleBeds)
                .WithWiFi (filter.WiFi)
                .WithRoomService (filter.RoomService)
                .WithAirConditioning(filter.AirConditioning)
                .WithTv(filter.AirConditioning)
                .WithNightPriceMax(filter.NigthPriceMax)
                .WithNightPriceMin(filter.NigthPriceMin)
                .Build();
            var response = GetRooms(result.Query, result.Parameters);
            return new DefaultResponse<List<Room>>()
            {
                Data = response.Data,
                Errors = response.Errors
            };
        }

        public DefaultResponse<bool> Insert(Room room)
        {
            var query = @"INSERT INTO Room  (HotelId, Number, Booked, SingleBeds, DoubleBeds, WiFi, RoomService, AirConditioning, TV, NightPrice)
                          VALUES
                          (@hotelId, @number, @booked, @singleBeds, @doubleBeds, @wifi, @roomService, @airConditioning, @tv, @nightPrice)";
            var parameters = new Dictionary<string, object>
            {
                {"@hotelId", room.HotelId},
                {"@number", room.Number},
                {"@booked", room.Booked},
                {"@singleBeds", room.SingleBeds},
                {"@doubleBeds", room.DoubleBeds},
                {"@wifi", room.WiFi},
                {"@roomService", room.RoomService},
                {"@airConditioning", room.AirConditioning},
                {"@tv", room.Tv},
                {"@nightPrice", room.NightPrice}
            };
            var response = ExecuteQuery(query, parameters);
            return new DefaultResponse<bool>
            {
                Data = response.Data == 0 ? false : true,
                Errors = response.Errors
            };
        }

        public DefaultResponse<bool> Update(Room room)
        {
            var query = @"UPDATE Room
                          SET
                          HotelId = @hotelId,
                          Number = @number,
                          Booked = @booked,
                          SingleBeds = @singleBeds,
                          DoubleBeds = @doubleBeds,
                          Wifi = @wifi,
                          RoomService = @roomService,
                          AirConditioning = @airConditioning,
                          TV = @tv,
                          NightPrice = @nightPrice
                          WHERE Id = @id
                           ";
            var parameters = new Dictionary<string, object>
            {
                {"@id", room.Id},
                {"@hotelId", room.HotelId},
                {"@number", room.Number},
                {"@booked", room.Booked},
                {"@singleBeds", room.SingleBeds},
                {"@doubleBeds", room.DoubleBeds},
                {"@wifi", room.WiFi},
                {"@roomService", room.RoomService},
                {"@airConditioning", room.AirConditioning},
                {"@tv", room.Tv},
                {"@nightPrice", room.NightPrice}
            };
            var response = ExecuteQuery(query, parameters);
            return new DefaultResponse<bool>
            {
                Data = response.Data == 0 ? false : true,
                Errors = response.Errors
            };
        }

        public DefaultResponse<bool> Delete(RoomByIdRequest id)
        {
            var query = "DELETE FROM Room WHERE Id = @id";
            var parameter = new Dictionary<string, object> { { "@id", id.Id } };
            var response = ExecuteQuery(query, parameter);
            return new DefaultResponse<bool>
            {
                Data = response.Data == 0 ? false : true,
                Errors = response.Errors
            };
        }

        private DefaultResponse<List<Room>> GetRooms (string query, Dictionary<string, object> parameters)
        {
            var result = new DefaultResponse<List<Room>>();
            try
            {
                using var connection = new SqlConnection(_databaseOptions.ConnectionString);
                using var command = new SqlCommand (query, connection);
                connection.Open ();
                var sqlParameters = parameters.Select(p => new SqlParameter(p.Key, p.Value)).ToArray();
                command.Parameters.AddRange(sqlParameters);
                using var reader = command.ExecuteReader();
                var rooms = new List<Room>();
                while (reader?.Read() == true)
                {
                    var room = new Room()
                    {
                        Id = reader.GetInt32("Id"),
                        HotelId = reader.GetInt32("HotelId"),
                        Number = reader.GetInt32("Number"),
                        Booked = reader.GetBoolean("Booked"),
                        SingleBeds = reader.GetInt32("SingleBeds"),
                        DoubleBeds = reader.GetInt32("DoubleBeds"),
                        WiFi = reader.GetBoolean("WiFi"),
                        RoomService = reader.GetBoolean("RoomService"),
                        AirConditioning = reader.GetBoolean("AirConditioning"),
                        Tv = reader.GetBoolean("TV"),
                        NightPrice = reader.GetDecimal("NightPrice")
                    };
                    rooms.Add(room);
                }
                result.Data = rooms;
            }catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                result.Data = new List<Room>();
            }
            return result;
        }

        private DefaultResponse<int> ExecuteQuery (string query, Dictionary<string, object> parameters)
        {
            var response = new DefaultResponse<int>();
            try
            {
                using var connection = new SqlConnection(_databaseOptions.ConnectionString);
                using var command = new SqlCommand(query, connection);
                connection.Open();
                var sqlParameters = parameters.Select(p => new SqlParameter(p.Key, p.Value)).ToArray();
                command.Parameters.AddRange(sqlParameters);
                response.Data = command.ExecuteNonQuery();

            }catch (Exception ex)
            { 
                response.Errors = new string[] { ex.Message }; 
            }
            return response;
        }
    }
}
