using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace CRM.Company
{
    public class CompanyAlreadyExistException : BusinessException
    {
        public CompanyAlreadyExistException(string name) : base(CRMDomainErrorCodes.CompanyAlreadyExist)
        {
            WithData("name", name);
        }
    }
}
