﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly FinalProjectContext _context;

        public ProjectsController(FinalProjectContext context)
        {
            _context = context;
        }

       

        // GET: Projects
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string useridd = HttpContext.User.Identity.Name;
            var userid =( from m in _context.AspNetUsers
                         where m.Email == useridd
                         select m.Id)
                         .FirstOrDefault();

            var prjcts = from m in _context.Project
                         join sem in _context.Category on m.CategoryId equals sem.Id
                         where m.PersonId == userid
                         select m;
                         

            var finalProjectContext = prjcts.Include(p => p.Category).Include(p => p.Person);
            return View(await finalProjectContext.ToListAsync());
           // return View(prjcts);
        }

        // GET: Projects/Details/5
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


        public class DateValid : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                value = (DateTime)value;
                if (DateTime.Now.AddYears(2).CompareTo(value) >= 0 && DateTime.Now.CompareTo(value) <= 0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Date must be within the next two years!");
                }
            }
        }
        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Title");
            //ViewData["PersonId"] = new SelectList(_context.AspNetUsers, "Id", "Id");


            string useridd = HttpContext.User.Identity.Name;

            var userid = from m in _context.AspNetUsers
                         where m.Email == useridd
                         select m.Id;

            ViewData["PersonId"] = new SelectList(userid);
            return View();
        }

        // POST: Projects/Create
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
                return RedirectToAction("Index", new { id = project.Id });
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Title", project.CategoryId);

            string useridd = HttpContext.User.Identity.Name;

            var userid = from m in _context.AspNetUsers
                         where m.Email == useridd
                         select m.Id;

            //ViewData["PersonId"] = new SelectList(_context.AspNetUsers, "Id", "Id", project.PersonId);
            ViewData["PersonId"] = new SelectList(userid);
            return View(project);

           
        }

        // GET: Projects/Edit/5
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
            //ViewData["PersonId"] = new SelectList(_context.AspNetUsers, "Id", "Id", project.PersonId);
            string useridd = HttpContext.User.Identity.Name;

            var userid = from m in _context.AspNetUsers
                         where m.Email == useridd
                         select m.Id;

            ViewData["PersonId"] = new SelectList(userid);
            return View(project);
        }

        // POST: Projects/Edit/5
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

            var dbproject = await _context.Project.SingleOrDefaultAsync(p => p.Id == id);
            dbproject.Category = project.Category;
            dbproject.HeroUrl = project.HeroUrl;
            dbproject.Title = project.Title;
            dbproject.Description = project.Description;
            dbproject.Deadline = project.Deadline;
            dbproject.Goal = project.Goal;

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(dbproject);
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
                return RedirectToAction("Index", new { id = project.Id });
                //return RedirectToAction("~/Views/ProjectsAll/Index.cshtml", new { id = project.Id });
                //return View("~/Views/ProjectsAll/Index.cshtml", await finalProjectContext.ToListAsync());

                
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Title", dbproject.CategoryId);
            string useridd = HttpContext.User.Identity.Name;

            var userid = from m in _context.AspNetUsers
                         where m.Email == useridd
                         select m.Id;

            ViewData["PersonId"] = new SelectList(userid);
            //ViewData["PersonId"] = new SelectList(_context.AspNetUsers, "Id", "Id", project.PersonId);
            return View(dbproject);
        }

        // GET: Projects/Delete/5
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

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = project.Id });
        }

        private bool ProjectExists(long id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}
