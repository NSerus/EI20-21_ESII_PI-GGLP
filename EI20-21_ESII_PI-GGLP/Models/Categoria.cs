using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }

        public string CTipo { get; set; }
        public string CComments { get; set; }


        // Categoria Class '1 to *' PontoDeInteresse Class
        public ICollection<PontoDeInteresse> PontoDeInteresses { get; set; }
    }
}
