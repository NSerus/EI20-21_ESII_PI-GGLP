using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class Dia
    {
        // Dia_ID (PK)
        [Key]
        public int Dia_ID { get; set; }

        // DNome
        [Required(ErrorMessage = "Nome do Dia.")]
        [Display(Name = "DNome")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "O nome deverá ter no mínimo 5 caracters.")]
        public string DNome { get; set; }

        // DComments

    }
}
