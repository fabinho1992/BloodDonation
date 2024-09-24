using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsAddress
{
    public class AddressResponse
    {
        public AddressResponse(string street, string city, string state, string zipCode, string complement)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Complement = complement;
        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Complement { get; set; }
    }
}
