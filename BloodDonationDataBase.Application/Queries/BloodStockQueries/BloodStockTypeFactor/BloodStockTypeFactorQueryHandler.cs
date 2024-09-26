using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsBloodStock;
using BloodDonationDataBase.Domain.Errors;
using BloodDonationDataBase.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.BloodStockQueries.BloodStockTypeFactor
{
    public class BloodStockTypeFactorQueryHandler : IRequestHandler<BloodStockTypeFactorQuery, ResultViewModel<BloodStockResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BloodStockTypeFactorQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<BloodStockResponse>> Handle(BloodStockTypeFactorQuery request, CancellationToken cancellationToken)
        {
            var BloodStockId = await _unitOfWork.BloodStockRepository.GetBloodType(request.BloodType, request.FactorRh);
            if (BloodStockId is null) 
            {
                return ResultViewModel<BloodStockResponse>.Error(BloodStockErrors.NotFound.ToString());
            }

            var BloodStockResponse = new BloodStockResponse(BloodStockId.Id, BloodStockId.BloodType,
                BloodStockId.FactorRh, BloodStockId.QuantityMl);

            return ResultViewModel<BloodStockResponse>.Success(BloodStockResponse);
        }
    }
}
