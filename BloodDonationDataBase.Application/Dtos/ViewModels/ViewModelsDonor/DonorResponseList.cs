using BloodDonationDataBase.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonor
{
    public class DonorResponseList
    {
        public DonorResponseList(int id, string name, string email, int age, Gender gender, double weight, BloodType bloodType, FactorRh factorRh)
        {
            Id = id;
            Name = name;
            Email = email;
            Age = age;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            FactorRh = factorRh;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int Age { get; set; }
        public Gender Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodType BloodType { get; private set; }
        public FactorRh FactorRh { get; set; }
    }
}
