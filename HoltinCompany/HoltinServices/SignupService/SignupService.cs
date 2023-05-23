using HoltinData.PersistenceService;
using HoltinModels.Entities;
using HoltinModels.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validators.EmailValidator;
using Validators.PasswordValidator;

namespace HoltinServices.SignupService
{
    public class SignupService : ISignupService
    {
        private readonly IClientPersistenceService _clientPersistenceService;
        private readonly IEmailValidator _emailValidator;
        private readonly IPasswordValidator _passwordValidator;

        public SignupService(IClientPersistenceService clientPersistenceService, IEmailValidator emailValidator, IPasswordValidator passwordValidator)
        {
            _clientPersistenceService = clientPersistenceService;
            _emailValidator = emailValidator;
            _passwordValidator = passwordValidator;
        }

        public void SignUp(Client client)
        {
            if (!_emailValidator.IsValid(client.Email).Valid)
            {
                throw new NotValidEmailException();
            };
            if (!_passwordValidator.IsValid(client.Password).Valid)
            {
                throw new NotValidPasswordException();
            }
            _clientPersistenceService.Insert(client);
        }
    }
}
