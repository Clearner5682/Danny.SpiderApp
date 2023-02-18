using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Danny.SpiderApp;

[Dependency(ReplaceServices = true)]
public class SpiderAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SpiderApp";
}
