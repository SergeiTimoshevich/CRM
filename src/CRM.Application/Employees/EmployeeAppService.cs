using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Company;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace CRM.Employees
{
    public class EmployeeAppService : CrudAppService<Employee, EmployeeDTO, Guid, PagedAndSortedResultRequestDto, CreateUpdateEmployeeDTO>, IEmployeeAppService
    {
        private readonly IRepository<Company.Company, Guid> _companyRepository;

        public EmployeeAppService(IRepository<Employee, Guid> repository, ICompanyRepository companyRepository) : base(repository)
        {
            _companyRepository = companyRepository;
        }

        public override async Task<EmployeeDTO> GetAsync(Guid id)
        {
            var queryable = await Repository.GetQueryableAsync();

            var res = queryable.Select(employee =>
            new
            {
                employee,
                employee.Company.Name
            }).FirstOrDefault(x => x.employee.Id == id);

            if (res is null)
                throw new EntityNotFoundException(typeof(Employee), id);

            var employeeDto = ObjectMapper.Map<Employee, EmployeeDTO>(res.employee);
            employeeDto.Name = res.Name;
            return employeeDto;
        }

        public override async Task<PagedResultDto<EmployeeDTO>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = queryable.Select(employee =>
                new
                {
                    employee,
                    employee.Company.Name
                });
            var queryResult = await AsyncExecuter.ToListAsync(query);

            var result = queryResult.Select(x =>
            {
                var employeeDto = ObjectMapper.Map<Employee, EmployeeDTO>(x.employee);
                employeeDto.CompanyName = x.Name;
                return employeeDto;
            }).ToList();

            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<EmployeeDTO>(
                totalCount, result
            );
        }

        public async Task<ListResultDto<CompanyLookupDto>> GetCompanyLookupAsync()
        {
            var res = await _companyRepository.GetListAsync();

            return new ListResultDto<CompanyLookupDto>(
                ObjectMapper.Map<List<Company.Company>, List<CompanyLookupDto>>(res));
        }
    }
}
