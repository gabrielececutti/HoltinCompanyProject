using HoltinData.QueriesBuilders;
using HoltinModels.Entities;
using HoltinModels.Requests.ClientRequest;
using HoltinModels.Responses;
using HoltinRepositories;
using System.Data;
using System.Data.SqlClient;

namespace HoltinData.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DatabaseOption _dbOptions;
        public ClientRepository(DatabaseOption dbOptions) 
        {
            _dbOptions = dbOptions;
        }

        public DefaultResponse<Client> GetClientById(ClientByIdRequest id)
        {
            var query = "SELECT * FROM Client WHERE Id = @id";
            var parameter = new Dictionary<string, object>() { {"@id", id.Id} };
            var response = GetClients(query, parameter);
            return new DefaultResponse<Client>
            {
                Data = response.Data.FirstOrDefault(), // creo un oggetto inutile
                Errors = response.Errors
            };
        }

        public DefaultResponse<List<Client>> GetClientsByFilter(ClientByFilterRequest filter)
        {
            var result = ClientQueryBuilder
                .Create()
                .WithName(filter.Name)
                .WithSurname(filter.Surname)
                .WithBirthDate(filter.BirthDate)
                .WithTaxiIdCode(filter.TaxIdCode)
                .WithPhoneNumber(filter.PhoneNumber)
                .WithEmail(filter.Email)
                .WithPassword(filter.Password)
                .WithFidelity(filter.Fidelity)
                .Build();
            var response = GetClients(result.Query, result.Parameters);
            return new DefaultResponse<List<Client>>
            {
                Data = response.Data,
                Errors = response.Errors
            };                             
        }

        public DefaultResponse<bool> Delete(ClientByIdRequest id)
        {
            var query = "DELETE FROM Client WHERE Id = @id";
            var parameter = new Dictionary<string, object> { { "id", id.Id} };
            var response = ExecuteQuery(query, parameter);
            return new DefaultResponse<bool>
            {
                Data = response.Data == 0 ? false : true,
                Errors = response.Errors
            };
        }

        public DefaultResponse<bool> Insert(Client client)
        {
            var query = @"INSERT INTO Client  (Name, Surname, BirthDate, TaxIdCode, PhoneNumber, Email, Password, Fidelity)
                          VALUES
                          (@name, @surname, @birthDate, @taxIdCode, @phoneNumber, @email, @password, @fidelity)";
            var parameters = new Dictionary<string, object>
            {
                {"@name", client.Name},
                {"@surname", client.Surname},
                {"@birthDate", client.BirthDate},
                {"@taxIdCode", client.TaxIdCode},
                {"@phoneNumber", client.PhoneNumber},
                {"@email", client.Email},
                {"@password", client.Password},
                {"@fidelity", client.Fidelity}
            };
            var response = ExecuteQuery(query, parameters);
            return new DefaultResponse<bool>
            {
                Data = response.Data == 0 ? false : true,
                Errors = response.Errors
            };
        }

        public DefaultResponse<bool> Update(Client client)
        {
            var query = @"UPDATE Client (Name, Surname, BirthDate, TaxIdCode, PhoneNumber, Email, Password, Fidelity)
                          SET
                          Name = @name,
                          Surname = @surname,
                          BirthDate = @birthDate,
                          TaxIdCode = @taxIdCode,
                          PhoneNumber = @phoneNumber,
                          Email = @email,
                          Password = @password,
                          Fidelity = @fidelity
                          WHERE Id = @id";
            var parameters = new Dictionary<string, object>
            {
                {"@name", client.Name },
                {"@surname", client.Surname },
                {"@birthDate", client.BirthDate },
                {"@taxidCode", client.TaxIdCode },
                {"@phoneNumber", client.PhoneNumber },
                {"@email", client.Email },
                {"@password", client.Password },
                {"@Fidelity", client.Fidelity }
            };
            var response = ExecuteQuery(query, parameters);
            return new DefaultResponse<bool>
            {
                Data = response.Data == 0 ? false : true,
                Errors = response.Errors
            };
        }

        private DefaultResponse<List<Client>> GetClients (string query, Dictionary<string, object> parameters)
        {
            var result = new DefaultResponse<List<Client>>();
            try
            {
                using var connection = new SqlConnection(_dbOptions.ConnectionString);
                using var command = new SqlCommand(query, connection);
                connection.Open();
                var sqlParameters = parameters.Select(p => new SqlParameter(p.Key, p.Value)).ToArray();
                command.Parameters.AddRange(sqlParameters);
                using var reader = command.ExecuteReader();
                var clients = new List<Client>();
                while (reader?.Read() == true)
                {
                    var client = new Client()
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        Surname = reader.GetString("Surname"),
                        BirthDate = reader.GetDateTime("BirthDate"),
                        TaxIdCode = reader.GetString("TaxIdCode"),
                        PhoneNumber = reader.GetString("PhoneNumber"),
                        Email = reader.GetString("Email"),
                        Password = reader.GetString("Password"),
                        Fidelity = reader.GetBoolean("Fidelity")
                    };
                    clients.Add(client);
                }
                result.Data = clients;
            } catch (Exception ex) 
            {
                // si potrebbe gestire l'eccezione di accesso ai dati (waiting ecc)
                result.Errors = new string[] {ex.Message};
                result.Data = new List<Client>();
            }
            return result;
        }

        private DefaultResponse<int> ExecuteQuery (string query, Dictionary<string, object> parameters)
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
                // si potrebbe gestire l'eccezione di accesso ai dati (waiting ecc)
                response.Errors = new string[] { ex.Message };
            }
            return response;
        }
    }
}
