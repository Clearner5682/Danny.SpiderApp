using Danny.SpiderApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Danny.SpiderApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SpiderAppController : AbpControllerBase
{
    protected SpiderAppController()
    {
        LocalizationResource = typeof(SpiderAppResource);
    }
}
