using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoIndigenas.Models;

namespace ProjetoIndigenas.Controllers
{
    public class DenunciaController : Controller
    {
        private readonly Contexto _context;

        public DenunciaController(Contexto context)
        {
            _context = context;
        }

        // GET: Denuncias
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Denuncia.Include(d => d.Pessoa);
            return View(await contexto.ToListAsync());
        }

        // GET: Denuncias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncia
                .Include(d => d.Pessoa)
                .FirstOrDefaultAsync(m => m.DenunciaID == id);
            if (denuncia == null)
            {
                return NotFound();
            }

            return View(denuncia);
        }

        // GET: Denuncias/Create
        public IActionResult Create()
        {
            ViewData["PessoaID"] = new SelectList(_context.Pessoa, "PessoaID", "PessoaID");
            return View();
        }

        // POST: Denuncias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DenunciaID,PessoaID,Tipo,Localizacao,Descricao,DatDenuncia")] Denuncia denuncia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denuncia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["PessoaID"] = new SelectList(_context.Pessoa, "PessoaID", "PessoaID", denuncia.PessoaID);
            return View(denuncia);
        }

        // GET: Denuncias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncia.FindAsync(id);
            if (denuncia == null)
            {
                return NotFound();
            }
            ViewData["PessoaID"] = new SelectList(_context.Pessoa, "PessoaID", "PessoaID", denuncia.PessoaID);
            return View(denuncia);
        }

        // POST: Denuncias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DenunciaID,PessoaID,Tipo,Localizacao,Descricao,DatDenuncia")] Denuncia denuncia)
        {
            if (id != denuncia.DenunciaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denuncia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenunciaExists(denuncia.DenunciaID))
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
            ViewData["PessoaID"] = new SelectList(_context.Pessoa, "PessoaID", "PessoaID", denuncia.PessoaID);
            return View(denuncia);
        }

        // GET: Denuncias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncia
                .Include(d => d.Pessoa)
                .FirstOrDefaultAsync(m => m.DenunciaID == id);
            if (denuncia == null)
            {
                return NotFound();
            }

            return View(denuncia);
        }

        // POST: Denuncias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var denuncia = await _context.Denuncia.FindAsync(id);
            _context.Denuncia.Remove(denuncia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenunciaExists(int id)
        {
            return _context.Denuncia.Any(e => e.DenunciaID == id);
        }
    }
}
