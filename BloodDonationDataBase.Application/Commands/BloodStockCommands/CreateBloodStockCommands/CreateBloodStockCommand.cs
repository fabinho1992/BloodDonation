using BloodDonationDataBase.Domain.Enuns;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.BloodStockCommands.CreateBloodStockCommands
{
    public class CreateBloodStockCommand : IRequest<BloodStock>
    {
        public CreateBloodStockCommand(BloodType bloodType, FactorRh factorRh)
        {
            BloodType = bloodType;
            FactorRh = factorRh;
        }

        public BloodType BloodType { get; private set; }
        public FactorRh FactorRh { get; private set; }
        
    }
}
