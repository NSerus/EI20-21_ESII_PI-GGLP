using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class Estado
    {
        [Key]
        public int EstadoID { get; set; }


        public string ENome { get; set; }
        public string EComments { get; set; }



        // Estado Class '1 to *' PontoDeInteresse Class
        public ICollection<PontoDeInteresse> PontoDeInteresses { get; set; }

    }
}
