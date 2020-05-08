using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository _repository;
        public CourseController(ICourseRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index(string name = null, decimal? price = null, string isActive = null)
        {
            var courses = _repository.GetCoursesByFilter(name, price, isActive);
            ViewBag.Name = name;
            ViewBag.price = price;
            ViewBag.isActive = isActive == "on" ? true : false;

            return View(courses);
        }



        public IActionResult Edit(int id)
        {
            ViewBag.ActionMode = "Edit";

            return View(_repository.GetById(id));
        }


        [HttpPost]
        public IActionResult Edit(Course course, Course original)
        {
            _repository.UpdateCourse(course, original);

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            ViewBag.ActionMode = "Create";
            return View("Edit", new Course());
        }

        [HttpPost]
        public IActionResult Create(Course newCourse)
        {
            int id = _repository.CreateCourse(newCourse);
            Console.WriteLine("Id:{0}", id);

            return RedirectToAction(nameof(Index));
        }
    }
}
