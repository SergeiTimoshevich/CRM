using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CRM.Employees
{
    public interface IEmployeeAppService : ICrudAppService<EmployeeDTO,Guid,PagedAndSortedResultRequestDto, CreateUpdateEmployeeDTO>
    {
        Task<ListResultDto<CompanyLookupDto>> GetCompanyLookupAsync();
    }
}
