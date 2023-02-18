using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Danny.SpiderApp;

[Dependency(ReplaceServices = true)]
public class SpiderAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SpiderApp";
}
