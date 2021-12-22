using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Volo.Abp.Domain.Services;

namespace CRM.Company
{
    public class CompanyManager : DomainService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyManager(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }


        public async Task<Company> CreateAsync(string name)
        {
            var existCompany = await _companyRepository.FindByNameAsync(name);
            if (existCompany != null)
            {
                throw new CompanyAlreadyExistException(name);
            }

            return new Company(GuidGenerator.Create(),name);
        }


        public async Task ChangeNameAsync(Company company, string  newName){
            var existCompany = await _companyRepository.FindByNameAsync(newName);
            if (existCompany != null && existCompany.Id != company.Id)
            {
                throw new CompanyAlreadyExistException(newName);
            }

            company.ChangeName(newName);
        }
    }
}
