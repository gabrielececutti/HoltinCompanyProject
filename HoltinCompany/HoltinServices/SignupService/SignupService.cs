using HoltinData.PersistenceService;
using HoltinModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices.SignupService
{
    public class SignupService : ISignupService
    {
        private readonly IClientPersistenceService _clientPersistenceService;

        public SignupService(IClientPersistenceService clientPersistenceService)
        {
            _clientPersistenceService = clientPersistenceService;
        }

        public void SignUp(Client client)
        {
            _clientPersistenceService.Insert(client);
        }
    }
}
