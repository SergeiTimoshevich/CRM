using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace CRM.Employees
{
    public class EmployeeDTO : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public DateTime StartWorking { get; set; }
        public EmployeesType Type { get; set; }

        public  Guid CompanyId { get; set; }
        public  string CompanyName { get; set; }
    }
}
