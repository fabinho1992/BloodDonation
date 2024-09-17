using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.Models
{
    public class Address : BaseModel
    {
        public Address(string street, string city, string state, string zipCode, string complement , int donorId)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            DonorId = donorId;
            Complement = complement;
        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Complement { get; set; }
        public int DonorId { get; set; }
        public Donor? Donor { get; set; }
    }
}
