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
    public class PartijaController : Controller
    {
        private readonly belaKontekst _context;

        public PartijaController(belaKontekst context)
        {
            _context = context;
        }

        // GET: Partija
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partija.ToListAsync());
        }

        // GET: Partija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partija = await _context.Partija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partija == null)
            {
                return NotFound();
            }

            return View(partija);
        }

        // GET: Partija/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv")] Partija partija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partija);
        }

        // GET: Partija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partija = await _context.Partija.FindAsync(id);
            if (partija == null)
            {
                return NotFound();
            }
            return View(partija);
        }

        // POST: Partija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv")] Partija partija)
        {
            if (id != partija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartijaExists(partija.Id))
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
            return View(partija);
        }

        // GET: Partija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partija = await _context.Partija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partija == null)
            {
                return NotFound();
            }

            return View(partija);
        }

        // POST: Partija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partija = await _context.Partija.FindAsync(id);
            _context.Partija.Remove(partija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartijaExists(int id)
        {
            return _context.Partija.Any(e => e.Id == id);
        }
    }
}
