using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Collections.Generic;
using System.Collections.Immutable;
using X.PagedList;
using System;
using System.Xml.Linq;
using WebApplication2.School_dbModels;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebApplication2.Controllers
{
    public class Students : Controller
    {
        private SchoolDbContext db = new SchoolDbContext();

        // GET: Students
        public IActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            var totalStudent = db.People.Where(p => p.Roles == 1);

            return View(totalStudent.ToPagedList(pageNumber, pageSize));
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            var student = db.People.FirstOrDefault(s => s.Id == id);

            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            DbSet<Role> roles = db.Roles;
            List<Role> rolesList = roles.ToList();

            ViewBag.Roles = new SelectList(rolesList, "Id", "Labels");
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person student)
        {
            DbSet<Role> roles = db.Roles;
            List<Role> rolesList = roles.ToList();

            ViewBag.Roles = new SelectList(rolesList, "Id", "Labels");

            if (ModelState.IsValid)
            {
                db.People.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }
        // GET: Students/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var person = await db.People.FindAsync(id);
            DbSet<Role> roles = db.Roles;
            List<Role> rolesList = roles.ToList();

            ViewBag.Roles = new SelectList(rolesList, "Id", "Labels");

            return View(person);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Birth,Roles")] Person person)
        {


            if (ModelState.IsValid)
            {
                db.People.Update(person);
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            DbSet<Role> roles = db.Roles;
            List<Role> rolesList = await roles.ToListAsync();
            ViewBag.Roles = new SelectList(rolesList, "Id", "Labels");

            return View(person);
        }


        // GET: Students/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var studentToDelete = db.People.Find(id);

            return View(studentToDelete);
        }

        // POST: Students/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Person studentToDelete)
        {

            db.People.Remove(studentToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [HttpGet]
        public ActionResult Search(string searchterm, int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            var searchedStudents = db.People.Where(s => s.LastName == searchterm || s.FirstName == searchterm);

            ViewBag.SearchTerm = searchterm;

            return View(searchedStudents.ToPagedList(pageNumber, pageSize));
        }
    }
}
