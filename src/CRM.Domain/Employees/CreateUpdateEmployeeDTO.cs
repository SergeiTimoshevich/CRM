using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Employees
{
    public class CreateUpdateEmployeeDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartWorking { get; set; }

        [Required] public EmployeesType Type { get; set; } = EmployeesType.FullTime;
        public  Guid CompanyId  { get; set; }
    }
}
