using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EI20_21_ESII_PI_GGLP.Data;
using EI20_21_ESII_PI_GGLP.Models;

namespace EI20_21_ESII_PI_GGLP.Controllers
{
    public class PontosController : Controller
    {
        private readonly GGLPDbContext _context;

        public PontosController(GGLPDbContext context)
        {
            _context = context;
        }

        // GET: Pontos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pontos.ToListAsync());
        }

        // GET: Pontos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontos = await _context.Pontos
                .FirstOrDefaultAsync(m => m.PontoId == id);
            if (pontos == null)
            {
                return NotFound();
            }

            return View(pontos);
        }

        // GET: Pontos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pontos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PontoId,PPicture,PNome,PCategoria,PDescricao,PEndereco,PCoordenadas,PHorarioSemana,PHorarioFimSemana,PHorarioFeriado,PContacto,PEmail,PPersonsNum,PTotalPersonsNum,PCovid")] Pontos pontos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pontos);
        }

        // GET: Pontos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontos = await _context.Pontos.FindAsync(id);
            if (pontos == null)
            {
                return NotFound();
            }
            return View(pontos);
        }

        // POST: Pontos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PontoId,PPicture,PNome,PCategoria,PDescricao,PEndereco,PCoordenadas,PHorarioSemana,PHorarioFimSemana,PHorarioFeriado,PContacto,PEmail,PPersonsNum,PTotalPersonsNum,PCovid")] Pontos pontos)
        {
            if (id != pontos.PontoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pontos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontosExists(pontos.PontoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pontos);
        }

        // GET: Pontos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontos = await _context.Pontos
                .FirstOrDefaultAsync(m => m.PontoId == id);
            if (pontos == null)
            {
                return NotFound();
            }

            return View(pontos);
        }

        // POST: Pontos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pontos = await _context.Pontos.FindAsync(id);
            _context.Pontos.Remove(pontos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontosExists(int id)
        {
            return _context.Pontos.Any(e => e.PontoId == id);
        }
    }
}
