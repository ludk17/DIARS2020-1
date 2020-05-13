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
    public class AlternativaController : Controller
    {
        [HttpGet]
        public IActionResult Create(int preguntaId)
        {
            var context = new AppPruebaContext();
            ViewBag.Pregunta = context.Preguntas
                .Include(o => o.Tema)
                .First(o => o.Id == preguntaId);

            return View();
        }

        [HttpPost]
        public IActionResult Create(Alternativa alternativa, int temaId)
        {
            var context = new AppPruebaContext();
            context.Alternativas.Add(alternativa);
            context.SaveChanges();

            return RedirectToAction("Index", "Pregunta", new { temaId = temaId });
        }
    }
}