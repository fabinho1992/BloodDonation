using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonor;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.DonorQueries
{
    public class DonorListQuery : ParametrosPaginacao, IRequest<ResultViewModel<List<DonorResponseList>>>
    {
        public DonorListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
