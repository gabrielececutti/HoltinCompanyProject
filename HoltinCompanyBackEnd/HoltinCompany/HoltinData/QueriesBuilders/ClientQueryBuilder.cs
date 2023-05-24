using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HoltinData.QueriesBuilders
{
    public class ClientQueryBuilder
    {
        private const string MainQuery = $"SELECT * FROM Client {WherePlaceholder}";

        private const string WherePlaceholder = "/***WHERE***/";

        private const string WhereName = $"Name = {NameParameterName}";
        private const string WhereSurname = $"Surname = {SurnameParameterName}";
        private const string WhereBirthDate = $"BirthDate = {BirthDateParameterName}";
        private const string WhereTaxIdCode = $"TaxIdCode = {TaxidCodeParameterName}";
        private const string WherePhoneNumber = $"PhoneNumber = {PhoneNumberParameterName}";
        private const string WhereEmail = $"Email = {EmailParameterName}";
        private const string WherePassword = $"Password = {PasswordParameterName}";
        private const string WhereFidelity = $"Fidelity = {FidelityParameterName}";

        private const string NameParameterName = "@name";
        private const string SurnameParameterName = "@surname";
        private const string BirthDateParameterName = "@birthDate";
        private const string TaxidCodeParameterName = "@taxIdCode";
        private const string PhoneNumberParameterName = "@phoneNumber";
        private const string EmailParameterName = "@email";
        private const string PasswordParameterName = "@password";
        private const string FidelityParameterName = "@fidelity";

        private List<string> Wheres { get; set; }
        private Dictionary<string, object> QueryParameters { get; set; }

        private ClientQueryBuilder() 
        { 
            Wheres = new List<string>();
            QueryParameters = new Dictionary<string, object>();
        }

        public static ClientQueryBuilder Create() => new();

        public ClientQueryBuilder WithName (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return this;
            }
            Wheres.Add(WhereName);
            QueryParameters.Add(NameParameterName, name);
            return this;
        }

        public ClientQueryBuilder WithSurname (string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
            {
                return this;
            }
            Wheres.Add(WhereSurname);
            QueryParameters.Add(SurnameParameterName, surname);
            return this;
        }

        public ClientQueryBuilder WithBirthDate (DateTime birthDate)
        {
            if (birthDate == DateTime.MinValue)
            {
                return this;
            }
            Wheres.Add(WhereBirthDate);
            QueryParameters.Add(BirthDateParameterName, birthDate);
            return this;
        }

        public ClientQueryBuilder WithTaxiIdCode (string taxIdCode)
        {
            if (string.IsNullOrWhiteSpace(taxIdCode)) 
            {
                return this;
            }
            Wheres.Add(WhereTaxIdCode);
            QueryParameters.Add(TaxidCodeParameterName, taxIdCode);
            return this;
        }

        public ClientQueryBuilder WithPhoneNumber (string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return this;
            }
            Wheres.Add(WherePhoneNumber);
            QueryParameters.Add(PhoneNumberParameterName, phoneNumber);
            return this;
        }

        public ClientQueryBuilder WithEmail (string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return this;
            }
            Wheres.Add(WhereEmail);
            QueryParameters.Add(EmailParameterName, email);
            return this;
        }

        public ClientQueryBuilder WithPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return this;
            }
            Wheres.Add(WherePassword);
            QueryParameters.Add(PasswordParameterName, password);
            return this;
        }

        public ClientQueryBuilder WithFidelity (bool fidelity)
        {
            if (fidelity)
            {
                Wheres.Add(WhereFidelity);
                QueryParameters.Add(FidelityParameterName, fidelity);
            }
            return this;
        }

        public QueryBuilderResult Build ()
        {
            var wheresStrings = string.Empty;
            if (Wheres.Any())
            {
                wheresStrings = $"{Environment.NewLine}WHERE {string.Join($" AND ", Wheres)}";
            }
            return new QueryBuilderResult
            {
                Query = MainQuery.Replace(WherePlaceholder, wheresStrings),
                Parameters = QueryParameters
            };
        }
    }
}
