using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Controllers
{
    [Authorize]
    public class ProjectFundsController : Controller
    {
        private readonly FinalProjectContext _context;

        public ProjectFundsController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: ProjectFunds
        [AllowAnonymous]
        public async Task<IActionResult> Index(long? id)
        {

            var prjpac = (from m in _context.Package
                          join sem in _context.Project on m.ProjectId equals sem.Id
                          where m.Id == id
                          select (sem.Progress + m.Value)).FirstOrDefault();

            var prid = (from m in _context.Package
                        join sem in _context.Project on m.ProjectId equals sem.Id
                        where m.Id == id
                        select m.ProjectId).FirstOrDefault();

            var result = (from p in _context.Project
                          where p.Id == prid
                          select p).SingleOrDefault();

            result.Progress = prjpac;

            _context.SaveChanges();

            //SqlCommand comm = new SqlCommand("UPDATE Project SET Progress=@goal WHERE Id==@id");
            //comm.Parameters.AddWithValue("@goal", prjpac);
            //comm.Parameters.AddWithValue("@id", prid);
            return RedirectToAction("Index", "ProjectsAll");
            //var finalProjectContext = _context.Project.Include(p => p.Category).Include(p => p.Person);
            //return View("~/Views/ProjectsAll/Index.cshtml", await finalProjectContext.ToListAsync());
            //return RedirectToAction("Index", new { id = _context.Project.Id });
            //return View("~/Views/ProjectsAll/Index.cshtml");
        }

        // GET: ProjectFunds/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Category)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: ProjectFunds/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Title");
            ViewData["PersonId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: ProjectFunds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,CategoryId,HeroUrl,Title,Description,Deadline,Goal")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Title", project.CategoryId);
            ViewData["PersonId"] = new SelectList(_context.AspNetUsers, "Id", "Id", project.PersonId);
            return View(project);
        }

        // GET: ProjectFunds/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Title", project.CategoryId);
            ViewData["PersonId"] = new SelectList(_context.AspNetUsers, "Id", "Id", project.PersonId);
            return View(project);
        }

        // POST: ProjectFunds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PersonId,CategoryId,HeroUrl,Title,Description,Deadline,Goal")] Project project)
        {
            if (id != project.Id)
            {
                //return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
                    {
                        //return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Title", project.CategoryId);
            ViewData["PersonId"] = new SelectList(_context.AspNetUsers, "Id", "Id", project.PersonId);
            return View(project);
        }

        // GET: ProjectFunds/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Category)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: ProjectFunds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(long id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}
