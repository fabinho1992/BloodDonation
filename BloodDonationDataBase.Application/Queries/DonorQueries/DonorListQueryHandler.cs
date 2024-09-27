using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonor;
using BloodDonationDataBase.Domain.Errors;
using BloodDonationDataBase.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.Queries.DonorQueries
{
    public class DonorListQueryHandler : IRequestHandler<DonorListQuery, ResultViewModel<List<DonorResponseList>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DonorListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<DonorResponseList>>> Handle(DonorListQuery request, CancellationToken cancellationToken)
        {
            var donorList = await _unitOfWork.DonorRepository.GetAll(request);
            if (donorList is null)
            {
                return ResultViewModel<List<DonorResponseList>>.Error(DonorErrors.Notfound.ToString());
            }

            var newDonorsList = new List<DonorResponseList>();
            foreach (var donor in donorList) 
            {
                var newDonor = new DonorResponseList(donor.Id, donor.Name, donor.Email, donor.Age, donor.Gender,
                    donor.Weight, donor.BloodType, donor.FactorRh);
                newDonorsList.Add(newDonor);
            }

            return ResultViewModel<List<DonorResponseList>>.Success(newDonorsList);
        }
    }
}
