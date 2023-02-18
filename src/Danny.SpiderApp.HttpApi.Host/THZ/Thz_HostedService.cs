using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using System.Collections.Generic;

namespace Danny.SpiderApp.THZ
{
    public class Thz_HostedService : BackgroundService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<Thz_HostedService> logger;

        public Thz_HostedService(IHttpClientFactory httpClientFactory,ILogger<Thz_HostedService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var baseUrl = "http://85thz.com/";
            var listUrl = Thz_Consts.CaribListUrl;
            try
            {
                Func<string, Task<int>> funcGetPageCount = (async x => { return await GetPageCountAsync(x); });
                var pageCount = await funcGetPageCount.TryForTimes(listUrl);


                Func<string, Task<List<Thz_ListInfo>>> funcGetListInfo = (async x => { return await GetListInfoAsync(x); });
                Func<string, Task<Thz_DetailInfo>> funcGetDetailInfo = (async x => { return await GetDetailInfoAsync(x); });
                for (int i = pageCount; i <= pageCount; i++)
                {
                    var listInfos = await funcGetListInfo.TryForTimes(listUrl + "&page=" + i);
                    var detailInfos = new List<Thz_DetailInfo>();
                    foreach(var listInfo in listInfos)
                    {
                        var detailInfo = await funcGetDetailInfo.TryForTimes(baseUrl+listInfo.ViewUrl);
                        detailInfos.Add(detailInfo);
                        Thread.Sleep(1000);
                    }

                    var test = 1;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private async Task<int> GetPageCountAsync(string listUrl)
        {
            if (listUrl.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException();
            }
            IConfiguration config = Configuration.Default.WithDefaultLoader();
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument document = await context.OpenAsync(listUrl);
            var lastPageElement = document.QuerySelector("#fd_page_bottom .pg a.last");
            var lastPageStr = lastPageElement.TextContent.Replace("...","");
            var lastPageInt = 0;
            if(int.TryParse(lastPageStr,out lastPageInt))
            {
                return lastPageInt;
            }

            throw new Exception();
        }

        private async Task<List<Thz_ListInfo>> GetListInfoAsync(string url)
        {
            var listInfos = new List<Thz_ListInfo>();

            IConfiguration config = Configuration.Default.WithDefaultLoader();
            IBrowsingContext context=BrowsingContext.New(config);
            IDocument document = await context.OpenAsync(url);
            var tbody_normalthread_selector = "div#threadlist table#threadlisttableid tbody:nth-child(n+2)";
            IHtmlCollection<IElement> elements = document.QuerySelectorAll(tbody_normalthread_selector);
            if (elements.Length == 0)
            {
                throw new Exception("Get Nothing");
            }
            foreach(var element in elements)
            {
                var a_xst = element.QuerySelector("tr th a.s.xst");
                var title = a_xst.TextContent;
                var viewUrl = a_xst.Attributes["href"].Value;
                var postTimeElement = element.QuerySelector("tr td.by em span span");
                if (postTimeElement == null)
                {
                    postTimeElement= element.QuerySelector("tr td.by em span");
                }
                var postTime = "";
                if (postTimeElement.HasAttribute("title"))
                {
                    postTime= postTimeElement.GetAttribute("title");
                }
                else
                {
                    postTime = postTimeElement.TextContent;
                }
                var commentNum = element.QuerySelector("tr td.num a").TextContent;
                var viewNum= element.QuerySelector("tr td.num em").TextContent;

                var listInfo = new Thz_ListInfo();
                listInfo.Category = EnumCategory.Carib;
                listInfo.Title = title;
                listInfo.ViewUrl = viewUrl;
                listInfo.PostTime=Convert.ToDateTime(postTime);
                listInfo.CommentNum=Convert.ToInt32(commentNum);
                listInfo.ViewNum=Convert.ToInt32(viewNum);
                listInfos.Add(listInfo);
            }

            return listInfos;
        }

        private async Task<Thz_DetailInfo> GetDetailInfoAsync(string url)
        {
            var detailInfo = new Thz_DetailInfo();

            if(url.IsNullOrEmpty())
            {
                url = "http://85thz.com/forum.php?mod=viewthread&tid=2645182&extra=page%3D1%26filter%3Dtypeid%26typeid%3D36";
            }
            IConfiguration config = Configuration.Default.WithDefaultLoader();
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument document = await context.OpenAsync(url);
            var detailInfoElement = document.QuerySelector("div.t_fsz td.t_f");
            var contentStr = detailInfoElement.InnerHtml;
            if (!contentStr.IsNullOrWhiteSpace())
            {
                var contentArray = contentStr.Split("<br>");
                if (contentArray.Length > 0)
                {
                    var title = contentArray[0].RemoveUseless();
                    var actress = contentArray[1].RemoveUseless();
                    var format = contentArray[2].RemoveUseless();
                    var size = contentArray[3].RemoveUseless();
                    var duration = contentArray[4].RemoveUseless();
                    var mosaic = contentArray[5].RemoveUseless();
                    var releaseDate = contentArray[6].RemoveUseless();
                    var code = contentArray[8].RemoveUseless();

                    detailInfo.Title = title;
                    detailInfo.Actress = actress;
                    detailInfo.Format = format;
                    detailInfo.Size = size;
                    detailInfo.Duration = duration;
                    detailInfo.Mosaic = mosaic;
                    detailInfo.ReleaseDate = Convert.ToDateTime(releaseDate);
                    detailInfo.Code = code;
                }
            }
            else
            {
                throw new Exception("Get Nothing");
            }
            var imageElements = document.QuerySelectorAll("img.zoom");
            if (imageElements.Length > 0)
            {
                var image1Url = imageElements[0].Attributes["file"].Value;
                var image2Url = imageElements[1].Attributes["file"].Value;
                detailInfo.Image1Path = image1Url;
                detailInfo.Image2Path = image2Url;
            }

            return detailInfo;
        }
    }
}
