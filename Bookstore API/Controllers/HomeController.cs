using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult AddBook()
        {
            ViewBag.Title = "Add book to bookstore";
            return View();
        }

        public ActionResult BookSuggestion()
        {
            ViewBag.Title = "Add suggestion to bookstore";
            return View();
        }
    }
}
