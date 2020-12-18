using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class Agendamentos
    {
        [Key]
        public int SchedulingtId { get; set; }

        [Required(ErrorMessage = "Escreva o seu Local onde deseja ir")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O nome do local deve ter pelo menos 2 caracteres e maximo de 80")]
        public string Local { get; set; }
        [Required(ErrorMessage = "Selecione o dia em que vai estar no local")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Selecione a Hora")]
        public string Hour { get; set; }
        [Required(ErrorMessage = "Escreva o número de pessoas que o vai acompanhar")]
        [Range(1, 4, ErrorMessage = "O número do grupo tem que ser de 1 a 4 pessoas")]
        public string Persons { get; set; }
    }
}
