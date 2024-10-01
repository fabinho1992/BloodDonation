using BloodDonationDataBase.Application.Commands.DonorCommands.CreateDonorCommands;
using BloodDonationDataBase.Application.Commands.DonorCommands.DeleteDonorCommands;
using BloodDonationDataBase.Application.Commands.DonorCommands.UpdateDonorCommands;
using BloodDonationDataBase.Application.Dtos;
using BloodDonationDataBase.Application.Dtos.ViewModels.ViewModelsDonor;
using BloodDonationDataBase.Application.Queries.DonorQueries;
using BloodDonationDataBase.Domain.IRepositories;
using BloodDonationDataBase.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BloodDonationDataBase.Api.Controllers
{
    [Route("[controller]")]
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

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(donor);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetId), new { id = result.Data }, donor);
        }


        [ProducesResponseType(typeof(DonorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var query = new DonorByIdQuery(id);

            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ParametrosPaginacao parametrosPaginacao)
        {
            var query = new DonorListQuery(parametrosPaginacao.PageNumber, parametrosPaginacao.PageSize);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateDonorCommand update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(update);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteDonorCommand deleteDonor)
        {
            var result = await _mediator.Send(deleteDonor);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
