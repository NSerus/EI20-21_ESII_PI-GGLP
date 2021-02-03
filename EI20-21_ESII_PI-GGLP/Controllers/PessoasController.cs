using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EI20_21_ESII_PI_GGLP.Data;
using EI20_21_ESII_PI_GGLP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

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
            if (!ModelState.IsValid)
            {
                return View(pessoaInfo);
            }

            string username = pessoaInfo.PEmail;
            IdentityUser user = await _userManager.FindByNameAsync(username);


            if (user != null)
            {
                ModelState.AddModelError("PEmail", "Já existe um utilizador com esse e-mail.");
                return View(pessoaInfo);
            }

            user = new IdentityUser(username);
            await _userManager.CreateAsync(user, pessoaInfo.Password);
            await _userManager.AddToRoleAsync(user, "Pessoa");


            Pessoa pessoa = new Pessoa
            {
                PNome = pessoaInfo.PNome,
                PContato = pessoaInfo.PContato,
                PEmail = pessoaInfo.PEmail,
                CTDataNas = pessoaInfo.CTDataNas,
                CTNIF = pessoaInfo.CTNIF,
                CTLocalidade = pessoaInfo.CTLocalidade,
                CTPais = pessoaInfo.CTPais,
                CTEndereco = pessoaInfo.CTEndereco,
                PComments = pessoaInfo.PComments
            };


            _context.Add(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");
        
        }


        // EDIT
        [Authorize(Roles = "Pessoa")]
        public async Task<IActionResult> EditPersonalData()
        {
            string email = User.Identity.Name;

            var pessoa = await _context.Pessoa.SingleOrDefaultAsync(p => p.PEmail == email);
            if (pessoa == null)
            {
                return NotFound();
            }

            EditLoggedInPessoaViewModel pessoaInfo = new EditLoggedInPessoaViewModel
            {
                PNome = pessoa.PNome,
                PContato = pessoa.PContato,
                PEmail = pessoa.PEmail,
                CTDataNas = pessoa.CTDataNas,
                CTNIF = pessoa.CTNIF,
                CTLocalidade = pessoa.CTLocalidade,
                CTPais = pessoa.CTPais,
                CTEndereco = pessoa.CTEndereco,
                PComments = pessoa.PComments
            };

            return View(pessoaInfo);
        }

        // POST: Pessoas/EditLoggedInPessoaViewModel
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pessoa")]
        public async Task<IActionResult> EditPersonalData(EditLoggedInPessoaViewModel pessoa)
        {

            if (!ModelState.IsValid)
            {
                return View(pessoa);
            }


            string email = User.Identity.Name;

            var pessoaLoggedin = await _context.Pessoa.SingleOrDefaultAsync(p => p.PEmail == email);
            if (pessoaLoggedin == null)
            {
                return NotFound();
            }

            pessoaLoggedin.PNome = pessoa.PNome;
            pessoaLoggedin.PContato = pessoa.PContato;
            //pessoaLoggedin.PEmail = pessoa.PEmail;
            pessoaLoggedin.CTDataNas = pessoa.CTDataNas;
            pessoaLoggedin.CTNIF = pessoa.CTNIF;
            pessoaLoggedin.CTLocalidade = pessoa.CTLocalidade;
            pessoaLoggedin.CTPais = pessoa.CTPais;
            pessoaLoggedin.CTEndereco = pessoa.CTEndereco;
            pessoaLoggedin.PComments = pessoa.PComments;

            //if (pessoaLoggedin.PessoaID != pessoa.PessoaID)
            //{
            //    return NotFound();
            //}

            try
            {
                _context.Update(pessoaLoggedin);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!PessoaExists(pessoa.PessoaID))
                //{
                //    return NotFound();
                //}
                //else
                //{
                    throw;
                //}
            }
            return RedirectToAction(nameof(Index), "Home");
        }













        // GET: Pessoas/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaID,PNome,PContato,PEmail,CTDataNas,CTNIF,CTLocalidade,CTPais,CTEndereco,PComments")] Pessoa pessoa)
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

        // POST: Pessoas/Delete/5
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
