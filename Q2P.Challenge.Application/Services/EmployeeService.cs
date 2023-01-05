using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Q2P.Challenge.Data;
using Q2P.Challenge.Domain.Core.DTO;
using Q2P.Challenge.Domain.Core.DTO.Requests;
using Q2P.Challenge.Domain.Core.DTO.Responses;
using Q2P.Challenge.Domain.Core.Entities;

namespace Q2P.Challenge.Application.Services.Interfaces
{
    public class EmployeeService : IEmployeeAppService
    {
        private readonly DataContext _context;
        private readonly ICompanyAppService _companyService;

        public EmployeeService(DataContext context, ICompanyAppService companyService)
        {
            _context = context;
            _companyService = companyService;
        }

        public async Task<EmployeeResponseDto?> AddEmployee(CreateEmployeeDto request)
        {
            var company = await _companyService.GetCompany(request.CompanyId);
            if (company == null)
            {
                //adicionar retorno genérico para controller api para especificar motivo
                return null;
            }

            var employee = new Employee
            {
                Name = request.Name,
                Occupation = request.Occupation,
                Remuneration = request.Remuneration,
                CompanyId = request.CompanyId
            };

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            return await GetEmployee(employee.Id);
        }

        public async Task<List<Employee>?> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee is null)
            {
                return null;
            }

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Employee>?> GetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();

            return employees ?? null;
        }

        public async Task<EmployeeResponseDto?> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee is null)
            {
                return null;
            }

            employee.Company = await _companyService.GetCompany(employee.CompanyId.GetValueOrDefault());

            var employeeResponseDto = new EmployeeResponseDto
            {
                Id = employee.Id,
                CompanyId = employee.CompanyId,
                Name = employee.Name,
                Occupation = employee.Occupation,
                Remuneration = employee.Remuneration,
                Company = employee.Company is null ? null : new CompanyResponseDto
                {
                    Id = employee.Company.Id,
                    Name = employee.Company.Name,
                    ZipCode = employee.Company.ZipCode,
                    FullAddress = employee.Company.FullAddress,
                    AddressNumber = employee.Company.AddressNumber,
                    AddressComplement = employee.Company.AddressComplement,
                    PhoneNumber = employee.Company.PhoneNumber
                }
            };

            return employeeResponseDto;
        }

        public async Task<List<Employee>?> UpdateEmployee(int id, Employee request)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee is null)
            {
                return null;
            }

            employee.Name = request.Name;
            employee.Occupation = request.Occupation;
            employee.Remuneration = request.Remuneration;

            _context.Update(employee);

            await _context.SaveChangesAsync();

            return await _context.Employees.ToListAsync();
        }
    }
}
