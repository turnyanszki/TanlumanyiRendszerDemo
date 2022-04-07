using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanulmanyiRendszerDemo.BLL.Filter
{
    public class PagedFilter
    {
        public int Skip { get; set; }
        public int Take { get; set; } = 10;
    }
}
