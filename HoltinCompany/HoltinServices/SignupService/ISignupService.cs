using HoltinModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices.SignupService
{
    public interface ISignupService
    {
        public void SignUp(Client client);
    }
}
