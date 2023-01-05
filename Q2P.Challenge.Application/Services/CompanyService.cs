using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Q2P.Challenge.Data;
using Q2P.Challenge.Data.External.Interfaces;
using Q2P.Challenge.Domain.Core.DTO.Requests;
using Q2P.Challenge.Domain.Core.Entities;
using Q2P.Challenge.Domain.Core.Entities.External;
using System.IO.Pipelines;
using System.Text.Json.Serialization;

namespace Q2P.Challenge.Application.Services.Interfaces
{
    public class CompanyService : ICompanyAppService
    {
        private readonly DataContext _context;
        private readonly IViaCepApiClient _viaCepClient;

        public CompanyService(DataContext context, IViaCepApiClient viaCepClient)
        {
            _context = context;
            _viaCepClient = viaCepClient;
        }

        public async Task<Company?>? AddCompany(CreateCompanyDto request)
        {
            var httpResponseMessage = await _viaCepClient.GetAddress(request.ZipCode);

            if (httpResponseMessage is null)
            {
                return null;
            }

            ViaCepResponse? viaCepResponse = null;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                if (httpResponseMessage.Content is not null)
                {
                    var responseJsonTextBody = await httpResponseMessage.Content.ReadAsStringAsync();

                    viaCepResponse = JsonConvert.DeserializeObject<ViaCepResponse>(responseJsonTextBody);
                }
            }
            else
            {
                //
                return null;
            }

            if (viaCepResponse is null)
            {
                return null;
            }

            var company = new Company
            {
                Name = request.Name,
                ZipCode = viaCepResponse.cep,
                FullAddress = $"{viaCepResponse.logradouro.ToUpper()}, {viaCepResponse.complemento.ToUpper()}, {viaCepResponse.bairro.ToUpper()}, {viaCepResponse.localidade.ToUpper()}-{viaCepResponse.uf.ToUpper()}",
                AddressNumber = request.AddressNumber,
                AddressComplement = request.AddressComplement,
                PhoneNumber = request.PhoneNumber //mask
            };

            _context.Companies.Add(company);

            await _context.SaveChangesAsync();

            //return await _context.Companies.ToListAsync();

            return await GetCompany(company.Id);
        }

        public async Task<List<Company>?> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company is null)
            {
                return null;
            }

            _context.Companies.Remove(company);

            await _context.SaveChangesAsync();

            return await _context.Companies.ToListAsync();
        }

        public async Task<List<Company>?> GetAllCompanies()
        {
            var companies = await _context.Companies.ToListAsync();

            return companies ?? null;
        }

        public async Task<Company?> GetCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            return company ?? null;
        }

        public async Task<List<Company>?> UpdateCompany(int id, Company request)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company is null)
            {
                return null;
            }

            company.Name = request.Name;
            company.ZipCode = request.ZipCode;
            company.FullAddress = request.FullAddress;
            company.AddressNumber = request.AddressNumber;
            company.AddressComplement = request.AddressComplement;
            company.PhoneNumber = request.PhoneNumber;

            _context.Update(company);

            await _context.SaveChangesAsync();

            return await _context.Companies.ToListAsync();
        }
    }
}
