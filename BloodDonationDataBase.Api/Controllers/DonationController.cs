using BloodDonationDataBase.Application.Commands.DonationCommands.CreateDonationCommands;
using BloodDonationDataBase.Application.Commands.DonationCommands.DeleteDonationCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationDataBase.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDonationCommand createDonation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(createDonation);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();
            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteDonationCommand deleteDonation)
        {
            var result = await _mediator.Send(deleteDonation);

            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }
            
            return NoContent();
        }
    }
}
