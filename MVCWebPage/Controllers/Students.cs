using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Collections.Generic;
using System.Collections.Immutable;
using System;
using System.Xml.Linq;


namespace WebApplication2.Controllers
{
    public class Students : Controller
    {
        private static List<StudentsModel> students = new List<StudentsModel>();

        private void SeedStudents()
        {
            if (students.Count() == 0)
            {
                for (int i = 1; i <= 50; i++)
                {
                    students.Add(new StudentsModel
                    {
                        Id = i,
                        Name = $"Student{i}",
                        LastName = $"Lastname{i}",
                        Age = 18 + i
                    });
                }
            }
        }

        // In your constructor or an appropriate initialization point, call the SeedStudents method
        public Students()
        {
            SeedStudents();
        }

        // GET: Students
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            List<StudentsModel> studentsToDisplay = new List<StudentsModel>();

            int totalStudents = students.Count;
            int skip = (page - 1) * pageSize;
            studentsToDisplay.AddRange(students.Skip(skip).Take(pageSize));

            var viewModel = new ViewModel
            {
                Items = studentsToDisplay,
                TotalItems = totalStudents,
                CurrentPage = page,
                PageSize = pageSize
            };

            return View(viewModel);
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
        public IActionResult Create(StudentsModel student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Count() == 0 ? 1 : students.Max(x => x.Id) + 1;
                students.Add(student);
                return RedirectToAction("Index");
            }

            return View();
        }
        // GET: Students/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var studentToEdit = students.FirstOrDefault(s => s.Id == id);

            return View(studentToEdit);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentsModel studentToEdit)
        {
            var studentToEditModel = students.FirstOrDefault(s => s.Id == studentToEdit.Id);
            if (ModelState.IsValid)
            {
                studentToEditModel.Name = studentToEdit.Name;
                studentToEditModel.LastName = studentToEdit.LastName;
                studentToEditModel.Age = studentToEdit.Age;
            }

            return RedirectToAction("Index");

        }


        // GET: Students/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var studentToDelete = students.FirstOrDefault(s => s.Id == id);

            return View(studentToDelete);
        }

        // POST: Students/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(StudentsModel studentToDelete)
        {
            students.RemoveAll(s => s.Id == studentToDelete.Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [HttpGet]
        public ActionResult Search(string searchTerm, int page = 1, int pageSize = 10)
        {
            List<StudentsModel> searchedStudents = new List<StudentsModel>();

            if (searchTerm != null)
            {
                var searchResult = students.Where(s => s.Name.Contains(searchTerm) || s.LastName.Contains(searchTerm)).ToList();
                searchedStudents = searchResult.Select(s => new StudentsModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    LastName = s.LastName,
                    Age = s.Age
                }).ToList();

                // Calculate the total number of search results
                int totalStudents = searchedStudents.Count();

                // Calculate the skip and take values for the current page
                int skip = (page - 1) * pageSize;
                int take = pageSize;

                // Get the list of students for the current page
                searchedStudents = searchedStudents.Skip(skip).Take(take).ToList();

                // Create a new SearchResultModel object and set the properties
                var searchResultModel = new SearchResultModel
                {
                    SearchTerm = searchTerm,
                    Items = searchedStudents,
                    TotalItems = totalStudents,
                    CurrentPage = page,
                    PageSize = pageSize
                };

                return View("Search", searchResultModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


    }
}
