using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.BloodStockQueries.BloodStockReportQuery
{
    public class BloodStockReportQueryHandler : IRequestHandler<BloodStockReportQuery, IEnumerable<BloodStock>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BloodStockReportQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BloodStock>> Handle(BloodStockReportQuery request, CancellationToken cancellationToken)
        {
            var bloodStock = await _unitOfWork.BloodStockRepository.GetAll();
            return bloodStock;
        }
    }
}
