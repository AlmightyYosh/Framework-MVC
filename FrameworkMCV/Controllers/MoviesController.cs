using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrameworkMCV.Models;
using FrameworkMCV.ViewModels;
using Microsoft.Ajax.Utilities;

namespace FrameworkMCV.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            //viewModel
            var viewModel = new RandomMovieViewModel() 
            { 
                Movie = movie,
                Customers = customers
            };
            
            
            //ViewDataDictionary way. 
            //ViewData["Movie"] = movie; **inside the view: @(((Movie) ViewData["Movie"]).Name)
            
            //ViewBag way.
            //ViewBag.Movie = movie; **inside the view: ViewBag.movie

            return View(viewModel);
        }

        //simple examples 
        public ActionResult Edit(int id)
        {
            return Content("id =" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        }

        [Route("movies/released/{year}/{month:regex(\\d{2})}")]
        public ActionResult byReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}