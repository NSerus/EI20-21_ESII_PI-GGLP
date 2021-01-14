using EI20_21_ESII_PI_GGLP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class SeedData
    {
        internal static void PopulatePontoDeInteresseTable(GGLPDbContext dbContext)
        {
            PopulatePontosDeInteresse(dbContext);
        }

        private static void PopulatePontosDeInteresse(GGLPDbContext dbContext)
        {
            if (dbContext.PontoDeInteresse.Any())
            {
                return;
            }

            dbContext.PontoDeInteresse.AddRange(
                new PontoDeInteresse
                {
                    //PontoDeInteresse_ID = 1,
                    //Categoria_ID = 1,
                    //PImagem = 
                    //PImagem
                    //PNome
                    //PDescricao
                    //PEndereco
                    //PCoordenadas
                    //PContacto
                    //PEmail
                    //PNumPessoas
                    //PMaxPessoas
                    //PEstado
                    //PDataEstado
                    //PComments
                }//,
            );

            dbContext.SaveChanges();
        }
    }
}
