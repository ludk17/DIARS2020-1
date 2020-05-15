using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.DB;
using MVCProject.Models;
using MVCProject.Extensions;

namespace MVCProject.Controllers
{

   

    [Authorize]
    public class TemaController : Controller
    {       

        [HttpGet]        
        public IActionResult Index()
        {
            var usserLogged = HttpContext.Session.Get<User>("SessionLoggedUser");

            var context = new AppPruebaContext();
            var model = context.Temas
                .Include(o => o.Categoria)
                .Where(o => o.UserId == usserLogged.Id)
                .ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var context = new AppPruebaContext();
            ViewBag.Categorias = context.Categorias.ToList();
            var tema = new Tema();
            return View(tema);
        }


        [HttpPost]
        public IActionResult Create(Tema tema)
        {
            var usserLogged = HttpContext.Session.Get<User>("SessionLoggedUser");
            var context = new AppPruebaContext();

            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = context.Categorias.ToList();                
                return View(tema);
            }

            tema.UserId = usserLogged.Id;

            context.Temas.Add(tema);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}