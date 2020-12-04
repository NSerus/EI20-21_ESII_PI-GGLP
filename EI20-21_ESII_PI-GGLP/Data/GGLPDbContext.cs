using EI20_21_ESII_PI_GGLP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Data
{
    public class GGLPDbContext : DbContext
    {
        public GGLPDbContext(DbContextOptions<GGLPDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pontos> Pontos { get; set; }

        //public DbSet<Contacts> Contactos { get; set; }
    }
}