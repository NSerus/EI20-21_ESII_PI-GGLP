using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class Pontos
    {
        // ID
        [Key]
        public int PontoId { get; set; }

        // PICTURE
        [Required(ErrorMessage = "Introduza o nome da foto do novo Ponto de Interesse.")]
        [Display(Name = "Foto (nome)")]
        public string PPicture { get; set; }

        // NAME
        [Required(ErrorMessage = "Introduza o nome do novo Ponto de Interesse.")]
        [Display(Name = "Nome")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "O nome deverá ter no mínimo 5 caracters.")]
        public string PNome { get; set; }

        // CATEGORY
        [Required(ErrorMessage = "Introduza a categoria do novo Ponto de Interesse.")]
        [Display(Name = "Categoria")]
        public string PCategoria { get; set; }

        // DESCRIPTION
        [Required(ErrorMessage = "Introduza uma breve descrição do novo Ponto de Interesse.")]
        [Display(Name = "Descrição")]
        [StringLength(400, MinimumLength = 10, ErrorMessage = "Mínimo 10 e máximo de 400 caracters.")]
        public string PDescricao { get; set; }

        // ADDRESS
        [Required(ErrorMessage = "Introduza o endereço do novo Ponto de Interesse.")]
        [Display(Name = "Descrição (Rua, Cod-Postal, Localidade)")]
        [StringLength(200)]
        public string PEndereco { get; set; }

        // GPS
        [Required(ErrorMessage = "Introduza as coordenadas GPS do novo Ponto de Interesse.")]
        [Display(Name = "Coordenadas")]
        public string PCoordenadas { get; set; }

        // SCHEDULE WEEK
        [Required(ErrorMessage = "Introduza o horário dos dias utéis do novo Ponto de Interesse.")]
        [Display(Name = "Horário (dia útil)")]
        [StringLength(100)]
        public string PHorarioSemana { get; set; }

        // SCHEDULE WEEKEND
        [Required(ErrorMessage = "Introduza o horário de fim de semana do novo Ponto de Interesse.")]
        [Display(Name = "Horário (fim de semana)")]
        [StringLength(100)]
        public string PHorarioFimSemana { get; set; }

        // SCHEDULE HOLYDAY
        [Required(ErrorMessage = "Introduza o horário de feriado do novo Ponto de Interesse.")]
        [Display(Name = "Horário (feriado)")]
        [StringLength(100)]
        public string PHorarioFeriado { get; set; }

        // PHONE
        [Required(ErrorMessage = "Introduza o contacto telefónico do novo Ponto de Interesse.")]
        [Display(Name = "Contacto")]
        [RegularExpression(@"((9[1236]|2\d)\d{7})", ErrorMessage = "Contacto Inválido.")]

        //[Phone]
        public int PContacto { get; set; }

        // EMAIL
        [Required(ErrorMessage = "Introduza o email do novo Ponto de Interesse.")]
        [Display(Name = "Email")]
        [StringLength(100)]
        [RegularExpression(@"(\w+(\.\w+)*@[a-zA-Z_]+?\.[a-zA-Z]{2,6})", ErrorMessage = "Email Inválido.")]
        [EmailAddress]
        public string PEmail { get; set; }

        // #PERSONS
        [Required(ErrorMessage = "Introduza o número de Indivíduos do novo Ponto de Interesse.")]
        [Display(Name = "# Pessoas (default = 0)")]
        public int PPersonsNum { get; set; }

        // #TOTALPERSONS
        [Required(ErrorMessage = "Introduza o número máximo de Indivíduos permitidos no novo Ponto de Interesse.")]
        [Display(Name = "# Total Pessoas")]
        public int PTotalPersonsNum { get; set; }

        // COVID
        [Required(ErrorMessage = "Introduza as normas COVID-19 aplicadas no novo Ponto de Interesse.")]
        [Display(Name = "COVID-19")]
        [StringLength(400, MinimumLength = 10, ErrorMessage = "Mínimo 10 e máximo de 400 caracters.")]
        public string PCovid { get; set; }
    }
}
