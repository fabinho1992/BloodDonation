using BloodDonationDataBase.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Domain.Models
{
    public class BloodStock : BaseModel
    {
        public BloodStock(BloodType bloodType, FactorRh factorRh, int quantityMl)
        {
            BloodType = bloodType;
            FactorRh = factorRh;
            QuantityMl = quantityMl;
        }

        public BloodType BloodType { get; private set; }
        public FactorRh FactorRh { get; private set; }
        public int QuantityMl { get; private set; }


        public void ReceivingDonation(int BloodMl)
        {
            QuantityMl += BloodMl;
        }

        public void BloodWithdrawal(int BloodMl)
        {
            QuantityMl -= BloodMl;
        }

    }

}
