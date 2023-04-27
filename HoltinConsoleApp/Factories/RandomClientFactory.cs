﻿using Bogus;
using HoltinModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoltinConsoleApp.Factories
{
    public class RandomClientFactory
    {
        private readonly Faker<Client> _faker;

        public RandomClientFactory(Faker<Client> faker)
        {
            _faker = faker;
        }

        public Client Create ()
        {
            var client = _faker
                        .RuleFor(c => c.Id, f => f.IndexFaker + 1)
                        .RuleFor(c => c.Name, f => f.Name.FirstName())
                        .RuleFor(c => c.Surname, f => f.Name.LastName())
                        .RuleFor(c => c.BirthDate, f => f.Person.DateOfBirth)
                        .RuleFor(c => c.TaxIdCode, f => f.Random.AlphaNumeric(16))
                        .RuleFor(c => c.PhoneNumber, f => f.Person.Phone)
                        .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Name, c.Surname))
                        .RuleFor(c => c.Fidelity, f => f.Random.Bool(0.3f))
                        .Generate();
            return client;
        }


    }
}
