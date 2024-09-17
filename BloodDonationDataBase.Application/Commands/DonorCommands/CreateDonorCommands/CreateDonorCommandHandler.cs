using BloodDonationDataBase.Application.Services;
using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Commands.DonorCommands.CreateDonorCommands
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, Donor>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddressZipCode _addressZipCode;

        public CreateDonorCommandHandler(IUnitOfWork unitOfWork, IAddressZipCode addressZipCode)
        {
            _unitOfWork = unitOfWork;
            _addressZipCode = addressZipCode;
        }

        public async Task<Donor> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = new Donor(request.Name,request.Email,request.DateOfBirth,
                request.Gender,request.Weight,request.BloodType,request.FactorRh,request.ZipCode);
            await _unitOfWork.DonorRepository.Create(donor);
            await _unitOfWork.Commit();

            var zipCode = await _addressZipCode.SearchZipCode(donor.ZipCode);
            var address = new Address(street: zipCode.Logradouro, city: zipCode.Localidade, state: zipCode.Uf,
                zipCode: zipCode.Cep, complement: request.Complement, donorId: donor.Id);
            await _unitOfWork.AddressRepository.Create(address);
            await _unitOfWork.Commit();

            return donor;
        }
    }
}
