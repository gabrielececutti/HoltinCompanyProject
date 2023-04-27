using HoltinModels.Entities;
using HoltinModels.Requests.ClientRequest;
using HoltinModels.Requests.RoomRequest;
using HoltinModels.Responses;

namespace HoltinServices
{
    public interface IClientService
    {
        public DefaultResponse<Client> GetClientById(ClientByIdRequest id);
        public DefaultResponse<List<Client>> GetClientByFilter(ClientByFilterRequest request);
        public bool Insert(Client client);
        public bool Update(Client client);
        public bool Delete(ClientByIdRequest id);
    }
}
