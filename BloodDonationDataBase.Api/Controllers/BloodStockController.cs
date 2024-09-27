using BloodDonationDataBase.Application.Commands.BloodStockCommands.BloodWithDrawalCommands;
using BloodDonationDataBase.Application.Commands.BloodStockCommands.CreateBloodStockCommands;
using BloodDonationDataBase.Application.Queries.BloodStockQueries;
using BloodDonationDataBase.Application.Queries.BloodStockQueries.BloodStockTypeFactor;
using BloodDonationDataBase.Domain.Enuns;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _mediator.Send(createBloodStock);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new BloodStockListQuery();
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("BloodType_FactoeRh")]
        public async Task<IActionResult> GetByBloodType([FromQuery]BloodType bloodType, FactorRh factorRh)
        {
            var query = new BloodStockTypeFactorQuery(bloodType, factorRh);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess) 
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("Blood withDrawal")]
        public async Task<IActionResult> TakeBlood(BloodWithDrawalComand withDrawalComand)
        {
            var result = await _mediator.Send(withDrawalComand);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok("");

        }
    }
}
