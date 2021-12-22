using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace CRM
{
    [Dependency(ReplaceServices = true)]
    public class CRMBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "CRM";
    }
}
