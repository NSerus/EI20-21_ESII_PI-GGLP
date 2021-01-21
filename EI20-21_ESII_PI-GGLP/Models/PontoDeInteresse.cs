using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class PontoDeInteresse
    {
        // PontoDeInteresseID (PK)
        [Key]
        public int PontoDeInteresseID { get; set; }


        // PontoDeInteresse Class '1 to *' Horario Class
        public ICollection<Horario> Horarios { get; set; }


        // PontoDeInteresse Class '* to 1' Categoria Class
        [Display(Name = "Tipo de Ponto de Interesse:")]
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }


        // PontoDeInteresse Class '* to 1' Pessoa Class
        //public int GestorID { get; set; }
        //public Pessoa Pessoa { get; set; }


        // PImagem
        //[Required(ErrorMessage = "Introduza uma foto do novo Ponto de Interesse.")]
        [Display(Name = "Imagem:")]
        public byte[] PImagem { get; set; }

        // PNome
        [Required(ErrorMessage = "Introduza o nome do novo Ponto de Interesse.")]
        [Display(Name = "Nome:")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "O nome deverá ter no mínimo 5 caracters.")]
        public string PNome { get; set; }

        // PDescricao
        [Required(ErrorMessage = "Introduza uma breve descrição do novo Ponto de Interesse.")]
        [Display(Name = "Descrição:")]
        [StringLength(400, MinimumLength = 10, ErrorMessage = "Mínimo 10 e máximo de 400 caracters.")]
        public string PDescricao { get; set; }

        // PEndereco
        [Required(ErrorMessage = "Introduza o endereço do novo Ponto de Interesse.")]
        [Display(Name = "Endereço (Rua, Cod-Postal, Localidade):")]
        [StringLength(200)]
        public string PEndereco { get; set; }

        // PCoordenadas
        [Required(ErrorMessage = "Introduza as coordenadas do novo Ponto de Interesse.")]
        [Display(Name = "Coordenadas:")]
        public string PCoordenadas { get; set; }

        // PContacto
        [Required(ErrorMessage = "Introduza o contacto telefónico do novo Ponto de Interesse.")]
        [Display(Name = "Contacto:")]
        [RegularExpression(@"((9[1236]|2\d)\d{7})", ErrorMessage = "Contacto Inválido.")]
        public int PContacto { get; set; }

        // PEmail
        [Required(ErrorMessage = "Introduza o email do novo Ponto de Interesse.")]
        [Display(Name = "Email:")]
        [StringLength(100)]
        [RegularExpression(@"(\w+(\.\w+)*@[a-zA-Z_]+?\.[a-zA-Z]{2,6})", ErrorMessage = "Email Inválido.")]
        [EmailAddress]
        public string PEmail { get; set; }

        // PNumPessoas
        [Required(ErrorMessage = "Introduza o número de Indivíduos do novo Ponto de Interesse.")]
        [Display(Name = "Número existentes de Pessoas:")]
        public int PNumPessoas { get; set; }

        // PMaxPessoas
        [Required(ErrorMessage = "Introduza o número máximo de Indivíduos permitidos no novo Ponto de Interesse.")]
        [Display(Name = "Máximo de Pessoas Permitidas:")]
        public int PMaxPessoas { get; set; }

        // PCovid
        /*[Required(ErrorMessage = "Introduza as normas COVID-19 aplicadas no novo Ponto de Interesse.")]
        [Display(Name = "COVID")]
        [StringLength(400, ErrorMessage = "Mínimo 10 e máximo de 400 caracters.")]
        public string PCovid { get; set; }*/



        // PontoDeInteresse Class '* to 1' Estado Class
        [Display(Name = "Estado:")]
        public int EstadoID { get; set; }
        public Estado Estado { get; set; }



        // PDataEstado
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        [Display(Name = "Estado (Data de entrada em vigor):")]
        [DataType(DataType.Date)]
        public DateTime PDataEstado { get; set; }

        // PComments
        [Display(Name = "Commentários:")]
        [StringLength(400, MinimumLength = 10, ErrorMessage = "Mínimo 10 e máximo de 400 caracters.")]
        public string PComments { get; set; }



        // PontoDeInteresse Class '1 to *' Agendamento Class
        public ICollection<Agendamento> Agendamentos { get; set; }
    }
}
