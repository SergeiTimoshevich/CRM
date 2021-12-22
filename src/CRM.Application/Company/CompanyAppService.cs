using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace CRM.Company
{
    public class CompanyAppService : CRMAppService, ICompanyAppService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly CompanyManager _companyManager;

        public CompanyAppService(
            ICompanyRepository companyRepository,
            CompanyManager companyManager)
        {
            _companyRepository = companyRepository;
            _companyManager = companyManager;
        }

        public async Task<CompanyDto> GetAsync(Guid id)
        {
            var company = await _companyRepository.GetAsync(id);
            return ObjectMapper.Map<Company, CompanyDto>(company);
        }

        public async Task<PagedResultDto<CompanyDto>> GetListAsync(GetCompanyListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Company.Name);
            }


            var company =
                await _companyRepository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting,
                    input.Filter);

            var totalCount = input.Filter == null
                ? await _companyRepository.CountAsync()
                : await _companyRepository.CountAsync(
                    c => c.Name.Contains(input.Filter));

            return new PagedResultDto<CompanyDto>
                (totalCount, ObjectMapper.Map<List<Company>, List<CompanyDto>>(company));
        }

        public async Task<CompanyDto> CreateAsync(CreateCompanyDto input)
        {
            var company = await _companyManager.CreateAsync(input.Name);

            await _companyRepository.InsertAsync(company);

            return ObjectMapper.Map<Company, CompanyDto>(company);
        }

        public async Task UpdateAsync(Guid id, UpdateCompanyDto input)
        {
           var company = await _companyRepository.GetAsync(id);

           if (company.Name != input.Name)
               await _companyManager.ChangeNameAsync(company, input.Name);


           company.Name = input.Name;

           await _companyRepository.UpdateAsync(company);

        }

        public async Task DeleteAsync(Guid id)
        {
            await _companyRepository.DeleteAsync(id);
        }
    }
}
