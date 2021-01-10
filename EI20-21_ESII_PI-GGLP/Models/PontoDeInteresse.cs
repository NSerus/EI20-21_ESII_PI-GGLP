using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class PontoDeInteresse
    {
        // PontoDeInteresse_ID (PK)
        [Key]
        public int PontoDeInteresse_ID { get; set; }

        // Categoria_ID (FK)

        // Gestor_ID (FK)

        // PImagem
        [Required(ErrorMessage = "Introduza o nome da foto do novo Ponto de Interesse.")]
        [Display(Name = "Foto (nome)")]
        public string PImagem { get; set; }

        // PNome
        [Required(ErrorMessage = "Introduza o nome do novo Ponto de Interesse.")]
        [Display(Name = "Nome")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "O nome deverá ter no mínimo 5 caracters.")]
        public string PNome { get; set; }

        // PDescricao
        [Required(ErrorMessage = "Introduza uma breve descrição do novo Ponto de Interesse.")]
        [Display(Name = "Descrição")]
        [StringLength(400, MinimumLength = 10, ErrorMessage = "Mínimo 10 e máximo de 400 caracters.")]
        public string PDescricao { get; set; }

        // PEndereco
        [Required(ErrorMessage = "Introduza o endereço do novo Ponto de Interesse.")]
        [Display(Name = "Descrição (Rua, Cod-Postal, Localidade)")]
        [StringLength(200)]
        public string PEndereco { get; set; }

        // PCoordenadas
        [Required(ErrorMessage = "Introduza as coordenadas GPS do novo Ponto de Interesse.")]
        [Display(Name = "Coordenadas")]
        public string PCoordenadas { get; set; }

        // PContacto
        [Required(ErrorMessage = "Introduza o contacto telefónico do novo Ponto de Interesse.")]
        [Display(Name = "Contacto")]
        [RegularExpression(@"((9[1236]|2\d)\d{7})", ErrorMessage = "Contacto Inválido.")]
        public int PContacto { get; set; }

        // PEmail
        [Required(ErrorMessage = "Introduza o email do novo Ponto de Interesse.")]
        [Display(Name = "Email")]
        [StringLength(100)]
        [RegularExpression(@"(\w+(\.\w+)*@[a-zA-Z_]+?\.[a-zA-Z]{2,6})", ErrorMessage = "Email Inválido.")]
        [EmailAddress]
        public string PEmail { get; set; }

        // PNumPessoas
        [Required(ErrorMessage = "Introduza o número de Indivíduos do novo Ponto de Interesse.")]
        [Display(Name = "Número de Pessoas")]
        public int PNumPessoas { get; set; }

        // PMaxPessoas
        [Required(ErrorMessage = "Introduza o número máximo de Indivíduos permitidos no novo Ponto de Interesse.")]
        [Display(Name = "Máximo de Pessoas")]
        public int PMaxPessoas { get; set; }

        // PCovid
        [Required(ErrorMessage = "Introduza as normas COVID-19 aplicadas no novo Ponto de Interesse.")]
        [Display(Name = "COVID")]
        [StringLength(400, ErrorMessage = "Mínimo 10 e máximo de 400 caracters.")]
        public string PCovid { get; set; }

        // PEstado_ID (FK)
        [Display(Name = "Estado")]
        public int Estado_ID { get; set; }

        // PDataEstado
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Dia")]
        [DataType(DataType.Date)]
        public DateTime PDataEstado { get; set; }

        // PComments
        [Display(Name = "Commentários")]
    }
}
