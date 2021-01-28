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
    public class HorariosController : Controller
    {
        private readonly GGLPDbContext _context;

        public HorariosController(GGLPDbContext context)
        {
            _context = context;
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {
            var gGLPDbContext = _context.Horario.Include(h => h.Dia).Include(h => h.PontoDeInteresse).Include(h => h.PontoDeInteresse.Categoria).Include(h => h.PontoDeInteresse.Estado);

            return View(await gGLPDbContext.ToListAsync());
        }

        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                .Include(h => h.Dia)
                .Include(h => h.PontoDeInteresse)
                .Include(h => h.PontoDeInteresse.Categoria)
                .Include(h => h.PontoDeInteresse.Estado)
                .FirstOrDefaultAsync(m => m.HorarioID == id);
            if (horario == null)
            {
                return NotFound();
            }
            return View(horario);
        }

        // GET: Horarios/Create
        public IActionResult Create()
        {
            ViewData["DiaID"] = new SelectList(_context.Dia, "DiaID", "DNome");
            ViewData["PontoDeInteresseID"] = new SelectList(_context.PontoDeInteresse, "PontoDeInteresseID", "PNome");
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HorarioID,PontoDeInteresseID,DiaID,HInicio,HFim")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiaID"] = new SelectList(_context.Dia, "DiaID", "DNome", horario.DiaID);
            ViewData["PontoDeInteresseID"] = new SelectList(_context.PontoDeInteresse, "PontoDeInteresseID", "PNome", horario.PontoDeInteresseID);
            return View(horario);
        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }
            ViewData["DiaID"] = new SelectList(_context.Dia, "DiaID", "DNome", horario.DiaID);
            ViewData["PontoDeInteresseID"] = new SelectList(_context.PontoDeInteresse, "PontoDeInteresseID", "PNome", horario.PontoDeInteresseID);
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HorarioID,PontoDeInteresseID,DiaID,HInicio,HFim")] Horario horario)
        {
            if (id != horario.HorarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.HorarioID))
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
            ViewData["DiaID"] = new SelectList(_context.Dia, "DiaID", "DNome", horario.DiaID);
            ViewData["PontoDeInteresseID"] = new SelectList(_context.PontoDeInteresse, "PontoDeInteresseID", "PNome", horario.PontoDeInteresseID);
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                .Include(h => h.Dia)
                .Include(h => h.PontoDeInteresse)
                .FirstOrDefaultAsync(m => m.HorarioID == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horario = await _context.Horario.FindAsync(id);
            _context.Horario.Remove(horario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioExists(int id)
        {
            return _context.Horario.Any(e => e.HorarioID == id);
        }
    }
}
