using BloodDonationDataBase.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.Models
{
    public class Donor : BaseModel
    {
        public Donor(int name, string email, DateTime dateOfBirth, int age, Gender gender, double weight,
            BloodType bloodType, FactorRh factorRh)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            Age = age;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            FactorRh = factorRh;
        }

        public int Name { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public int Age { get; private set; }
        public Gender Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodType BloodType { get; private set; }
        public FactorRh FactorRh { get; set; }
        public Address? Address { get; set; }
        public List<Donation>? Donations { get; set; }
    }
}
