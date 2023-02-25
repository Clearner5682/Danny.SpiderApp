using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Danny.SpiderApp.THZ
{
    public class Thz_Website:Entity<Guid>
    {
        public EnumCategory Category { get; set; }
        public string Url { get; set; }
    }
}
