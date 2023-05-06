using HoltinData.QueriesBuilders;
using HoltinModels.Entities;
using HoltinModels.Requests.ReservationRequest;
using HoltinModels.Responses;
using HoltinRepositories;
using System.Data;
using System.Data.SqlClient;

namespace HoltinData.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DatabaseOption _dbOptions;
        public ReservationRepository(DatabaseOption databaseOptions)
        {
            _dbOptions = databaseOptions;
        }

        public DefaultResponse<Reservation> GetReservationById(ReservationByIdRequest id)
        {
            var query = @"SELECT * FROM Reservation WHERE Id = @id";
            var parameter = new Dictionary<string, object>() { { "id", id.Id } };
            var response = GetReservations(query, parameter);
            return new DefaultResponse<Reservation>()
            {
                Data = response.Data.FirstOrDefault(),
                Errors = response.Errors
            };
        }

        public DefaultResponse<List<Reservation>> GetReservationsByFilter(ReservationByFilterRequest filter)
        {
            var result = ReservationQueryBuilder
                .Create()
                .WithHotelId(filter.HotelId)
                .WithRoomId(filter.RoomId)
                .WithClientId(filter.ClientId)
                .WithGuests(filter.Guests)
                .WithCheckIn(filter.CheckIn)
                .WithCheckOut(filter.CheckOut)
                .WithTotalPrice(filter.TotalPrice)
                .Build();
            var response = GetReservations(result.Query, result.Parameters);
            return new DefaultResponse<List<Reservation>>()
            {
                Data = response.Data,
                Errors = response.Errors
            };
        }

        public DefaultResponse<bool> Insert(Reservation reservation)
        {
            var query = @$"INSERT INTO Reservation (Id, HotelId, RoomId, RoomNumber, ClientId, Guests, CheckIn, CheckOut, TotalPrice)
                          VALUES 
                          (@id, @hotelId, @roomId, @roomNumber, @clientId, @guests, @checkIn, @checkOut, @totalPrice)";
            var parameters = new Dictionary<string, object>()
            {
                {"@id", reservation.Id },
                {"@hotelId", reservation.HotelId},
                {"@roomId", reservation.RoomId},
                {"@roomNumber", reservation.RoomNumber},
                {"@clientId", reservation.ClientId},
                {"@guests", reservation.Guests},
                {"@checkIn", reservation.CheckIn},
                {"@checkOut", reservation.CheckOut},
                {"@totalPrice", reservation.TotalPrice}
            };
            var response = ExecuteQuery(query, parameters);
            return new DefaultResponse<bool>
            {
                Data = response.Data == 0 ? false : true,
                Errors = response.Errors
            };
        }

        public DefaultResponse<bool> Delete(ReservationByIdRequest id)
        {
            var query = "DELETE FROM Reservation WHERE Id = @id";
            var parameter = new Dictionary<string, object>() { { "@id", id.Id } };
            var response = ExecuteQuery(query, parameter);
            return new DefaultResponse<bool>
            {
                Data = response.Data == 0 ? false : true,
                Errors = response.Errors
            };
        }

        private DefaultResponse<List<Reservation>> GetReservations(string query, Dictionary<string, object> parameters)
        {
            var result = new DefaultResponse<List<Reservation>>();
            try
            {
                using var connection = new SqlConnection(_dbOptions.ConnectionString);
                using var command = new SqlCommand(query, connection);
                var sqlParameters = parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToArray();
                command.Parameters.AddRange(sqlParameters);
                connection.Open();
                using var reader = command.ExecuteReader();
                var reservations = new List<Reservation>();
                while (reader?.Read() == true)
                {
                    var reservation = new Reservation()
                    {
                        Id = reader.GetInt32("id"),
                        HotelId = reader.GetInt32("HotelId"),
                        RoomId = reader.GetInt32("RoomId"),
                        RoomNumber = reader.GetInt32("RoomNumber"),
                        ClientId = reader.GetInt32("ClientId"),
                        Guests = reader.GetInt32("Guests"),
                        CheckIn = reader.GetDateTime("CheckIn"),
                        CheckOut = reader.GetDateTime("CheckOut")
                    };
                    reservations.Add(reservation);
                }
                result.Data = reservations;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                result.Data = new List<Reservation>();
            }
            return result;
        }

        public DefaultResponse<int> ExecuteQuery(string query, Dictionary<string, object> parameters)
        {
            var response = new DefaultResponse<int>();
            try
            {
                using var connection = new SqlConnection(_dbOptions.ConnectionString);
                using var command = new SqlCommand(query, connection);
                connection.Open();
                var sqlParameters = parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToArray();
                command.Parameters.AddRange(sqlParameters);
                response.Data = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                response.Errors = new string[] { ex.Message };
            }
            return response;
        }
    }
}
