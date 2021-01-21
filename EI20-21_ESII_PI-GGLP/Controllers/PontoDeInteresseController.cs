using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EI20_21_ESII_PI_GGLP.Data;
using EI20_21_ESII_PI_GGLP.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace EI20_21_ESII_PI_GGLP.Controllers
{
    public class PontoDeInteresseController : Controller
    {
        private readonly GGLPDbContext _context;

        public PontoDeInteresseController(GGLPDbContext context)
        {
            _context = context;
        }

        // GET: PontoDeInteresse
        public async Task<IActionResult> Index(string name = null, int page = 1, string category = null)
        {
            var gGLPDbContext = _context.PontoDeInteresse.Include(p => p.Categoria).Include(p => p.Estado);

            // Horarios
            




            //return View(await gGLPDbContext.ToListAsync());

            var pagination = new PagingInfo
            {
                CurrentPage = page,
                PageSize = PagingInfo.DEFAULT_PAGE_SIZE,
                TotalItems = _context.PontoDeInteresse.Where(p => name == null || p.PNome.Contains(name) || p.Categoria.CTipo.Contains(name)).Count()
            };


            await gGLPDbContext.ToListAsync();
            return View(
                new PontoDeInteresseListViewModel
                {
                    PontoDeInteresses = _context.PontoDeInteresse.Where(p => name == null || p.PNome.Contains(name) || p.Categoria.CTipo.Contains(name))
                        .OrderBy(p => p.PNome)
                        .Skip((page - 1) * pagination.PageSize)
                        .Take(pagination.PageSize),
                    Pagination = pagination,
                    SearchName = name
                }
            );
        }

        // GET: PontoDeInteresse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoDeInteresse = await _context.PontoDeInteresse
                .Include(p => p.Categoria)
                .Include(p => p.Estado)
                .FirstOrDefaultAsync(m => m.PontoDeInteresseID == id);

            

            if (pontoDeInteresse == null)
            {
                return NotFound();
            }

            return View(pontoDeInteresse);
        }






        // GET: PontoDeInteresse/Create
        public IActionResult Create()
        {
            //ViewData["CTipo"] = new SelectList(_context.Categoria, "CTipo", "CTipo");
            ViewData["CategoriaID"] = new SelectList(_context.Categoria, "CategoriaID", "CTipo");
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "ENome");
            return View();
        }






        // POST: PontoDeInteresse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(PontoDeInteresse pontosdeinteresse, List<IFormFile> PImagem)
        {
            foreach (var item in PImagem)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        pontosdeinteresse.PImagem = stream.ToArray();
                    }
                }
            }
            _context.PontoDeInteresse.Add(pontosdeinteresse);
            _context.SaveChanges();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2([Bind("PontoDeInteresseID,CategoriaID,PNome,PDescricao,PEndereco,PCoordenadas,PContacto,PEmail,PNumPessoas,PMaxPessoas,EstadoID,PDataEstado,PComments")] PontoDeInteresse pontoDeInteresse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontoDeInteresse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categoria, "CategoriaID", "CategoriaID", pontoDeInteresse.CategoriaID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "EstadoID", pontoDeInteresse.EstadoID);

            return View(pontoDeInteresse);
        }
















        // GET: PontoDeInteresse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoDeInteresse = await _context.PontoDeInteresse.FindAsync(id);
            if (pontoDeInteresse == null)
            {
                return NotFound();
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categoria, "CategoriaID", "CategoriaID", pontoDeInteresse.CategoriaID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "EstadoID", pontoDeInteresse.EstadoID);
            return View(pontoDeInteresse);
        }

        // POST: PontoDeInteresse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PontoDeInteresseID,CategoriaID,PImagem,PNome,PDescricao,PEndereco,PCoordenadas,PContacto,PEmail,PNumPessoas,PMaxPessoas,EstadoID,PDataEstado,PComments")] PontoDeInteresse pontoDeInteresse)
        {

            if (id != pontoDeInteresse.PontoDeInteresseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pontoDeInteresse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoDeInteresseExists(pontoDeInteresse.PontoDeInteresseID))
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
            ViewData["CategoriaID"] = new SelectList(_context.Categoria, "CategoriaID", "CategoriaID", pontoDeInteresse.CategoriaID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "EstadoID", "EstadoID", pontoDeInteresse.EstadoID);
            return View(pontoDeInteresse);
        }

        // GET: PontoDeInteresse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoDeInteresse = await _context.PontoDeInteresse
                .Include(p => p.Categoria)
                .Include(p => p.Estado)
                .FirstOrDefaultAsync(m => m.PontoDeInteresseID == id);
            if (pontoDeInteresse == null)
            {
                return NotFound();
            }

            return View(pontoDeInteresse);
        }

        // POST: PontoDeInteresse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pontoDeInteresse = await _context.PontoDeInteresse.FindAsync(id);
            _context.PontoDeInteresse.Remove(pontoDeInteresse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontoDeInteresseExists(int id)
        {
            return _context.PontoDeInteresse.Any(e => e.PontoDeInteresseID == id);
        }
    }
}
