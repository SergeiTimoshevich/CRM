using AutoMapper;
using CRM.Company;
using CRM.Employees;

namespace CRM
{
    public class CRMApplicationAutoMapperProfile : Profile
    {
        public CRMApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */


            CreateMap<Employee, EmployeeDTO>();
            CreateMap<CreateUpdateEmployeeDTO, Employee>();
            CreateMap<Company.Company, CompanyDto>();
            CreateMap<Company.Company, CompanyLookupDto>();
        }
    }
}
