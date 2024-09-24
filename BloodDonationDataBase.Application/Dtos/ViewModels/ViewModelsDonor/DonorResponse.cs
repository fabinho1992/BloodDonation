using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsAddress;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonation;
using BloodDonationDataBase.Domain.Enuns;
using BloodDonationDataBase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonor
{
    public class DonorResponse
    {
        public DonorResponse(string name, string email, int age, Gender gender, double weight,
                    BloodType bloodType, FactorRh factorRh, AddressResponse addressResponse, List<DonationResponse> donations)
        {
            Name = name;
            Email = email;
            Age = age;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            FactorRh = factorRh;
            AddressResponse = addressResponse;
            Donations = donations;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public int Age { get; set; }
        public Gender Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodType BloodType { get; private set; }
        public FactorRh FactorRh { get; set; }
        public AddressResponse AddressResponse { get; set; }
        public List<DonationResponse> Donations { get; set; }

    }
}
