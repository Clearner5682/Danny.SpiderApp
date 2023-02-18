using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Danny.SpiderApp.Data;

/* This is used if database provider does't define
 * ISpiderAppDbSchemaMigrator implementation.
 */
public class NullSpiderAppDbSchemaMigrator : ISpiderAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
