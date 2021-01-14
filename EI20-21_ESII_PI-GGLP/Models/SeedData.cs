using EI20_21_ESII_PI_GGLP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class SeedData
    {
        internal static void Populate(GGLPDbContext dbContext)
        {
            PopulateEstado(dbContext);
            PopulateCategoria(dbContext);
        }


        private static void PopulateEstado(GGLPDbContext dbContext)
        {
            if (dbContext.Estado.Any())
            {
                return;
            }

            dbContext.Estado.AddRange(
                new Estado
                {
                    ENome = "Disponível",
                    EComments = "O Ponto De Interesse encontrasse disponível para receber visitas."
                },
                new Estado
                {
                    ENome = "Indisponível",
                    EComments = "O Ponto De Interesse não se encontra disponível para receber visitas."
                },
                new Estado
                {
                    ENome = "Quarentena",
                    EComments = "O Ponto De Interesse encontrasse em quarentena devia a uma situação pandemica."
                }
            );

            dbContext.SaveChanges();
        }

        

        private static void PopulateCategoria(GGLPDbContext dbContext)
        {
            if (dbContext.Categoria.Any())
            {
                return;
            }

            dbContext.Categoria.AddRange(
                new Categoria
                {
                    CTipo = "Monumento",
                    CComments = "Estrutura ou edifício arquitectónico com história local."
                },
                new Categoria
                {
                    CTipo = "Museu",
                    CComments = "Local com exposições de objecto e cultura local."
                },
                new Categoria
                {
                    CTipo = "Restauração",
                    CComments = "Local com a oportunidade de apreciar diversos pratos locais."
                },
                new Categoria
                {
                    CTipo = "Shopping",
                    CComments = "Loja ou local com diversas lojas de diversas dos mais variados tipos."
                },
                new Categoria
                {
                    CTipo = "Espaço Aberto",
                    CComments = "Local ao ar livre com diversas actividades de lazer."
                }
            );

            dbContext.SaveChanges();
        }
    }
}
