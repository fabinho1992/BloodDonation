using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Domain.Errors;
using BloodDonationDataBase.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.BloodStockCommands.BloodWithDrawalCommands
{
    public class BloodWithDrawalCommandHandler : IRequestHandler<BloodWithDrawalComand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BloodWithDrawalCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(BloodWithDrawalComand request, CancellationToken cancellationToken)
        {
            var BloodStock = await _unitOfWork.BloodStockRepository.GetBloodType(request.BloodType, request.FactorRh);
            if (BloodStock is null) 
            {
                return ResultViewModel.Error(BloodStockErrors.NotFound.ToString());
            }

            if(request.QuantityMl > BloodStock.QuantityMl)
            {
                return ResultViewModel.Error(BloodStockErrors.NotEnoughAmount.ToString());
            }

            BloodStock.BloodWithdrawal(request.QuantityMl);

            await _unitOfWork.Commit();

            return ResultViewModel.Success();
        }
    }
}
