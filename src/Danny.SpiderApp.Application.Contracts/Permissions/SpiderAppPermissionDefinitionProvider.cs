using Danny.SpiderApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Danny.SpiderApp.Permissions;

public class SpiderAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SpiderAppPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SpiderAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SpiderAppResource>(name);
    }
}
