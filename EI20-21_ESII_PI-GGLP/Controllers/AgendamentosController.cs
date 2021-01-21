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
    public class AgendamentosController : Controller
    {
        private readonly GGLPDbContext _context;

        public AgendamentosController(GGLPDbContext context)
        {
            _context = context;
        }

        // GET: Agendamentos
        public async Task<IActionResult> Index()
        {
            var gGLPDbContext = _context.Agendamento.Include(a => a.Pessoa).Include(a => a.PontoDeInteresse);
            return View(await gGLPDbContext.ToListAsync());
        }

        // GET: Agendamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamento
                .Include(a => a.Pessoa)
                .Include(a => a.PontoDeInteresse)
                .FirstOrDefaultAsync(m => m.AgendamentoID == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // GET: Agendamentos/Create
        public IActionResult Create()
        {
            ViewData["PessoaID"] = new SelectList(_context.Pessoa, "PessoaID", "PComments");
            ViewData["PontoDeInteresseID"] = new SelectList(_context.PontoDeInteresse, "PontoDeInteresseID", "PCoordenadas");
            return View();
        }

        // POST: Agendamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgendamentoID,PessoaID,PontoDeInteresseID,AData,AHora,ANumPessoas")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agendamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaID"] = new SelectList(_context.Pessoa, "PessoaID", "PComments", agendamento.PessoaID);
            ViewData["PontoDeInteresseID"] = new SelectList(_context.PontoDeInteresse, "PontoDeInteresseID", "PCoordenadas", agendamento.PontoDeInteresseID);
            return View(agendamento);
        }

        // GET: Agendamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamento.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }
            ViewData["PessoaID"] = new SelectList(_context.Pessoa, "PessoaID", "PComments", agendamento.PessoaID);
            ViewData["PontoDeInteresseID"] = new SelectList(_context.PontoDeInteresse, "PontoDeInteresseID", "PCoordenadas", agendamento.PontoDeInteresseID);
            return View(agendamento);
        }

        // POST: Agendamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgendamentoID,PessoaID,PontoDeInteresseID,AData,AHora,ANumPessoas")] Agendamento agendamento)
        {
            if (id != agendamento.AgendamentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoExists(agendamento.AgendamentoID))
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
            ViewData["PessoaID"] = new SelectList(_context.Pessoa, "PessoaID", "PComments", agendamento.PessoaID);
            ViewData["PontoDeInteresseID"] = new SelectList(_context.PontoDeInteresse, "PontoDeInteresseID", "PCoordenadas", agendamento.PontoDeInteresseID);
            return View(agendamento);
        }

        // GET: Agendamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamento
                .Include(a => a.Pessoa)
                .Include(a => a.PontoDeInteresse)
                .FirstOrDefaultAsync(m => m.AgendamentoID == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // POST: Agendamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agendamento = await _context.Agendamento.FindAsync(id);
            _context.Agendamento.Remove(agendamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoExists(int id)
        {
            return _context.Agendamento.Any(e => e.AgendamentoID == id);
        }
    }
}
