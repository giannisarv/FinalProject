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
    public class DetailsController : Controller
    {
        private readonly CrowdFundingContext _context;

        public DetailsController(CrowdFundingContext context)
        {
            _context = context;
        }

        // GET: Details
        public async Task<IActionResult> Index()
        {
            //get projectDetails from userProjects
            var projectDetails = from d in _context.Detail
                                 join p in _context.Projects on d.ProjectId equals p.ProjectId
                                 where p.PersonId == Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier))
                                 select d;

            var userProjectDetailsContext = await projectDetails
                .Include(p => p.Project)
                //.Include(p => p.Person)
                .ToListAsync();
            return View(userProjectDetailsContext);
        }

        public async Task<IActionResult> SpecificIndex(long? id)
        {
            if (id is null)
            {
                return await Index();
                //return NotFound();
            }
            //get projectDetails from userProjects
            var projectDetails = from d in _context.Detail
                                 join p in _context.Projects on d.ProjectId equals p.ProjectId
                                 where p.PersonId == Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier))
                                        && d.ProjectId == id
                                 select d;

            var userProjectDetailsContext = await projectDetails
                .Include(p => p.Project)
                //.Include(p => p.Person)
                .ToListAsync();
            return View(userProjectDetailsContext);
        }

        // GET: Details/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.DetailId == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // GET: Details/Create
        public IActionResult Create()
        {
            //It brings only userloged projects for adding new detail
            var userProjects = from m in _context.Projects
                               where m.PersonId == Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier))
                               select m;

            //var userProjectContext = userProjects.Include(p => p.Category).Include(p => p.Person);
            ViewData["ProjectId"] = new SelectList(userProjects, "ProjectId", "Title");
            return View();
        }

        public async Task<IActionResult> CreateSpecific (long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.ProjectId == id);

            var userProjects = from p in _context.Projects
                               where p.ProjectId == id
                               select p;

            ViewData["ProjectId"] = new SelectList(userProjects, "ProjectId", "Title");

            return View();
        }


        // POST: Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetailId,ProjectId,Title,Description,DateOfUpdate")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Title", detail.ProjectId);
            return View(detail);
        }

        // GET: Details/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }

            //ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Title", detail.ProjectId);
            //return View(detail);

            var userProjects = from m in _context.Projects
                               where m.PersonId == Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier))
                               select m;

            var userProjectContext = userProjects.Include(p => p.Category).Include(p => p.Person);
            ViewData["ProjectId"] = new SelectList(userProjectContext, "ProjectId", "Title");
            return View();
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("DetailId,ProjectId,Title,Description,DateOfUpdate")] Detail detail)
        {
            if (id != detail.DetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailExists(detail.DetailId))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Title", detail.ProjectId);
            return View(detail);
        }

        // GET: Details/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.DetailId == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var detail = await _context.Detail.FindAsync(id);
            _context.Detail.Remove(detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailExists(long id)
        {
            return _context.Detail.Any(e => e.DetailId == id);
        }
    }
}
