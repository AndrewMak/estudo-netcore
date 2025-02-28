﻿using backendtest.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend_test.Domain.Entities
{
    public class Address : Entity
    {
        public Address(string street,
            string number,
            string complement,
            string district,
            string city,
            string state,
            string country,
            string zipCode)
        {
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public override string ToString()
        {
            return $"{Street}, {Number} - {City}/{State}";
        }
    }
}
