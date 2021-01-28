using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class Horario
    {
        [Key]
        public int HorarioID { get; set; }


        // Horario Class '* to 1' PontoDeInteresse Class
        [Display(Name = "Confirme o Ponto de Interesse:")]
        public int PontoDeInteresseID { get; set; }
        public PontoDeInteresse PontoDeInteresse { get; set; }


        // Horario Class '* to 1' Dia Class
        [Display(Name = "O tipo de Dia:")]
        public int DiaID { get; set; }
        public Dia Dia { get; set; }

        [Required(ErrorMessage = "Introduza uma hora de Início válida.")]
        [Display(Name = "Hora de Início:")]
        public int HInicio { get; set; }

        [Required(ErrorMessage = "Introduza uma hora de Fim válida.")]
        [Display(Name = "Hora de Fim:")]
        public int HFim { get; set; }



        //public string HCovid { get; set; }
        //public string HComments{ get; set; }
    }
}
