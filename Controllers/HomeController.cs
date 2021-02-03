using CadeRasmussen_Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CadeRasmussen_Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //This is what is returned when the form page is first loaded or when not all the required information is entered into the form
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movies addMovie)
        {
            //Verifying the form when submit button is hit, if all required data entered, go to confirmation page, else go return to form page with required
            //information posted under the form
            if (ModelState.IsValid)
            {
                TempStorage.AddMovie(addMovie);
                return View("Confirmation", addMovie);
            }
            else
            {
                return View();
            }
        }

        //Returning the podcast page, when the podcast navigation bar is clicked, or typed into URL
        public IActionResult MyPodcast()
        {
            return View();
        }

        //Returning the movie liest page, when the movie list navigation bar is clicked, or typed into URL
        public IActionResult MovieList()
        {
            //Returning the view for Movie List with the Data from the Model of TempStorage, which is currently saving move list until app is killed
            return View(TempStorage.MovieList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
