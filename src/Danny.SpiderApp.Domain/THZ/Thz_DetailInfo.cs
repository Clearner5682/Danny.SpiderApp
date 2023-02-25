using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Danny.SpiderApp.THZ
{
    public class Thz_DetailInfo:Entity<Guid>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Actress { get; set; }
        public string Format { get; set; }
        public string Size { get; set; }
        public string Duration { get; set; }
        public string Mosaic { get; set; }
        public DateTime? ReleaseDate { get; set; }
        // 不包含baseUrl
        public string Image1Url { get; set; }
        // 不包含baseUrl
        public string Image2Url { get; set; }
        public string Image1Path { get; set; }
        public string Image2Path { get; set; }
        public string TorrentUrl { get; set; }

        public Guid ListInfoId { get; set; }
        public Thz_ListInfo ListInfo { get; set; }

        public Thz_DetailInfo(Guid id)
        {
            this.Id = id;
        }
    }
}
