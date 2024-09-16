using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.Models
{
    public class Donation : BaseModel
    {
        public Donation(int donorId, DateTime dateDonation, int quantityMl)
        {
            DonorId = donorId;
            DateDonation = dateDonation;
            QuantityMl = quantityMl;
        }

        public int DonorId { get; private set; }
        public DateTime DateDonation { get; private set; }
        public int QuantityMl { get; private set; }
        public Donor? Donor { get;  set; }
    }
}
