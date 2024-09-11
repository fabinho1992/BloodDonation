using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.Models
{
    public class Donation
    {
        public Donation(int id, int donorId, DateTime dateDonation, int quantityMl)
        {
            Id = id;
            DonorId = donorId;
            DateDonation = dateDonation;
            QuantityMl = quantityMl;
        }

        public int Id { get; private set; }
        public int DonorId { get; private set; }
        public DateTime DateDonation { get; private set; }
        public int QuantityMl { get; private set; }
        public Donor? Donor { get;  set; }
    }
}
