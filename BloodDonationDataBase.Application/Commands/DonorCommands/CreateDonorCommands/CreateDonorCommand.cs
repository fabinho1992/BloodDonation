using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Domain.Enuns;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.DonorCommands.CreateDonorCommands
{
    public class CreateDonorCommand : IRequest<ResultViewModel<int>>
    {
        public CreateDonorCommand(string name, string email, DateTime dateOfBirth, Gender gender, double weight,
            BloodType bloodType, FactorRh factorRh, string zipCode, string complement)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            FactorRh = factorRh;
            ZipCode = zipCode;
            Complement = complement;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Gender Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodType BloodType { get; private set; }
        public FactorRh FactorRh { get; set; }
        public string ZipCode { get; private set; }
        public string Complement {  get; private set; }
    }
}
