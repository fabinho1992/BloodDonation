using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.Models
{
    public class Address : BaseModel
    {
        public Address(string street, string city, int state, int zipCode, int donorId)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            DonorId = donorId;

        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public int State { get; private set; }
        public int ZipCode { get; private set; }
        public int DonorId { get; set; }
        public Donor? Donor { get; set; }
    }
}
