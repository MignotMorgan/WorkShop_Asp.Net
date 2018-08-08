using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            ViewData["montest"] = "mon test";
            MonTest montest = new MonTest("classe MonTest"); 
            ViewBag.mavaleur = "mavaleur";
            return View(montest);
            //Session["value"] = value";
            //return RedirectToAction("function");
            //return RedirectToLocal(returnUrl);
        }

        public IActionResult FuncTest(int id = 0, string name = "pas de nom")
        {
            ViewBag.id = id;
            ViewBag.name = name;
            return View();
        }
    }
}