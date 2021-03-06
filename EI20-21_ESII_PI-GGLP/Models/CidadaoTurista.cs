﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class CidadaoTurista : Pessoa
    {
        [Required(ErrorMessage = "Introduza a Data do Nascimento")]
        [RegularExpression (@"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$", ErrorMessage = "Data inválida")]

        public int CTDataNas { get; set; }



        [Required(ErrorMessage = "Introduza NIF")]
        [RegularExpression (@"([a-z]|[A-Z]|[0-9])[0-9]{7}([a-z]|[A-Z]|[0-9])")]
        public int CTNIF { get; set; }




        [Required(ErrorMessage = "Introduza a localidade")]
        public string CTLocalidade { get; set; }




        [Required(ErrorMessage = "Introduza o País")]
        [StringLength(30)]
        public string CTPais { get; set; }




        [Required(ErrorMessage = "Introduza seu Endereço")]
        [RegularExpression(@"\d{4}(-\d{3})?", ErrorMessage ="Endereço inválido")]
        public string CTEndereco { get; set; }





    }
}
