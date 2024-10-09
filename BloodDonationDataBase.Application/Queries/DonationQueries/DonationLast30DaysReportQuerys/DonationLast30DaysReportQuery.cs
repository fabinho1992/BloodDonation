using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.DonationQueries.DonationLast30DaysReportQuerys
{
    public class DonationLast30DaysReportQuery : IRequest<IEnumerable<Donation>>
    {
    }
}
