using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab5_Gadgets.Models
{
    public class GadgetContext : DbContext
    {
        public GadgetContext(DbContextOptions<GadgetContext> options) : base(options)
        {

        }

        public DbSet<appointment> appointment { get; set; }
        public DbSet<customer> customer { get; set; }
        public DbSet<SalesRep> salesRep { get; set; }

    }
}
