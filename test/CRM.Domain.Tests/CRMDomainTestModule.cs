using CRM.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CRM
{
    [DependsOn(
        typeof(CRMEntityFrameworkCoreTestModule)
        )]
    public class CRMDomainTestModule : AbpModule
    {

    }
}