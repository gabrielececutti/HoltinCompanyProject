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

namespace HoltinCompanyDomain.Cliente
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateOnly DataDiNascita { get; set; } 
        public string CodiceFiscale { get; set; } 
        public string NumeroDiCellulare { get; set; }
        public string Email { get; set; }
        public bool Fedeltà { get;  set; }
  //      public List<Prenotazione> PrenotazioniEffettuate { get; private set; }

        private const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{7})$";

        public Cliente(string nome, string cognome, DateOnly dataDiNascita, string codiceFiscale, string numeroDiCellulare, string email)
        {
            Nome = nome ?? throw new Exception("nome is null");
            Cognome = cognome ?? throw new Exception("cognome is null");
            DataDiNascita = dataDiNascita;
            if (codiceFiscale.Length != 16 || codiceFiscale is null)
            {
                throw new Exception("codice fiscale invalid");
            }else {
                CodiceFiscale = codiceFiscale;
            }
            if (!PhoneNbrIsValid(numeroDiCellulare))
            {
                throw new Exception("numero di cellulare invalid");
            }else
            {
                NumeroDiCellulare = numeroDiCellulare;
            }
            if (!EmailIsValid(email))
            {
                throw new Exception("email invalid");
            }else
            {
                Email = email;
            }
            Fedeltà = false ;
           // PrenotazioniEffettuate = new List<Prenotazione> ();
        }

        public Cliente ()
        {

        }

        private bool EmailIsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool PhoneNbrIsValid(string number)
        {
            if (number != null) return Regex.IsMatch(number, motif);
            else return false;
        }
    }
}
