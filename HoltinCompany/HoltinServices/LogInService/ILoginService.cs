using HoltinModels.Entities;
using HoltinModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinServices.LogInService
{
    public interface ILoginService
    {
        public bool Login(Client client);
    }
}
