using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.DonationQueries.DonationLast30DaysReportQuerys
{
    public class DonationLast30DaysReportQueryHandler : IRequestHandler<DonationLast30DaysReportQuery, IEnumerable<Donation>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DonationLast30DaysReportQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Donation>> Handle(DonationLast30DaysReportQuery request, CancellationToken cancellationToken)
        {
            var donations = await _unitOfWork.DonationRepository.GetAllThirtyDays();
            return donations;
        }
    }
}
