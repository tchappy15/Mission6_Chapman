using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Chapman.Models;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private JoelHiltonMovieCollectionContext _context;
        //constructor:
        public HomeController(JoelHiltonMovieCollectionContext someName) //getting an instance of the database
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

        //EnterMovie get
        [HttpGet]
        public IActionResult EnterMovie()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("EnterMovie", new Movie());
        }

        //EnterMovie post:
        [HttpPost]
        public IActionResult EnterMovie(Movie response)
        {
            Console.WriteLine($"MovieId: {response.MovieId}, CategoryId: {response.CategoryId}");

            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); //add record to the database
                _context.SaveChanges(); //save or commit the changes


                return View("Confirmation", response); //take user to confirmation page
            }
            else //invalid data was attempted by the user
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

                return View(response); //pass them back the data they have already put in
            }
        }


        
        public IActionResult ViewRecords()
        {
            var movies = _context.Movies //go to the context file (which is like the C# version of our database), go to the Applications table, then use "linq" instead of SQL, altho it is SQLish
                .Include(x => x.Category) //a way of joining to the major table
                .OrderBy(x => x.MovieId).ToList(); //this List is what we send to the viewRecords view


            return View(movies); //by default, returns the ViewRecords view, and then also the movies since we specified that
        }

        //Edit Get
        [HttpGet]
        public IActionResult Edit(int id) //This int HAS to be named "id" since that is what the pattern needs
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id); //use .Single instead of .Where so that we only are returned one record only

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("EnterMovie", recordToEdit);
        }

        //Edit Post
        [HttpPost]
        public IActionResult Edit(Movie updatedRecord)
        {
                    
            if (ModelState.IsValid)
            {
                _context.Update(updatedRecord);
                _context.SaveChanges();

                //IMPORTANT: this is calling a VIEW, NOT an action, so we do this instead:
                return RedirectToAction("ViewRecords");
            }
            else //invalid data was attempted by the user
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

                return View("EnterMovie", updatedRecord); //pass them back the data they have already put in
            }
        }


        //Delete Get
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        //Delete Post
        [HttpPost]
        public IActionResult Delete(Movie app)
        {
            _context.Movies.Remove(app);
            _context.SaveChanges();

            return RedirectToAction("ViewRecords");
        }

    }
}
