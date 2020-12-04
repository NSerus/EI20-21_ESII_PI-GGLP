using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class Contacts
    {
        [Key]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Escreva o seu nome por favor")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O nome deve ter pelo menos 2 caracteres e maximo de 80")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Escreva o seu Nº por favor")]
        [Phone(ErrorMessage = "numero mal composto")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Escreva o seu email por favor")]
        [EmailAddress(ErrorMessage = "E-mail mal composto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Escolha um tipo por favor")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Escreva uma Descrição")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O nome deve ter pelo menos 2 caracteres e maximo de 80")]
        public string Desc { get; set; }

    }
}
