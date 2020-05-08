using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class HomeController : Controller
    {
        private CourseAppContext _context;
        public HomeController(CourseAppContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View(_context.Courses);
        }
        [HttpGet]
        public IActionResult AddRequest()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddRequest(Request model)
        {
            _context.Requests.Add(model);
            _context.SaveChanges();
            return View("Thanks",model);
        }
        public IActionResult List(Request model)
        {
            return View(_context.Requests);
        }
    }
}