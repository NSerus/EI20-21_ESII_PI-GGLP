﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class Gestor : Pessoa
    {
        [Required (ErrorMessage = "Adicionar Departamento")]
        [StringLength(50)]
        public string GDepartment { get; set; }


    }
}
