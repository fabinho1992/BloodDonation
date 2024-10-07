using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.BloodStockQueries.BloodStockReportQuery
{
    public class BloodStockReportQuery : IRequest<IEnumerable<BloodStock>>
    {
    }
}
