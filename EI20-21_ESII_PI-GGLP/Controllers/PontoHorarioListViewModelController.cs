using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EI20_21_ESII_PI_GGLP.Data;
using EI20_21_ESII_PI_GGLP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EI20_21_ESII_PI_GGLP.Controllers
{
    public class PontoHorarioListViewModelController : Controller
    {
        private readonly GGLPDbContext _context;

        public PontoHorarioListViewModelController(GGLPDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {

            //var tables = new PontoHorarioListViewModel
            //{
            //    PontoDeInteresses = _context.PontoDeInteresse.ToList()
            //};

            List<PontoDeInteresse> PontosLista = _context.PontoDeInteresse.ToList();
            List<Categoria> CategoriaLista = _context.Categoria.ToList();
            List<Estado> EstadoLista = _context.Estado.ToList();
            List<Horario> HorarioLista = _context.Horario.ToList();
            List<Dia> DiaLista = _context.Dia.ToList();

            //List<PontoHorarioListViewModel> PHViewModel = PontoHorarioListViewModel.

            return View();
        }
    }
}
