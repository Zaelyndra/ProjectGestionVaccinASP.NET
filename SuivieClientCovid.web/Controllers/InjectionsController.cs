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
    public class InjectionsController : Controller
    {
        private readonly Contexte _context = new Contexte();

       /* public InjectionsController(Contexte context)
        {
            _context = context;
        } */

        // GET: Injections
        public async Task<IActionResult> Index()
        {
            var contexte = _context.Injections.Include(i => i.TypesVaccins).Include(i => i.personne);
            return View(await contexte.ToListAsync());
        }

        // GET: Retard Vaccins
        public async Task<IActionResult> RetardVaccin()
        {
            var contexte = _context.Injections.Include(i => i.TypesVaccins).Include(i => i.personne);
            return View(await contexte.ToListAsync());
        }

        // GET: Injections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injection = await _context.Injections
                .Include(i => i.TypesVaccins)
                .Include(i => i.personne)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (injection == null)
            {
                return NotFound();
            }

            return View(injection);
        }

        // GET: Injections/Create
        public IActionResult Create()
        {
            ViewData["TypesVaccinId"] = new SelectList(_context.TypesVaccins, "Id", "Id");
            ViewData["PersonneId"] = new SelectList(_context.Personnes, "Id", "Id");
            return View();
        }

        // POST: Injections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marque,NuméroDuLot,Date,DateRappel,TypesVaccinId,PersonneId")] Injection injection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(injection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypesVaccinId"] = new SelectList(_context.TypesVaccins, "Id", "Id", injection.TypesVaccinId);
            ViewData["PersonneId"] = new SelectList(_context.Personnes, "Id", "Id", injection.PersonneId);
            return View(injection);
        }

        // GET: Injections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injection = await _context.Injections.FindAsync(id);
            if (injection == null)
            {
                return NotFound();
            }
            ViewData["TypesVaccinId"] = new SelectList(_context.TypesVaccins, "Id", "Id", injection.TypesVaccinId);
            ViewData["PersonneId"] = new SelectList(_context.Personnes, "Id", "Id", injection.PersonneId);
            return View(injection);
        }

        // POST: Injections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marque,NuméroDuLot,Date,DateRappel,TypesVaccinId,PersonneId")] Injection injection)
        {
            if (id != injection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(injection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InjectionExists(injection.Id))
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
            ViewData["TypesVaccinId"] = new SelectList(_context.TypesVaccins, "Id", "Id", injection.TypesVaccinId);
            ViewData["PersonneId"] = new SelectList(_context.Personnes, "Id", "Id", injection.PersonneId);
            return View(injection);
        }

        // GET: Injections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injection = await _context.Injections
                .Include(i => i.TypesVaccins)
                .Include(i => i.personne)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (injection == null)
            {
                return NotFound();
            }

            return View(injection);
        }

        // POST: Injections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var injection = await _context.Injections.FindAsync(id);
            _context.Injections.Remove(injection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InjectionExists(int id)
        {
            return _context.Injections.Any(e => e.Id == id);
        }
    }
}
