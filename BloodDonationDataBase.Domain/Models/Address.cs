using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.Models
{
    public class Address
    {
        public Address(int id, string street, string city, int state, int zipCode)
        {
            Id = id;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public int Id { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public int State { get; private set; }
        public int ZipCode { get; private set; }
        public Donor? Donor { get; set; }
    }
}
