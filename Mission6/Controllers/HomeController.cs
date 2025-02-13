using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private JoelHiltonContext _context;
        //constructor:
        public HomeController(JoelHiltonContext someName) //getting an instance of the database
        {
            _context = someName;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        public IActionResult EnterMovie()
        {
            return View();
        }

        //making a post method:
        [HttpPost]
        public IActionResult EnterMovie(Application response)
        {
            _context.Applications.Add(response); //add record to the database
            _context.SaveChanges(); //save or commit the changes


            return View("Confirmation");
        }
    }
}
