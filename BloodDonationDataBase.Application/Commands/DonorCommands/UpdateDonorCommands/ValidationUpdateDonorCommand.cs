using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.IServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.DonorCommands.UpdateDonorCommands
{
    public class ValidationUpdateDonorCommand : IPipelineBehavior<UpdateDonorCommand, ResultViewModel<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressZipCode _addressZipCode;

        public ValidationUpdateDonorCommand(IUnitOfWork unitOfWork, IAddressZipCode addressZipCode)
        {
            _unitOfWork = unitOfWork;
            _addressZipCode = addressZipCode;
        }

        public async Task<ResultViewModel<int>> Handle(UpdateDonorCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var donor = await _unitOfWork.DonorRepository.GetById(request.Id);
            if (donor is null) 
            {
                return ResultViewModel<int>.Error($"Donor with ID {request.Id} not found");
            }

            var zipCode = await _addressZipCode.SearchZipCode(request.ZipCode);
            if (zipCode is null)
            {
                return ResultViewModel<int>.Error("ZipCode not found");
            }

            return await next();


        }
    }
}
