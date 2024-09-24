using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.DonorQueries
{
    public class DonorByIdQuery : IRequest<ResultViewModel<DonorResponse>>
    {
        public DonorByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
