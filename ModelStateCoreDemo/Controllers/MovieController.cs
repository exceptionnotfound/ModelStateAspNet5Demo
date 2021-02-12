using Microsoft.AspNetCore.Mvc;
using ModelStateCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelStateCoreDemo.Controllers
{
    public class MovieController : Controller
    {
        [HttpGet("~/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("movies/add")]
        public IActionResult Add()
        {
            AddMovieVM model = new AddMovieVM();
            return View(model);
        }

        [HttpPost("movies/add/post")]
        public IActionResult AddPost(AddMovieVM model)
        {
            if(model.Title == model.Description)
            {
                ModelState.AddModelError("description", "The Description cannot exactly match the Title.");
            }

            if(!ModelState.IsValid)
            {
                return View("Add", model);
            }

            return RedirectToAction("Index");
        }
    }
}
