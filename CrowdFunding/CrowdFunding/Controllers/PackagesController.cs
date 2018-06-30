using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrowdFunding.Models;
using System.Security.Claims;

namespace CrowdFunding.Controllers
{
    public class PackagesController : Controller
    {
        private readonly CrowdFundingContext _context;

        public PackagesController(CrowdFundingContext context)
        {
            _context = context;
        }

        // GET: Packages
        //public async Task<IActionResult> Index()
        //{
        //    var crowdFundingContext = _context.Package.Include(p => p.Project);
        //    return View(await crowdFundingContext.ToListAsync());
        //}

        //Nikos Index
        public async Task<IActionResult> Index(long? id)
        {
            var pckgs = (from m in _context.Package
                         where m.ProjectId == id
                         select m);


            var finalProjectContext = pckgs.Include(p => p.Project);
            return View(await finalProjectContext.ToListAsync());
        }

        public async Task<IActionResult> AnonIndex (long? id)
        {
            var pckgs = (from m in _context.Package
                         where m.ProjectId == id
                         select m);


            var finalProjectContext = pckgs.Include(p => p.Project);
            return View(await finalProjectContext.ToListAsync());
        }

        // GET: Packages/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Package
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        //// GET: Packages/Create
        //public IActionResult Create()
        //{
        //    ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Title");
        //    return View();
        //}

        //Nik Create
        public IActionResult Create()
        {
            var prjcts = from m in _context.Projects
                             // join sem in _context.Package on m.Id equals sem.ProjectId
                         where m.PersonId == Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier))
                         select m;
            ViewData["ProjectId"] = new SelectList(prjcts, "ProjectId", "Title");
            return View();
        }

        public async Task<IActionResult> CreateSpecific(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Package
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.ProjectId == id);

            //var projectPackages = from p in _context.Package
            //                   where p.ProjectId == id
            //                   select p;
            var projectPackages = from p in _context.Projects
                             // join sem in _context.Package on m.Id equals sem.ProjectId
                         where p.ProjectId == id
                         select p;

            ViewData["ProjectId"] = new SelectList(projectPackages, "ProjectId", "Title");

            return View();
        }

        //// POST: Packages/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PackageId,ProjectId,Name,Description,Value")] Package package)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(package);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Title", package.ProjectId);
        //    return View(package);
        //}

        //NIK
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectId,Name,Description,Value")] Package package)
        {
            if (ModelState.IsValid)
            {
                _context.Add(package);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = package.ProjectId });
            }

            var prjcts = (from m in _context.Projects
                          where m.PersonId == Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier))
                          select new { m.Title, m.ProjectId }).Distinct();

            ViewData["ProjectId"] = new SelectList(prjcts, "Id", "Title", package.ProjectId);

            return View();
        }

        // GET: Packages/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Package.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Title", package.ProjectId);
            return View(package);
        }

        // POST: Packages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PackageId,ProjectId,Name,Description,Value")] Package package)
        {
            if (id != package.PackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(package);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackageExists(package.PackageId))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Title", package.ProjectId);
            return View(package);
        }

        // GET: Packages/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Package
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        // POST: Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var package = await _context.Package.FindAsync(id);
            _context.Package.Remove(package);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackageExists(long id)
        {
            return _context.Package.Any(e => e.PackageId == id);
        }
    }
}
