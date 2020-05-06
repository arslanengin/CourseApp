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
        private CourseAppContext context;
        public HomeController(CourseAppContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public IActionResult AddRequest()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddRequest(Request model)
        {
            context.Requests.Add(model);
            context.SaveChanges();
            return View("Thanks",model);
        }
        public IActionResult List(Request model)
        {
            return View(context.Requests);
        }
    }
}