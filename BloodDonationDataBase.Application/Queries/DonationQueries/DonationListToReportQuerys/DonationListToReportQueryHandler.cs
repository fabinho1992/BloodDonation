using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.DonationQueries.DonationListToReportQuerys
{
    public class DonationListToReportQueryHandler : IRequestHandler<DonationListToReportQuery, IEnumerable<Donation>>
    {
        public IUnitOfWork _unitOfWork;

        public DonationListToReportQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Donation>> Handle(DonationListToReportQuery request, CancellationToken cancellationToken)
        {
            var donations = await _unitOfWork.DonationRepository.GetAllReports();
            return donations;
        }
    }
}
