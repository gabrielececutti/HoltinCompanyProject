using HoltinData.PersistenceService;
using HoltinModels.Entities;
using HoltinModels.Requests.ClientRequest;

namespace HoltinAdministratorsServices.AdministratorServicesOnClient
{
    public class AdministratorServiceOnClient : IAdministratorServiceOnClient
    {
        public readonly IClientPersistenceService _clientServicePersistence;

        public AdministratorServiceOnClient(IClientPersistenceService clientServicePersistence)
        {
            _clientServicePersistence = clientServicePersistence;
        }

        public void Delete(ClientByIdRequest id)
        {
            _clientServicePersistence.Delete(id);
        }

        public void Insert(Client client)
        {
            _clientServicePersistence.Insert(client);
        }

        public void Update(Client client)
        {
            _clientServicePersistence.Update(client);
        }
    }
}
