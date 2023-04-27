using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinModels.Entities
{
    public class Client
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public DateTime BirthDate { get; init; }
        public string TaxIdCode { get; init; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Fidelity { get; set; }
    }
}
