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
        public DefaultResponse<bool> Insert(Client client);
        public DefaultResponse<bool> Update(Client client);
        public DefaultResponse<bool> Delete(ClientByIdRequest id);
    }
}
