using System.Threading.Tasks;

namespace Danny.SpiderApp.Data;

public interface ISpiderAppDbSchemaMigrator
{
    Task MigrateAsync();
}
