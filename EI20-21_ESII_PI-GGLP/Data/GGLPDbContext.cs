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


        public DbSet<EI20_21_ESII_PI_GGLP.Models.Dia> Dia { get; set; }
        public DbSet<EI20_21_ESII_PI_GGLP.Models.PontoDeInteresse> PontoDeInteresse { get; set; }
        public DbSet<EI20_21_ESII_PI_GGLP.Models.Categoria> Categoria { get; set; }
        public DbSet<EI20_21_ESII_PI_GGLP.Models.Estado> Estado { get; set; }
        public DbSet<EI20_21_ESII_PI_GGLP.Models.Agendamento> Agendamento { get; set; }
        public DbSet<EI20_21_ESII_PI_GGLP.Models.Pessoa> Pessoa { get; set; }



        public DbSet<Pontos> Pontos { get; set; }

        public DbSet<EI20_21_ESII_PI_GGLP.Models.Contacts> Contactos { get; set; }
    }
}