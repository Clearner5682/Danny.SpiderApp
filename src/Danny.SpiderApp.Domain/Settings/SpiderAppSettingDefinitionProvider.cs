using Volo.Abp.Settings;

namespace Danny.SpiderApp.Settings;

public class SpiderAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SpiderAppSettings.MySetting1));
    }
}
