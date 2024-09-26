using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Domain.IServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.DonorCommands.CreateDonorCommands
{
    public class ValidationCreateDonorCommand : IPipelineBehavior<CreateDonorCommand, ResultViewModel<int>>
    {
        private readonly IAddressZipCode _addressZipCode;

        public ValidationCreateDonorCommand(IAddressZipCode addressZipCode)
        {
            _addressZipCode = addressZipCode;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonorCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var zipCode = await _addressZipCode.SearchZipCode(request.ZipCode);
            if (zipCode is null) 
            {
                return ResultViewModel<int>.Error("ZipCode not found");
            }

            if (request.Weight <= 50) 
            {
                return ResultViewModel<int>.Error("weight must be greater than 50kg");
            }

            return await next();
        }
    }
}
