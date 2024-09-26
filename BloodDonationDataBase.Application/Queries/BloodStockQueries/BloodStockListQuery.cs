using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsBloodStock;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.BloodStockQueries
{
    public class BloodStockListQuery : IRequest<ResultViewModel<List<BloodStockResponse>>>
    {

    }
}
