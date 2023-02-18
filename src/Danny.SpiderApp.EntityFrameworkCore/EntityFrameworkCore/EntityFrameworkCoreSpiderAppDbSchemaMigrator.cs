using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Danny.SpiderApp.Data;
using Volo.Abp.DependencyInjection;

namespace Danny.SpiderApp.EntityFrameworkCore;

public class EntityFrameworkCoreSpiderAppDbSchemaMigrator
    : ISpiderAppDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSpiderAppDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the SpiderAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SpiderAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
