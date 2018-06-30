using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using FinalProject.Data;

namespace FinalProject.Controllers
{
    public class ProjectsUserController : Controller
    {
        private readonly FinalProjectContext _context;

        public ProjectsUserController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: ProjectsUser
        public async Task<IActionResult> Index()
        {
            //var mail = User.Identity.Name;
            var userid = (from m in _context.AspNetUsers
                             //join sem in _context.Project on m.Id equals sem.Id
                         where m.Email == User.Identity.Name
                         select m.Id).SingleOrDefault();

            var prjct = (from m in _context.Project
                             //join sem in _context.Project on m.Id equals sem.Id
                         where m.PersonId == userid
                         select m);

            //return RedirectToAction("Index", "ProjectsAll");
            var finalProjectContext = prjct.Include(p => p.Category).Include(p => p.Person);
            return View("~/Views/ProjectsAll/Index.cshtml", await finalProjectContext.ToListAsync());
            //return View(await finalProjectContext.ToListAsync());
        }

        // GET: ProjectsUser/Details/5
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

        // GET: ProjectsUser/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Title");
            ViewData["PersonId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: ProjectsUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,CategoryId,HeroUrl,Title,Description,Deadline,Goal,Progress")] Project project)
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

        // GET: ProjectsUser/Edit/5
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

        // POST: ProjectsUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PersonId,CategoryId,HeroUrl,Title,Description,Deadline,Goal,Progress")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
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
                        return NotFound();
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

        // GET: ProjectsUser/Delete/5
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

        // POST: ProjectsUser/Delete/5
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
