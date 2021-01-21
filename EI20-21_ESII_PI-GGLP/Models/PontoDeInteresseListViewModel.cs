using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class PontoDeInteresseListViewModel
    {
        public IEnumerable<PontoDeInteresse> PontoDeInteresses { get; set; }
        public PagingInfo Pagination { get; set; }

        public string SearchName { get; set; }

    }
}
