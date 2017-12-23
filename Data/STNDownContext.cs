using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace STNDown.Models
{
    public class STNDownContext : DbContext
    {
        public STNDownContext (DbContextOptions<STNDownContext> options)
            : base(options)
        {
        }

        public DbSet<STNDown.Models.CheckedServer> CheckedServer { get; set; }
    }
}
