using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.DB;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public ViewResult Index(int rows)
        {
            ViewBag.Rows = rows;
            return View();
        }

        [HttpPost]
        public ViewResult Create(List<Producto> productos)
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(User user)
        //{
        //    var context = new AppPruebaContext();

        //    if (user.Username != null && user.Username.ToLower().Contains("z"))
        //        ModelState.AddModelError("Username", "Username no debe contener z");
        //    if (user.Username != null && !user.Username.ToLower().Contains("."))
        //        ModelState.AddModelError("Username", "Username debe contenet un .");

        //    if (ModelState.IsValid)
        //    {
        //        context.Users.Add(user);
        //        context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }

        //    return View("Create");
            
        //}

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var context = new AppPruebaContext();
            var user = context.Users.Where(o => o.Id == id).First();
            return View(user);
        }


        [HttpPost]
        public RedirectToActionResult Edit(User user)
        {
            var context = new AppPruebaContext();
            var userDb = context.Users.Where(o => o.Id == user.Id).First();
            
            userDb.Username = user.Username;

            context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public RedirectToActionResult Delete(int id)
        {
            var context = new AppPruebaContext();

            var userDb = context.Users.Where(o => o.Id == id).First();

            context.Users.Remove(userDb);
            context.SaveChanges();

            return RedirectToAction("index");
        }

        public string Valores(Usuario u)
        {
            return u.Username + u.Password; 
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
