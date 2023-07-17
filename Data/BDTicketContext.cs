//Tickets
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AplicacionWeb_1_GG_ER.Models;

namespace ZoologicoApiWeb.Data
{
    public class BDTicketContext : DbContext
    {
        public BDTicketContext (DbContextOptions<BDTicketContext> options)
            : base(options)
        {
        }

        public DbSet<AplicacionWeb_1_GG_ER.Models.AddTickets> AddTickets { get; set; } = default!;

        public DbSet<AplicacionWeb_1_GG_ER.Models.Promocion>? Promocion { get; set; }
    }
}
