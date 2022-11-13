using System.Threading.Tasks;
using CQRSMediator.CQRS.Commands;
using CQRSMediator.CQRS.Queries;
using CQRSMediator.Migrations;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [EnableCors("*")]
        public async Task<IActionResult> Create(CreateEmployeeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllEmployeeQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetEmployeeByIdQuery() { Id = id }));
        }

        // URL - https://localhost:44378/api/Product/{id} type PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeCommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteEmployeeByIdCommand { Id = id }));
        }
    }
}