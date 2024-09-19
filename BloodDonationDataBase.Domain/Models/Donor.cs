using BloodDonationDataBase.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.Models
{
    public class Donor : BaseModel
    {
        public Donor(string name, string email, DateTime dateOfBirth, Gender gender, double weight,
            BloodType bloodType, FactorRh factorRh, string zipCode)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            Age = CalculatedAge(dateOfBirth);
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            FactorRh = factorRh;
            ZipCode = zipCode;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public int Age { get ;  set; }
        public Gender Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodType BloodType { get; private set; }
        public FactorRh FactorRh { get; set; }
        public string ZipCode { get; private set; }
        public Address? Address { get; set; }
        public List<Donation>? Donations { get; private set; }


        public void Update(string name, string email, DateTime dateOfBirth, Gender gender, double weight,
            BloodType bloodType, FactorRh factorRh, string zipCode)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            FactorRh = factorRh;
            ZipCode = zipCode;
        }


        public int CalculatedAge(DateTime date)
        {
            // Calcula a idade com base na data de aniversário
            var hoje = DateTime.Now;
            var idade = hoje.Year - date.Year;

            // Verifica se o aniversário já passou este ano
            if (hoje.Month < date.Month || (hoje.Month == date.Month && hoje.Day < date.Day))
            {
                idade--;
            }

            return idade;
        }

    }
}
