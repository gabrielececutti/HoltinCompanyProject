using HoltinModels.Entities;
using HoltinModels.Requests.HotelRequest;
using HoltinModels.Responses;
using HoltinRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace HoltinData.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        public const string connectionString = @"Server=DESKTOP-476F63V\SQLEXPRESS; Database=HoltinCompany; Integrated Security=true; TrustServerCertificate=True";
        public DefaultResponse<Hotel> GetHotelById(HotelByIdRequest id)
        {
            var query = @"select * from Hotel where Id = @id";
            var hotel = GetHotels(query, "@id", id.Id).Data.First();

            DefaultResponse<Hotel> result = new DefaultResponse<Hotel>() { Data = hotel };
            return result;
        }

        public DefaultResponse<List<Hotel>> GetHotelsByFilter(HotelByFilterRequest filter) // Name = "dcfr" City = null
        {
            throw new NotImplementedException();
        }

        private DefaultResponse<List<Hotel>> GetHotels (string query, string parameter, object value)
        {
            var result = new DefaultResponse<List<Hotel>>();
            try
            {
                var connection = new SqlConnection(connectionString);
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue(parameter, value);
                connection.Open();
                using var reader = command.ExecuteReader();
                var hotels = new List<Hotel>();
                while (reader?.Read() == true)
                {
                    var hotel = new Hotel()
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Hotel.Name"), // why ?
                        City = reader.GetString("Hotel.City")
                    };
                    hotels.Add(hotel);
                }
                result.Data = hotels;
            } catch (SqlException ex)
            {
                var error = ex.Message;
                result.Errors = new string[] { error };
            }
          return result;
        }

        public DefaultResponse<List<Hotel>> ExecuteQuery (string query, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }



  
    }
}
