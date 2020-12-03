using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EI20_21_ESII_PI_GGLP.Models;

namespace EI20_21_ESII_PI_GGLP.Data
{
    public class PontosDbContext : DbContext
    {
        public PontosDbContext (DbContextOptions<PontosDbContext> options)
            : base(options)
        {
        }

        public DbSet<EI20_21_ESII_PI_GGLP.Models.Pontos> Pontos { get; set; }
    }
}
