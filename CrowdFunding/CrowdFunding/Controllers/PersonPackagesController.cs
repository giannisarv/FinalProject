using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrowdFunding.Models;

namespace CrowdFunding.Controllers
{
    public class PersonPackagesController : Controller
    {
        private readonly CrowdFundingContext _context;

        public PersonPackagesController(CrowdFundingContext context)
        {
            _context = context;
        }

        // GET: PersonPackages
        public async Task<IActionResult> Index()
        {
            var crowdFundingContext = _context.PersonPackage.Include(p => p.Package).Include(p => p.Person);
            return View(await crowdFundingContext.ToListAsync());
        }

        // GET: PersonPackages/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personPackage = await _context.PersonPackage
                .Include(p => p.Package)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (personPackage == null)
            {
                return NotFound();
            }

            return View(personPackage);
        }

        // GET: PersonPackages/Create
        public IActionResult Create()
        {
            ViewData["PackageId"] = new SelectList(_context.Package, "PackageId", "Name");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Email");
            return View();
        }

        // POST: PersonPackages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackageId,PersonId")] PersonPackage personPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PackageId"] = new SelectList(_context.Package, "PackageId", "Name", personPackage.PackageId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Email", personPackage.PersonId);
            return View(personPackage);
        }

        // GET: PersonPackages/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personPackage = await _context.PersonPackage.FindAsync(id);
            if (personPackage == null)
            {
                return NotFound();
            }
            ViewData["PackageId"] = new SelectList(_context.Package, "PackageId", "Name", personPackage.PackageId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Email", personPackage.PersonId);
            return View(personPackage);
        }

        // POST: PersonPackages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PackageId,PersonId")] PersonPackage personPackage)
        {
            if (id != personPackage.PackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonPackageExists(personPackage.PackageId))
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
            ViewData["PackageId"] = new SelectList(_context.Package, "PackageId", "Name", personPackage.PackageId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Email", personPackage.PersonId);
            return View(personPackage);
        }

        // GET: PersonPackages/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personPackage = await _context.PersonPackage
                .Include(p => p.Package)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (personPackage == null)
            {
                return NotFound();
            }

            return View(personPackage);
        }

        // POST: PersonPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var personPackage = await _context.PersonPackage.FindAsync(id);
            _context.PersonPackage.Remove(personPackage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonPackageExists(long id)
        {
            return _context.PersonPackage.Any(e => e.PackageId == id);
        }
    }
}
