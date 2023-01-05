using Microsoft.AspNetCore.Mvc;
using Q2P.Challenge.Application.Services.Interfaces;
using Q2P.Challenge.Domain.Core.DTO.Requests;
using Q2P.Challenge.Domain.Core.Entities;

namespace Q2P.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyAppService _companyService;

        public CompanyController(ICompanyAppService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetAllCompanies()
        {
            var result = await _companyService.GetAllCompanies();

            if (result is null)
                return NotFound("Empresa não encontrada.");

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var result = await _companyService.GetCompany(id);

            if (result is null)
                return NotFound("Empresa não encontrada.");

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Company?>?> AddCompany([FromBody] CreateCompanyDto request)
        {
            var result = await _companyService.AddCompany(request);

            if (result is null)
                return NotFound("Nao foi possível completar a solicitação.");

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<List<Company>>> UpdateCompany(int id, [FromBody] Company request)
        {
            var result = await _companyService.UpdateCompany(id, request);

            if (result is null)
                return NotFound("Empresa não encontrada.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Company>>> DeleteCompany(int id)
        {
            var result = await _companyService.DeleteCompany(id);

            if (result is null)
                return NotFound("Empresa não encontrada.");

            return Ok(result);
        }
    }
}
