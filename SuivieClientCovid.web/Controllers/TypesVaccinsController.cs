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
    public class TypesVaccinsController : Controller
    {
        private readonly Contexte _context = new Contexte();

        /* public TypesVaccinsController(Contexte context)
        {
            _context = context;
        } */

        // GET: TypesVaccins
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypesVaccins.ToListAsync());
        }

        // GET: TypesVaccins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesVaccin = await _context.TypesVaccins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typesVaccin == null)
            {
                return NotFound();
            }

            return View(typesVaccin);
        }

        // GET: TypesVaccins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypesVaccins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Description")] TypesVaccin typesVaccin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typesVaccin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typesVaccin);
        }

        // GET: TypesVaccins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesVaccin = await _context.TypesVaccins.FindAsync(id);
            if (typesVaccin == null)
            {
                return NotFound();
            }
            return View(typesVaccin);
        }

        // POST: TypesVaccins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Description")] TypesVaccin typesVaccin)
        {
            if (id != typesVaccin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typesVaccin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypesVaccinExists(typesVaccin.Id))
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
            return View(typesVaccin);
        }

        // GET: TypesVaccins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesVaccin = await _context.TypesVaccins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typesVaccin == null)
            {
                return NotFound();
            }

            return View(typesVaccin);
        }

        // POST: TypesVaccins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typesVaccin = await _context.TypesVaccins.FindAsync(id);
            _context.TypesVaccins.Remove(typesVaccin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypesVaccinExists(int id)
        {
            return _context.TypesVaccins.Any(e => e.Id == id);
        }
    }
}
