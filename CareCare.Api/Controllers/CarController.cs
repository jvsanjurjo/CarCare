using CarCare.Application.Cars.Commands;
using CarCare.Application.Cars.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CareCare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<List<GetCarsQueryResponse>> GetCars() => _mediator.Send(new GetCarsQuery());

        [HttpGet("{RegistrationNumber}")]
        public Task<GetCarQueryResponse> GetCarById([FromRoute] GetCarQuery query) =>
        _mediator.Send(query);

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
