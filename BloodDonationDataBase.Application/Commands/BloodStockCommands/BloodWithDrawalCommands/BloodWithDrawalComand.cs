using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.BloodStockCommands.BloodWithDrawalCommands
{
    public class BloodWithDrawalComand : IRequest<ResultViewModel>
    {
        public BloodWithDrawalComand(BloodType bloodType, FactorRh factorRh, int quantityMl)
        {
            BloodType = bloodType;
            FactorRh = factorRh;
            QuantityMl = quantityMl;
        }

        public BloodType BloodType { get; private set; }
        public FactorRh FactorRh { get; private set; }
        public int QuantityMl { get; private set; }
    }
}
