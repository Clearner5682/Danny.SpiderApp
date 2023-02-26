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

            return dbContext.Thz_Websites.FirstOrDefault(o=>o.Category==EnumCategory.Home);
        }

        public async Task<Thz_Website> GetWebsiteByCategoryAsync(EnumCategory category)
        {
            var dbContext = await this.dbContextProvider.GetDbContextAsync();

            return dbContext.Thz_Websites.FirstOrDefault(o => o.Category == category);
        }

        [UnitOfWork]
        public async Task SaveThzInfo(Thz_ListInfo listInfo, Thz_DetailInfo detailInfo)
        {
            var dbContext = await this.dbContextProvider.GetDbContextAsync();
            await dbContext.Thz_ListInfos.AddAsync(listInfo);
            await dbContext.Thz_DetailInfos.AddAsync(detailInfo);
        }
    }
}
