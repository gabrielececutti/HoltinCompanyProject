using HoltinData.PersistenceService;
using HoltinModels.Entities;
using HoltinModels.Models;
using HoltinModels.Requests.ClientRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices.LogInService
{
    public class LoginService : ILoginService
    {
        private readonly IClientPersistenceService _clientPersistenceService;

        public LoginService(IClientPersistenceService clientPersistenceService)
        {
            _clientPersistenceService = clientPersistenceService;
        }

        public bool Login(Client client)
        {
            var filter = new ClientByFilterRequest { Email = client.Email , Password = client.Password};
            var clientFind = _clientPersistenceService.GetClientsByFilter(filter);
            if (clientFind.Data != null) return true;
            return false;
        }
    }
}
