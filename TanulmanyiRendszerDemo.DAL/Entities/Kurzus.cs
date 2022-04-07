using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanulmanyiRendszerDemo.DAL.Entities
{
    public class Kurzus : EntityBase
    {
        public string Megnevezes { get; set; }
        public string OktatoNev { get; set; }
        public int SzemeszterId { get; set; }
        public Szemeszter Szemeszter { get; set; }
    }
}
