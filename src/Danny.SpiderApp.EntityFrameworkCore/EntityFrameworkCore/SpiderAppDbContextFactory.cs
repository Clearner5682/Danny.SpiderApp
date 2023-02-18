using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Danny.SpiderApp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class SpiderAppDbContextFactory : IDesignTimeDbContextFactory<SpiderAppDbContext>
{
    public SpiderAppDbContext CreateDbContext(string[] args)
    {
        SpiderAppEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SpiderAppDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new SpiderAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Danny.SpiderApp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
