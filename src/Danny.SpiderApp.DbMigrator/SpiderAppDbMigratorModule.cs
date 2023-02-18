using Danny.SpiderApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Danny.SpiderApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SpiderAppEntityFrameworkCoreModule),
    typeof(SpiderAppApplicationContractsModule)
    )]
public class SpiderAppDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
