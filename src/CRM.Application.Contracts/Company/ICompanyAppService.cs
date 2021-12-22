using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CRM.Company
{
    public interface ICompanyAppService : IApplicationService
    {
        Task<CompanyDto> GetAsync(Guid id);

        Task<PagedResultDto<CompanyDto>> GetListAsync(GetCompanyListDto input);

        Task<CompanyDto> CreateAsync(CreateCompanyDto input);

        Task UpdateAsync(Guid id, UpdateCompanyDto input);

        Task DeleteAsync(Guid id);
    }
}
