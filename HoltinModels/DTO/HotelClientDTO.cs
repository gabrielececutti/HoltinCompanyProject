using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HoltinModels.DTO
{
    public class HotelClientDTO : ClientDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly DateOfBirth { get; }
        public string TaxIdCode { get; }
        public string Email { get; }
        public bool Fidelity { get; }
        public List<HotelReservationDTO> RoomReservations { get; }

    }
}
