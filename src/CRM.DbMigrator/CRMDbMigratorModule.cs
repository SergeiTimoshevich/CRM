using CRM.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace CRM.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(CRMEntityFrameworkCoreModule),
        typeof(CRMApplicationContractsModule)
        )]
    public class CRMDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
