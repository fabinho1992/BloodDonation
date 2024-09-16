using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationDataBase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DonorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Donor donor)
        {
            

            await _unitOfWork.DonorRepository.Create(donor);

            await _unitOfWork.Commit();
            //var Address = new Address(donor.Address.Street, donor.Address.City, donor.Address.State,
            //                            donor.Address.ZipCode, donor.Address.DonorId);
            //await _unitOfWork.AddressRepository.Create(Address);
            //await _unitOfWork.Commit();

            return Ok();
            
        }
    }
}
