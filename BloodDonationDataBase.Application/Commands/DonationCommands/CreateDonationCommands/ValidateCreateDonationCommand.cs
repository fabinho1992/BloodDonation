using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Domain.Enuns;
using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Infrastructure.DataContext;
using MediatR;

namespace BloodDonationDataBase.Application.Commands.DonationCommands.CreateDonationCommands
{
    public class ValidateCreateDonationCommand : IPipelineBehavior<CreateDonationCommand, ResultViewModel<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ValidateCreateDonationCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {

            if (request.QuantityMl < 420 || request.QuantityMl > 470)
            {
                return ResultViewModel<int>.Error("Donation must be between 420 and 470 ml");
            }

            var donor = await _unitOfWork.DonorRepository.GetById(request.DonorId);
            //var bloodStock = await _unitOfWork.BloodStockRepository.GetBloodType(donor.BloodType, donor.FactorRh);
            //if (bloodStock is null)
            //{
            //    return ResultViewModel<int>.Error("BloodType the FactorRh not found in the database");
            //}

            if (donor.Age < 18)
            {
                return ResultViewModel<int>.Error("Donor must be of legal age");
            }

            if (donor.Gender == Gender.F && donor.LastDonation >= DateTime.Now.AddDays(-90))
            {
                return ResultViewModel<int>.Error("Donations can only be made every 90 days");
            }

            if (donor.Gender == Gender.M && donor.LastDonation >= DateTime.Now.AddDays(-60))
            {
                return ResultViewModel<int>.Error("Donations can only be made every 60 days");
            }

            return await next();
        }
    }
}
