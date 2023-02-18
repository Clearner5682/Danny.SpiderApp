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
            await Task.Run(async () =>
            {
                //while (true)
                //{
                //    if (stoppingToken.CanBeCanceled && stoppingToken.IsCancellationRequested)
                //    {
                //        break;
                //    }

                //    this.logger.LogInformation($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                //    Thread.Sleep(1000);
                //}
                await GetListInfo();
            });
        }

        private async Task GetListInfo()
        {
            var listInfos = new List<Thz_ListInfo>();

            IConfiguration config = Configuration.Default.WithDefaultLoader();
            IBrowsingContext context=BrowsingContext.New(config);
            IDocument document = await context.OpenAsync(Thz_Consts.CaribListUrl);
            var tbody_normalthread_selector = "div#threadlist table#threadlisttableid tbody:nth-child(n+2)";
            IHtmlCollection<IElement> elements = document.QuerySelectorAll(tbody_normalthread_selector);
            foreach(var element in elements)
            {
                var a_xst = element.QuerySelector("tr th a.s.xst");
                var title = a_xst.TextContent;
                var viewUrl = a_xst.Attributes["href"].Value;
                var postTimeElement = element.QuerySelector("tr td.by em span span");
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

            await Task.CompletedTask;
        }

        private async Task GetDetailInfo(string detailUrl)
        {
            if(detailUrl.IsNullOrEmpty())
            {
                detailUrl = "http://85thz.com/forum.php?mod=viewthread&tid=2645182&extra=page%3D1%26filter%3Dtypeid%26typeid%3D36";
            }
            IConfiguration config = Configuration.Default.WithDefaultLoader();
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument document = await context.OpenAsync(detailUrl);
            var detailInfoElement = document.QuerySelector("div.t_fsz td.t_f");
            var contentStr = detailInfoElement.InnerHtml;
            if (!contentStr.IsNullOrWhiteSpace())
            {

            }

            await Task.CompletedTask;
        }
    }
}
