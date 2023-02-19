using Danny.SpiderApp.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;

namespace Danny.SpiderApp.THZ
{
    public class ThzRepository : EfCoreRepository<SpiderAppDbContext, Thz_ListInfo>,IThzRepository
    {
        private readonly IDbContextProvider<SpiderAppDbContext> dbContextProvider;

        public ThzRepository(IDbContextProvider<SpiderAppDbContext> dbContextProvider) : base(dbContextProvider)
        {
            this.dbContextProvider = dbContextProvider;
        }

        public async Task<Thz_Website> GetDefaultThzWebSiteAsync()
        {
            var dbContext = await this.dbContextProvider.GetDbContextAsync();

            return dbContext.Thz_Websites.FirstOrDefault();
        }

        [UnitOfWork]
        public async Task SaveThzInfo(List<Thz_ListInfo> listInfos,List<Thz_DetailInfo> detailInfos)
        {
            // 只有当ListInfo和DetailInfo都成功下载下来的才保存到数据库
            var combinedList = from a in listInfos
                               join b in detailInfos
                               on a.Id equals b.ListInfo.Id
                               select new { A = a, B = b };

            if (combinedList.Any())
            {
                var dbContext = await this.dbContextProvider.GetDbContextAsync();
                await dbContext.Thz_ListInfos.AddRangeAsync(combinedList.Select(o => o.A));
                await dbContext.Thz_DetailInfos.AddRangeAsync(combinedList.Select(o => o.B));
            }
        }
    }
}
