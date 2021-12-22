using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Company;
using CRM.Employees;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace CRM.Contributors
{
    
    public class CRMStoreDataSeederContributor : IDataSeedContributor,ITransientDependency
    {
        private readonly IRepository<Employee, Guid> _employeeRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly CompanyManager _companyManager;

        public CRMStoreDataSeederContributor(
            IRepository<Employee,Guid> employeeRepository,
            ICompanyRepository companyRepository,
            CompanyManager companyManager
            )
        {
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
            _companyManager = companyManager;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (!(await _employeeRepository.AnyAsync()))
            {
              var company =   await _companyRepository
                    .InsertAsync(await _companyManager.CreateAsync("First company"), autoSave: true);


                await _employeeRepository.InsertAsync(new Employee()
                {
                    CompanyId = company.Id,
                    Name = "first_employee_name",
                    StartWorking = DateTime.Now,
                    Type = EmployeesType.FullTime
                }, autoSave: true);
            }


        }
    }
    
}
