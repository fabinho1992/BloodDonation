using BloodDonationDataBase.Application.Commands.DonationCommands.CreateDonationCommands;
using BloodDonationDataBase.Application.Commands.DonationCommands.DeleteDonationCommands;
using BloodDonationDataBase.Application.Queries.DonationQueries;
using BloodDonationDataBase.Domain.Enuns;
using BloodDonationDataBase.Domain.Models;
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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]ParametrosPaginacao parametrosPaginacao)
        {
            var query = new DonationListQuery(parametrosPaginacao.PageNumber, parametrosPaginacao.PageSize);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new DonationByIdQuery(id);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("BloodType")]
        public async Task<IActionResult> GetBloodType([FromQuery]BloodType bloodType)
        {
            var query = new DonationBloodTypeQuery(bloodType);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
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
