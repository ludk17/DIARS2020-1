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
    public class PreguntaController : Controller
    {
        [HttpGet]
        public IActionResult Index(int temaId)
        {
            var context = new AppPruebaContext();

            var model = context.Temas
                //.Include(x => x.Preguntas)
                .Include("Preguntas.Alternativas")
                .Include(x => x.Categoria)
                .Where(x => x.Id == temaId)
                .FirstOrDefault();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create(int temaId)
        {
            ViewBag.TemaId = temaId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pregunta pregunta)
        {
            var context = new AppPruebaContext();
            context.Preguntas.Add(pregunta);
            context.SaveChanges();

            return RedirectToAction("Index", new { temaId = pregunta.TemaId });
        }
    }
}