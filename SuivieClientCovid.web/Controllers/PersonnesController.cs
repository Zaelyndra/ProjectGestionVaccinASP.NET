using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuiviClientCovid.ORM;
using SuivieClientCovid.web.Models;

namespace SuivieClientCovid.web.Controllers
{
    public class PersonnesController : Controller
    {
        private readonly Contexte _context = new Contexte();

        /* public PersonnesController(Contexte context)
         {
             _context = context;
         } */

        // GET: Personnes Non vacciné contre le Covid
        public IActionResult ListePersonneNonVaccineCovid()
        {
            var context = from personne in _context.Personnes
                          from injection in _context.Injections
                          .Where(i => personne.Id == i.PersonneId)
                          .DefaultIfEmpty()
                          from typeVaccin in _context.TypesVaccins
                          .Where(t => injection.TypesVaccinId == t.Id)
                          .DefaultIfEmpty()
                          where typeVaccin.Nom != "Covid"

            select new ListePersonnesNonCovidViewModel
                          (
                              personne.Nom,
                              personne.Prenom,
                              injection,
                              typeVaccin
                          );

            return View(context.ToList());
        }

        // GET: Personnes
        public async Task<IActionResult> Index()
        {
            var contexte = _context.Personnes.Include(p => p.sexe);
            return View(await contexte.ToListAsync());
        }

        // GET: Personnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await _context.Personnes
                .Include(p => p.sexe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personne == null)
            {
                return NotFound();
            }

            return View(personne);
        }

        // GET: Personnes/Create
        public IActionResult Create()
        {
            ViewData["SexeId"] = new SelectList(_context.Sexes, "Id", "name");
            return View();
        }

        // POST: Personnes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,DateDeNaissance,Résident_Ou_Personnel,SexeId")] Personne personne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SexeId"] = new SelectList(_context.Sexes, "Id", "name", personne.SexeId);
            return View(personne);
        }

        // GET: Personnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await _context.Personnes.FindAsync(id);
            if (personne == null)
            {
                return NotFound();
            }
            ViewData["SexeId"] = new SelectList(_context.Sexes, "Id", "name", personne.SexeId);
            return View(personne);
        }

        // POST: Personnes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,DateDeNaissance,Résident_Ou_Personnel,SexeId")] Personne personne)
        {
            if (id != personne.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonneExists(personne.Id))
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
            ViewData["SexeId"] = new SelectList(_context.Sexes, "Id", "name", personne.SexeId);
            return View(personne);
        }

        // GET: Personnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await _context.Personnes
                .Include(p => p.sexe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personne == null)
            {
                return NotFound();
            }

            return View(personne);
        }

        // POST: Personnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personne = await _context.Personnes.FindAsync(id);
            _context.Personnes.Remove(personne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonneExists(int id)
        {
            return _context.Personnes.Any(e => e.Id == id);
        }
    }
}
