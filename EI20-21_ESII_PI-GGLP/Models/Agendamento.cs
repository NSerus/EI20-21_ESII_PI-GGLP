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
        public int AgendamentoID { get; set; }


        // Agendamento Class '* to 1' Pessoa Class
        public int PessoaID { get; set; }
        public Pessoa Pessoa { get; set; }


        // Agendamento Class '* to 1' PontoDeInteresse Class
        public int PontoDeInteresseID { get; set; }
        public PontoDeInteresse PontoDeInteresse { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        [Display(Name = "Estado (Data de entrada em vigor):")]
        [DataType(DataType.Date)]
        public DateTime AData { get; set; }

        [Required(ErrorMessage = "Selecione a Hora")]
        public string AHora { get; set; }

        [Required(ErrorMessage = "Escreva o número de pessoas que o vai acompanhar")]
        [Range(1, 4, ErrorMessage = "O número do grupo tem que ser de 1 a 4 pessoas")]
        public int ANumPessoas { get; set; }

    }
}
