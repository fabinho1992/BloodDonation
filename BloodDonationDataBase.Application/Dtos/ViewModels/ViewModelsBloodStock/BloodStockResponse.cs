using BloodDonationDataBase.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsBloodStock
{
    public class BloodStockResponse
    {
        public BloodStockResponse(int id, BloodType bloodType, FactorRh factorRh, int quantityMl)
        {
            Id = id;
            BloodType = bloodType;
            FactorRh = factorRh;
            QuantityMl = quantityMl;
        }

        public int Id { get; private set; }
        public BloodType BloodType { get; private set; }
        public FactorRh FactorRh { get; private set; }
        public int QuantityMl { get; private set; }
    }
}
