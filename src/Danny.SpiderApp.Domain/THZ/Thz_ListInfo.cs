using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Danny.SpiderApp.THZ
{
    public class Thz_ListInfo:Entity<Guid>
    {
        public EnumCategory Category { get; set; }
        public string Title { get; set; }
        public int? CommentNum { get; set; }
        public int? ViewNum { get; set; }
        public DateTime? PostTime { get; set; }
        public string ViewUrl { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}
