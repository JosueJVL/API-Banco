using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banco.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Banco.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Movie movie = new Movie()
            {

                Title = "El bromas",
                RelaseDate = new DateTime(1997, 10, 28)
            };
            
            return View(movie);
            //return Content("Helo Work!!");
        }
    }
}