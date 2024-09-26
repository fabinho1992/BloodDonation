using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsBloodStock;
using BloodDonationDataBase.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.BloodStockQueries.BloodStockTypeFactor
{
    public class BloodStockTypeFactorQuery : IRequest<ResultViewModel<BloodStockResponse>>
    {
        public BloodStockTypeFactorQuery(BloodType bloodType, FactorRh factorRh)
        {
            BloodType = bloodType;
            FactorRh = factorRh;
        }

        public BloodType BloodType { get; private set; }
        public FactorRh FactorRh { get; private set; }
    }
}
