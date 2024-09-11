using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.Models
{
    public class BloodStock
    {
        public BloodStock(int id, string bloodType, string factorRh, int quantityMl)
        {
            Id = id;
            BloodType = bloodType;
            FactorRh = factorRh;
            QuantityMl = quantityMl;
        }

        public int Id { get; private set; }
        public string BloodType { get; private set; }
        public string FactorRh { get; private set; }
        public int QuantityMl { get; private set; }


        public void ReceivingDonation(int BloodMl)
        {

        }

    }

}
