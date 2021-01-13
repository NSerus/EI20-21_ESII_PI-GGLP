using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class RegrasCOVID
    {
        [Key]
        public int RegrasCOVID_ID { get; set; }


        // RDescricao
        [Required(ErrorMessage = "Introduza uma breve descrição da regra.")]
        [Display(Name = "Descrição")]
        [StringLength(400, MinimumLength = 10, ErrorMessage = "Mínimo 10 e máximo de 400 caracters.")]
        public string RDescricao { get; set; }

        // RDataVigor
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        [Display(Name = "Data de entrada em vigor")]
        [DataType(DataType.Date)]
        public DateTime RDataVigor { get; set; }
    }
}
