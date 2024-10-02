using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.DonationQueries.DonationListToReportQuerys
{
    public class DonationListToReportQuery : IRequest<IEnumerable<Donation>>
    {
    }
}
