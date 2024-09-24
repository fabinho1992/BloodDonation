using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.BloodStockCommands.CreateBloodStockCommands
{
    public class CreateBloodStockCommandHandler : IRequestHandler<CreateBloodStockCommand, BloodStock>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBloodStockCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BloodStock> Handle(CreateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var newStock = new BloodStock(request.BloodType, request.FactorRh);
            await _unitOfWork.BloodStockRepository.Create(newStock);
            await _unitOfWork.Commit();

            return newStock;
        }
    }
}
