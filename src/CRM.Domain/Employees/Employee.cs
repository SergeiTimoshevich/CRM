using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace CRM.Employees
{
    public class Employee : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public DateTime StartWorking { get; set; }
        public EmployeesType Type { get; set; }

        public Guid CompanyId { get; set; }
        public  Company.Company Company { get; set; }
     

    }
}
