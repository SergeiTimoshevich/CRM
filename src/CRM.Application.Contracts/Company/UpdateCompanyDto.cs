using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Company
{
    public class UpdateCompanyDto
    {
        [Required]
        public string Name { get; set; }
    }
}
