using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.Models
{
    public class Donor
    {
        public Donor(int id, int name, string email, DateTime dateOfBirth, int age, string gender, 
            double weight, string bloodType, string factorRh, int addressId)
        {
            Id = id;
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            Age = age;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            FactorRh = factorRh;
            AddressId = addressId;
        }

        public int Id { get; private set; }
        public int Name { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public int Age { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }
        public string FactorRh { get; set; }
        public int AddressId {  get; private set; }
        public Address? Address { get; set; }
        public List<Donation>? Donations { get; set; }
    }
}
