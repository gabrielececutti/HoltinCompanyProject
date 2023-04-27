using HoltinModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.DTO
{
    public class ClientDTO
    {
        public string Name { get; }
        public string Surname { get; }
        public string MobilePhoneNumber { get; }
        public List<Reservation> Reservations { get; set; }
    }
}
