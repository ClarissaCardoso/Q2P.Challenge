using Q2P.Challenge.Domain.Core.DTO.Requests;
using Q2P.Challenge.Domain.Core.Entities;

namespace Q2P.Challenge.Application.Services.Interfaces
{
    public interface ICompanyAppService
    {
        public Task<Company?>? AddCompany(CreateCompanyDto request);
        public Task<List<Company>?> DeleteCompany(int id);
        public Task<List<Company>?> GetAllCompanies();
        public Task<Company?> GetCompany(int id);
        public Task<List<Company>?> UpdateCompany(int id, Company request);
    }
}
