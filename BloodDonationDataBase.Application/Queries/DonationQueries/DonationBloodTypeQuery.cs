using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonation;
using BloodDonationDataBase.Domain.Enuns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.DonationQueries
{
    public class DonationBloodTypeQuery : IRequest<ResultViewModel<List<DonationResponseToList>>>
    {
        public DonationBloodTypeQuery(BloodType bloodType)
        {
            BloodType = bloodType;
        }

        public BloodType BloodType { get; private set; }
    }
}
