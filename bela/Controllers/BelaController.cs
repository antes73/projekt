using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bela.Data;
using bela.Models;

namespace bela.Controllers
{
    public class BelaController : Controller
    {
        private readonly belaKontekst _context;

        public BelaController(belaKontekst context)
        {
            _context = context;
        }

        // GET: Bela
        public async Task<IActionResult> Index(string search)
        {
            if (!String.IsNullOrEmpty(search)) { 

            var partije = from Bela in _context.Bela
                          select Bela;
            partije = partije.Where(Bela => Bela.Partija.Naziv.Contains(search));

            return View(partije.ToList());

            var belaKontekst = _context.Bela.Include(b => b.Partija);
            return View(await belaKontekst.ToListAsync());
            }

            var partijee = from Bela in _context.Bela
                          select Bela;
            partijee = partijee.Where(Bela => Bela.Partija.Naziv.Contains("kkk"));

            return View(partijee.ToList());

            


        }

        // GET: Bela/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bela = await _context.Bela
                .Include(b => b.Partija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bela == null)
            {
                return NotFound();
            }

            return View(bela);
        }

        // GET: Bela/Create
        public IActionResult Create()
        {
            ViewData["PartijaId"] = new SelectList(_context.Partija, "Id", "Naziv");
            return View();
        }

        // POST: Bela/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ZvanjaMi,BodoviMi,BodoviVi,ZvanjaVi,PartijaId")] Bela bela)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bela);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartijaId"] = new SelectList(_context.Partija, "Id", "Naziv", bela.PartijaId);
            return View(bela);
        }

        // GET: Bela/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bela = await _context.Bela.FindAsync(id);
            if (bela == null)
            {
                return NotFound();
            }
            ViewData["PartijaId"] = new SelectList(_context.Partija, "Id", "Naziv", bela.PartijaId);
            return View(bela);
        }

        // POST: Bela/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ZvanjaMi,BodoviMi,BodoviVi,ZvanjaVi,PartijaId")] Bela bela)
        {
            if (id != bela.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bela);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BelaExists(bela.Id))
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
            ViewData["PartijaId"] = new SelectList(_context.Partija, "Id", "Naziv", bela.PartijaId);
            return View(bela);
        }

        // GET: Bela/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bela = await _context.Bela
                .Include(b => b.Partija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bela == null)
            {
                return NotFound();
            }

            return View(bela);
        }

        // POST: Bela/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bela = await _context.Bela.FindAsync(id);
            _context.Bela.Remove(bela);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BelaExists(int id)
        {
            return _context.Bela.Any(e => e.Id == id);
        }
    }
}
