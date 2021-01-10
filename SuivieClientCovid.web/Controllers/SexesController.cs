using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuiviClientCovid.ORM;

namespace SuivieClientCovid.web.Controllers
{
    public class SexesController : Controller
    {
        private readonly Contexte _context = new Contexte();

       /* public SexesController(Contexte context)
        {
            _context = context;
        } */

        // GET: Sexes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sexes.ToListAsync());
        }

        // GET: Sexes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexe = await _context.Sexes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sexe == null)
            {
                return NotFound();
            }

            return View(sexe);
        }

        // GET: Sexes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sexes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name")] Sexe sexe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sexe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sexe);
        }

        // GET: Sexes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexe = await _context.Sexes.FindAsync(id);
            if (sexe == null)
            {
                return NotFound();
            }
            return View(sexe);
        }

        // POST: Sexes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name")] Sexe sexe)
        {
            if (id != sexe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sexe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SexeExists(sexe.Id))
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
            return View(sexe);
        }

        // GET: Sexes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexe = await _context.Sexes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sexe == null)
            {
                return NotFound();
            }

            return View(sexe);
        }

        // POST: Sexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sexe = await _context.Sexes.FindAsync(id);
            _context.Sexes.Remove(sexe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SexeExists(int id)
        {
            return _context.Sexes.Any(e => e.Id == id);
        }
    }
}
