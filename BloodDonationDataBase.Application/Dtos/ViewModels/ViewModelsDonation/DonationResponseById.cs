using BloodDonationDataBase.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonation
{
    public class DonationResponseById
    {
        public DonationResponseById(int id, string donorName, int donorId, string donorEmail, double donorWeight,
            BloodType bloodType, FactorRh factorRh, DateTime dateDonation, int quantityMl)
        {
            Id = id;
            DonorName = donorName;
            DonorId = donorId;
            DonorEmail = donorEmail;
            DonorWeight = donorWeight;
            BloodType = bloodType;
            FactorRh = factorRh;
            DateDonation = dateDonation.ToString("dd/MM/yyyy");
            QuantityMl = quantityMl;
        }

        public int Id { get; private set; }
        public string DonorName { get; private set; }
        public int DonorId { get; private set; }
        public string DonorEmail { get; private set; }
        public double DonorWeight { get; private set; }
        public BloodType BloodType { get; private set; }
        public FactorRh FactorRh { get; private set; }
        public string DateDonation { get; private set; }
        public int QuantityMl { get; private set; }

    }
}
