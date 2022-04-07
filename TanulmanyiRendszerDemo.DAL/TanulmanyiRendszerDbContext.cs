using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanulmanyiRendszerDemo.DAL.Entities;

namespace TanulmanyiRendszerDemo.DAL
{
    public class TanulmanyiRendszerDbContext : DbContext
    {
        public TanulmanyiRendszerDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Szemeszter> Szemeszterek { get; set; }
        public DbSet<Kurzus> Kurzusok { get; set; }
    }
}
