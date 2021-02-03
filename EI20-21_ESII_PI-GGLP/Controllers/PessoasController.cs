using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EI20_21_ESII_PI_GGLP.Data;
using EI20_21_ESII_PI_GGLP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EI20_21_ESII_PI_GGLP.Controllers
{
    public class PessoasController : Controller
    {
        private readonly GGLPDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PessoasController(GGLPDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Pessoas
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pessoa.ToListAsync());
        }

        // GET: Pessoas/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.PessoaID == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        public IActionResult Register()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterPessoaViewModel pessoaInfo)
        {
            if (ModelState.IsValid)
            {
                return View(pessoaInfo);
            }

            string username = pessoaInfo.Email;

            IdentityUser user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                ModelState.AddModelError("Email", "There is allready a customer with that email.");
                return View(pessoaInfo);
            }

            user = new IdentityUser(username);
            await _userManager.CreateAsync(user, pessoaInfo.Password);
            await _userManager.AddToRoleAsync(user, "User");

            IdentityUser identityUser = new IdentityUser
            {
                UserName = pessoaInfo.Name,
                Email = pessoaInfo.Email
            };

            Pessoa pessoa = new Pessoa
            {
                PNome = pessoaInfo.Name,
                PEmail = pessoaInfo.Email

                //PessoaID
                //PNome = pessoaInfo.Name,
                //PEmail = pessoaInfo.Email,
                //PContato = 928312764,
                //CTDataNas = new DateTime(1985, 02, 21),
                //CTNIF = 826496108,
                //CTLocalidade = "Aveiro",
                //CTPais = "Portugal",
                //CTEndereco = "Rua. Manel Antonio, 3648-143, Aveiro",
                //PComments = "Dono de Restaurante"
            };
            //_context.Add(pessoa);
            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");


        }


        //------------------------



        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaID,PNome,PContato,PEmail,CTDataNas,CTNIF,CTLocalidade,CTPais,CTEndereco,PComments,Password,ConfirmPassword")] Pessoa pessoa)
        {
            if (id != pessoa.PessoaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.PessoaID))
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
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pessoa = await _context.Pessoa
        //        .FirstOrDefaultAsync(m => m.PessoaID == id);
        //    if (pessoa == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pessoa);
        //}

        //// POST: Pessoas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var pessoa = await _context.Pessoa.FindAsync(id);
        //    _context.Pessoa.Remove(pessoa);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.PessoaID == id);
        }
    }
}
