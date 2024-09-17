using BloodDonationDataBase.Application.Commands.DonorCommands.CreateDonorCommands;
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

        public DonorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDonorCommand donor)
        {

            var createDonor = await _mediator.Send(donor);

            return Ok();
            
        }
    }
}
