using HoltinData.Queries;
using HoltinModels.Entities;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Responses;
using HoltinRepositories;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace HoltinData.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DatabaseOption _dbOptions;
        public HotelRepository(DatabaseOption databaseOptions) 
        {
            _dbOptions = databaseOptions;
        }
        public DefaultResponse<Hotel> GetHotelById(HotelByIdRequest id)
        {
            var query = @"SELECT * FROM Hotel WHERE Id = @id";
            var parameter = new Dictionary<string, object>(){{ "id", id.Id } };
            var response = GetHotels(query, parameter);
            return new DefaultResponse<Hotel>()
            {
                Data = response.Data.First(),
                Errors = response.Errors
            };
        }

        public DefaultResponse<List<Hotel>> GetHotelsByFilter(HotelByFilterRequest filter) 
        {
            var result = HotelQueryBuilder
                .Create()
                .WithName(filter.Name)
                .WithCity(filter.City)
                .Build();
            var response = GetHotels(result.Query, result.Parameters);
            return new DefaultResponse<List<Hotel>>()
            {
                Data = response.Data,
                Errors = response.Errors
            };
        }

        public bool Insert(Hotel hotel)
        {
            var query = @$"INSERT INTO Hotel (Name, City)
                          VALUES 
                          (@name, @city)";
            var parameters = new Dictionary<string, object>()
            {
                {"@name", hotel.Name},
                {"@city", hotel.City}
            };
            var response = ExecuteQuery(query, parameters);
            if (response.Errors != null || response.Data==0) { return false; }
            return false;
        }

        public bool Update(Hotel hotel)
        {
            var query = @"UPDATE Hotel 
                          SET
                          Name = @name,
                          City = @city
                          WHERE Id = @id";
            var parameters = new Dictionary<string, object>()
            {
                {"@id", hotel.Id },
                {"@name", hotel.Name },
                {"@city", hotel.City }
            };
            var response = ExecuteQuery(query, parameters);
            if (response.Errors != null || response.Data==0) { return false; }
            return true;
        }

        public bool Delete(HotelByIdRequest id)
        {
            var query = "DELETE FROM Hotel WHERE Id = @id";
            var parameter = new Dictionary<string, object>() { { "@id", id.Id } };
            var response = ExecuteQuery(query, parameter);
            if (response.Errors != null || response.Data== 0) { return false; }
            return true;
        }

        private DefaultResponse<List<Hotel>> GetHotels(string query, Dictionary<string, object> parameters)
        {
            var result = new DefaultResponse<List<Hotel>>();
            try
            {
                using var connection = new SqlConnection(_dbOptions.ConnectionString);
                using var command = new SqlCommand(query, connection);
                var sqlParameters = parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToArray();
                command.Parameters.AddRange(sqlParameters);
                connection.Open();
                using var reader = command.ExecuteReader();
                var hotels = new List<Hotel>();
                while (reader?.Read() == true)
                {
                    var hotel = new Hotel()
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        City = reader.GetString("City")
                    };
                    hotels.Add(hotel);
                }
                result.Data = hotels;
            }
            catch (SqlException ex)
            {
                var error = ex.Message;
                result.Errors = new string[] { error };
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
            } catch(SqlException ex)
            {
                response.Errors = new string[] { ex.Message };
            }
            return response;
        }
    }
}
