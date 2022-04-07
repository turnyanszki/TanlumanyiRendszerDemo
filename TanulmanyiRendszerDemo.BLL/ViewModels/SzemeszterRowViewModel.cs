using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanulmanyiRendszerDemo.BLL.ViewModels
{
    public class SzemeszterRowViewModel
    {
        public string Megnevezes { get; set; }
        public DateTime Kezdet { get; set; }
        public DateTime Veg { get; set; }
        public DateTime TargyjelentkezesKezdet { get; set; }
        public DateTime TargyJelentkezesVeg { get; set; }
        public DateTime VizsgajelentkezesKezdet { get; set; }
        public DateTime VizsgajelentkezesVeg { get; set; }
        public int KurzusokSzama { get; set; }
    }
}
