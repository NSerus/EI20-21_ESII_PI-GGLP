using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class PontoHorarioListViewModel
    {
        public IEnumerable<PontoDeInteresse> PontoDeInteresses { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }
        public IEnumerable<Estado> Estados { get; set; }
        public IEnumerable<Horario> Horarios { get; set; }
        public IEnumerable<Dia> Dias { get; set; }
    }
}
