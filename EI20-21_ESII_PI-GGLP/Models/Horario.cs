using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class Horario
    {
        [Key]
        public int Horario_ID { get; set; }
        //FK
        public int PontosDeInteresse_ID { get; set; }
        //FK
        public int Dia_ID { get; set; }
        public int HInicio { get; set; }
        public int HFim { get; set; }
        public string HCovid { get; set; }
        public string UComments{ get; set; }
    }
}
