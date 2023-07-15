using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZoologicoApiWeb.Models;

namespace ZoologicoApiWeb.Data
{
    public class ZoologicoApiWebContext : DbContext
    {
        public ZoologicoApiWebContext (DbContextOptions<ZoologicoApiWebContext> options)
            : base(options)
        {
        }

        public DbSet<ZoologicoApiWeb.Models.Registro> Registro { get; set; } = default!;

        public DbSet<ZoologicoApiWeb.Models.Usuario>? Usuario { get; set; }
    }
}
