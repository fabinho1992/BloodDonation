using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsBloodStock;
using BloodDonationDataBase.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.BloodStockQueries
{
    public class BloodStockListQueryHandler : IRequestHandler<BloodStockListQuery, ResultViewModel<List<BloodStockResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BloodStockListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<BloodStockResponse>>> Handle(BloodStockListQuery request, CancellationToken cancellationToken)
        {
            var BloodStockAll = await _unitOfWork.BloodStockRepository.GetAll();
            if (BloodStockAll is null) 
            {
                return ResultViewModel<List<BloodStockResponse>>.Error("BloodStock not found");
            }

            var bloodStockResponse = BloodStockAll.Select(b => new BloodStockResponse(
                id: b.Id,
                bloodType: b.BloodType,
                factorRh: b.FactorRh,
                quantityMl: b.QuantityMl
                )).ToList();

            return ResultViewModel<List<BloodStockResponse>>.Success(bloodStockResponse);
        }
    }
}
