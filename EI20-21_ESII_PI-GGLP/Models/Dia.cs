using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class Dia
    {
        [Key]
        public int DiaID { get; set; }

        public string DNome { get; set; }
        public string DComments { get; set; }



        // Dia Class '1 to *' Horario Class
        public ICollection<Horario> Horarios { get; set; }
    }
}
