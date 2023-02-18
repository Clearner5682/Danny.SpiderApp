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
        public string Image1Path { get; set; }
        public string Image2Path { get; set; }
        public string TorrentUrl { get; set; }
    }
}
