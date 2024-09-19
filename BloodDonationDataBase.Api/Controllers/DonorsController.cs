using BloodDonationDataBase.Application.Commands.DonorCommands.CreateDonorCommands;
using BloodDonationDataBase.Application.Commands.DonorCommands.UpdateDonorCommands;
using BloodDonationDataBase.Application.Services;
using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationDataBase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public DonorsController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDonorCommand donor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createDonor = await _mediator.Send(donor);

            return Ok();
            
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDonorCommand update)
        {
            var updateDonor = await _mediator.Send(update);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetId(int id)
        {
            var donor = await _unitOfWork.DonorRepository.GetById(id);
            return Ok(donor);
        }
    }
}
