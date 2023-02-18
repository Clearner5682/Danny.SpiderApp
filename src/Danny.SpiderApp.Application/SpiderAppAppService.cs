using System;
using System.Collections.Generic;
using System.Text;
using Danny.SpiderApp.Localization;
using Volo.Abp.Application.Services;

namespace Danny.SpiderApp;

/* Inherit your application services from this class.
 */
public abstract class SpiderAppAppService : ApplicationService
{
    protected SpiderAppAppService()
    {
        LocalizationResource = typeof(SpiderAppResource);
    }
}
