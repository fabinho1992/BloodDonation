using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.DonationQueries
{
    public class DonationByIdQuery : IRequest<ResultViewModel<DonationResponseById>>
    {
        public DonationByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
