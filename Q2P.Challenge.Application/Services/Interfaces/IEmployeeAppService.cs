using Q2P.Challenge.Domain.Core.DTO;
using Q2P.Challenge.Domain.Core.DTO.Requests;
using Q2P.Challenge.Domain.Core.DTO.Responses;
using Q2P.Challenge.Domain.Core.Entities;

namespace Q2P.Challenge.Application.Services.Interfaces
{
    public interface IEmployeeAppService
    {
        public Task<EmployeeResponseDto?> AddEmployee(CreateEmployeeDto request);
        public Task<List<Employee>?> DeleteEmployee(int id);
        public Task<List<Employee>?> GetAllEmployees();
        public Task<EmployeeResponseDto?> GetEmployee(int id);
        public Task<List<Employee>?> UpdateEmployee(int id, Employee request);
    }
}
