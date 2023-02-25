using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Danny.SpiderApp.THZ
{
    public interface IThzRepository:IRepository<Thz_ListInfo>
    {
        Task<Thz_Website> GetDefaultThzWebSiteAsync();
        Task<Thz_Website> GetWebsiteByCategoryAsync(EnumCategory category);
        Task SaveThzInfo(List<Thz_ListInfo> listInfos, List<Thz_DetailInfo> detailInfos);
    }
}
