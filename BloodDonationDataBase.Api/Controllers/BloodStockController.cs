using BloodDonationDataBase.Application.Commands.BloodStockCommands.CreateBloodStockCommands;
using BloodDonationDataBase.Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationDataBase.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BloodStockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BloodStockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBloodStockCommand createBloodStock)
        {
            var result = await _mediator.Send(createBloodStock);

            return Ok(result);
        }
    }
}
