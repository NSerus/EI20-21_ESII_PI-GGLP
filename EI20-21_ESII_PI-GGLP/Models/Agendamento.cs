using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class Agendamento
    {
        [Key]
        public int Agendamento_ID { get; set; }


        //FK
        public int Pessoa_ID { get; set; }
        //FK
        public int PontoDeIntersse_ID { get; set; }

        public string AData { get; set; }

        [Required(ErrorMessage = "Selecione a Hora")]
        public string AHora { get; set; }

        [Required(ErrorMessage = "Escreva o número de pessoas que o vai acompanhar")]
        [Range(1, 4, ErrorMessage = "O número do grupo tem que ser de 1 a 4 pessoas")]
        public int ANumPessoas { get; set; }

    }
}
