using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class Categoria
    {
        [Key]
        public int Categoria_ID { get; set; }
        public string CTipo { get; set; }
        public string CComments { get; set; }
    }
}
