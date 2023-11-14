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
            return View();
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person student)
        {
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
        public ActionResult Edit(int id)
        {
            Person studentToEdit = db.People.Find(id);
            DbSet<Role> roles = db.Roles;
            List<Role> rolesList = roles.ToList();

            ViewBag.Roles = new SelectList(rolesList, "Id", "Labels");

            return View(studentToEdit);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person studentToEdit)
        {
            if (ModelState.IsValid)
            {
                Person student = db.People.Find(studentToEdit.Id);

                if (student != null)
                {
                    studentToEdit.Roles = student.Roles;

                    student.FirstName = studentToEdit.FirstName;
                    student.LastName = studentToEdit.LastName;
                    student.Birth = studentToEdit.Birth;
                    student.Roles = studentToEdit.Roles;

                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(studentToEdit);
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
