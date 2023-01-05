using Microsoft.AspNetCore.Mvc;
using Q2P.Challenge.Application.Services.Interfaces;
using Q2P.Challenge.Domain.Core.DTO;
using Q2P.Challenge.Domain.Core.DTO.Requests;
using Q2P.Challenge.Domain.Core.Entities;

namespace Q2P.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeAppService _employeeService;

        public EmployeeController(IEmployeeAppService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var result = await _employeeService.GetAllEmployees();

            if (result is null)
                return NotFound("Funcionário não encontrado.");

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var result = await _employeeService.GetEmployee(id);

            if (result is null)
                return NotFound("Funcionário não encontrado.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Employee?>> AddEmployee(CreateEmployeeDto request)
        {
            var result = await _employeeService.AddEmployee(request);

            if (result is null)
            {
                return BadRequest("Não foi possível completar a operação.");
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(int id, Employee request)
        {
            var result = await _employeeService.UpdateEmployee(id, request);

            if (result is null)
                return NotFound("Funcionário não encontrado.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);

            if (result is null)
                return NotFound("Funcionário não encontrado.");

            return Ok(result);
        }
    }
}
