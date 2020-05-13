using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.DB;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class TemaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var context = new AppPruebaContext();
            var model = context.Temas
                //.Include("Categoria")
                .Include(o => o.Categoria)
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
            var context = new AppPruebaContext();

            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = context.Categorias.ToList();                
                return View(tema);
            }

            context.Temas.Add(tema);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}