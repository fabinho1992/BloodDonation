using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.DonorQueries.DonorReportQuerys
{
    public class DonorReportQueryHandler : IRequestHandler<DonorReportQuery, IEnumerable<Donor>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DonorReportQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Donor>> Handle(DonorReportQuery request, CancellationToken cancellationToken)
        {
            var donors = await _unitOfWork.DonorRepository.GetAllReport();

            return donors;
        }
    }
}
