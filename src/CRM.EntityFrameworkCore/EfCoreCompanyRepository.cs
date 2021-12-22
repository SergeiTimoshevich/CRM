using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Company;
using CRM.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CRM
{
    public class EfCoreCompanyRepository : EfCoreRepository<CRMDbContext,Company.Company,Guid>, ICompanyRepository
    {
        public EfCoreCompanyRepository(IDbContextProvider<CRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Company.Company> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Company.Company>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    x => x.Name.Contains(filter)
                ).ToListAsync();
        }
    }
}
