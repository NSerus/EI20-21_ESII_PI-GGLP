using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class Pessoa
    {


        public int PessoaId { get; set; }


        [Required(ErrorMessage = "Introduza seu o Nome")]
        [RegularExpression ( @"[a-zA-Z]+")]
        [StringLength(50)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Introduza o Contato")]
        [RegularExpression(@"(9[1236]\d{7})|(2\d{8})", ErrorMessage = "Contato Incorreto")]
        public int Contato { get; set; }


        [Required(ErrorMessage = "Introduza o Email")]
        [EmailAddress(ErrorMessage = "Email Incorreto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Introzua um Comentario")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "No mínimo 10 carateres")]
        public string Comentario { get; set; }

    }
}
