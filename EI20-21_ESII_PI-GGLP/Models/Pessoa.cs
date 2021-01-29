using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class Pessoa
    {

        [Key]
        public int PessoaID { get; set; }

        // PNome
        [Required(ErrorMessage = "Introduza seu o Nome")]
        [RegularExpression ( @"[a-zA-Z]+")]
        [StringLength(50)]
        public string PNome { get; set; }

        // PContacto
        [Required(ErrorMessage = "Introduza o Contato")]
        [RegularExpression(@"(9[1236]\d{7})|(2\d{8})", ErrorMessage = "Contato Incorreto")]
        public int PContato { get; set; }

        // PEmail
        [Required(ErrorMessage = "Introduza o Email")]
        [EmailAddress(ErrorMessage = "Email Incorreto")]
        public string PEmail { get; set; }

        // PDataNasc
        [Required(ErrorMessage = "Introduza a Data do Nascimento")]
        //[RegularExpression(@"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$", ErrorMessage = "Data inválida")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        [Display(Name = "Estado (Data de entrada em vigor):")]
        [DataType(DataType.Date)]
        public DateTime CTDataNas { get; set; }

        // PNIF
        [Required(ErrorMessage = "Introduza NIF")]
        [RegularExpression(@"([a-z]|[A-Z]|[0-9])[0-9]{7}([a-z]|[A-Z]|[0-9])")]
        public int CTNIF { get; set; }

        // CTLocalidade
        [Required(ErrorMessage = "Introduza a localidade")]
        public string CTLocalidade { get; set; }

        // CTPais
        [Required(ErrorMessage = "Introduza o País")]
        [StringLength(30)]
        public string CTPais { get; set; }

        // CTEndereco
        [Required(ErrorMessage = "Introduza seu Endereço")]
        [RegularExpression(@"\d{4}(-\d{3})?", ErrorMessage = "Endereço inválido")]
        public string CTEndereco { get; set; }

        // PComments
        [Required(ErrorMessage = "Introzua um Comentario")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "No mínimo 10 carateres")]
        public string PComments { get; set; }


        // Pessoa Class '1 to *' Agendamento Class
        public ICollection<Agendamento> Agendamentos { get; set; }

        // Pessoa Class '1 to *' PontoDeInteresse Class
        //public ICollection<PontoDeInteresse> PontoDeInteresses { get; set; }
    }
}
