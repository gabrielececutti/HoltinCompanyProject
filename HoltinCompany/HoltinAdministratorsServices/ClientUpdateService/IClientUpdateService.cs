using HoltinModels.Entities;
using HoltinModels.Requests.ClientRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinAdministratorsServices.AdministratorServicesOnClient
{
    public interface IClientUpdateService
    {
        public void Insert(Client client);
        public void Delete(ClientByIdRequest id);
        public void Update(Client client);
    }
}
