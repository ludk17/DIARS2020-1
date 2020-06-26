using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.DB;
using MVCProject.Extensions;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class PreguntaController : Controller
    {
        [HttpGet]
        public IActionResult Index(int temaId)
        {
            
            ValidarTemaEsDeUsuarioLoggueado(temaId);
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
            ValidarTemaEsDeUsuarioLoggueado(temaId);
            ViewBag.TemaId = temaId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pregunta pregunta)
        {
            ValidarTemaEsDeUsuarioLoggueado(pregunta.TemaId);
            var context = new AppPruebaContext();
            context.Preguntas.Add(pregunta);
            context.SaveChanges();

            return RedirectToAction("Index", new { temaId = pregunta.TemaId });
        }

        private void ValidarTemaEsDeUsuarioLoggueado(int temaId)
        {
            var usserLogged = HttpContext.Session.Get<User>("SessionLoggedUser");
            var context = new AppPruebaContext();
            var tema = context.Temas.FirstOrDefault(x => x.Id == temaId && x.UserId == usserLogged.Id);
            if (tema == null)
                throw new Exception("usuario no tiene permiso a tema");
        }
    }
}