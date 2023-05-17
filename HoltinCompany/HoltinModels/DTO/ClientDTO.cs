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
        public int Id { get; } 
        public string Name { get; }
        public string Surname { get; }
        public DateTime BirthDate { get; }
        public string TaxidCode { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public List<ReservationDTO> Reservations { get; set; }
    }
}
