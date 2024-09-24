using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.IServices;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.DonorCommands.UpdateDonorCommands
{
    public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, ResultViewModel<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressZipCode _addressZipCode;

        public UpdateDonorCommandHandler(IUnitOfWork unitOfWork, IAddressZipCode addressZipCode)
        {
            _unitOfWork = unitOfWork;
            _addressZipCode = addressZipCode;
        }

        public async Task<ResultViewModel<int>> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _unitOfWork.DonorRepository.GetById(request.Id);
            donor.Update(request.Name, request.Email, request.DateOfBirth, request.Gender,
                request.Weight, request.BloodType, request.FactorRh, request.ZipCode);
            donor.Age = donor.CalculatedAge(request.DateOfBirth);
            await _unitOfWork.DonorRepository.Update(donor);
            await _unitOfWork.Commit();

            var zipCode = await _addressZipCode.SearchZipCode(donor.ZipCode);
            var address = await _unitOfWork.AddressRepository.GetById(donor.Id);
            address.Update(zipCode.Logradouro, zipCode.Localidade, zipCode.Uf,
                zipCode.Cep, request.Complement, donor.Id);
           
            await _unitOfWork.AddressRepository.Update(address);
            await _unitOfWork.Commit();

            return ResultViewModel<int>.Success(donor.Id);
        }
    }
}
