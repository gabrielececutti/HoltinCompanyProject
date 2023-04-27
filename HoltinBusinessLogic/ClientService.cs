using HoltinModels.Entities;
using HoltinModels.Requests.ClientRequest;
using HoltinModels.Responses;
using HoltinRepositories;

namespace HoltinBusinessLogic
{
    public class ClientService : IClientRepository
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public DefaultResponse<Client> GetClientById(ClientByIdRequest id)
        {
            return _clientRepository.GetClientById(id);
        }

        public DefaultResponse<List<Client>> GetClientsByFilter(ClientByFilterRequest filter)
        {
            return _clientRepository.GetClientsByFilter(filter);
        }

        public bool Insert(Client client)
        {
            return _clientRepository.Insert(client);
        }

        public bool Update(Client client)
        {
            return _clientRepository.Update(client);
        }

        public bool Delete(ClientByIdRequest id)
        {
            return _clientRepository.Delete(id);
        }
    }
}
