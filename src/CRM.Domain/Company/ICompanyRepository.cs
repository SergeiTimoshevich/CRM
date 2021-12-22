using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace CRM.Company
{
    public interface ICompanyRepository : IRepository<Company,Guid>
    {
        Task<Company> FindByNameAsync(string name);

        Task<List<Company>> GetListAsync(int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null);
    }
}
