using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milestone4_CrudEmployee_MongoDB_Mar21.Commands;
using Milestone4_CrudEmployee_MongoDB_Mar21.Models;
using Milestone4_CrudEmployee_MongoDB_Mar21.Queries;

namespace Milestone4_CrudEmployee_MongoDB_Mar21.Controllers
{
    [EnableCors("swagger")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(employees);
        }
        [HttpPost]
        [Route("addEmployee")]
        public async Task<ActionResult> CreateNew([FromBody] EmployeeTable employee)
        {
            await _mediator.Send(new AddNewEmployee(employee));
            return StatusCode(201);
        }

        [HttpPut]
        [Route("updateEmployee/{id}")]
        public async Task<ActionResult> Update( string id,EmployeeTable employee)
        {
            await _mediator.Send(new UpdateEmployee(id,employee));
            return StatusCode(200);
        }

        [HttpDelete]
        [Route("deleteEmployee")]
        public async Task<ActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteEmployee(id));
            return StatusCode(200);
        }

    }
}
