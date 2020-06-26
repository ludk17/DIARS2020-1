using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.DB;
using MVCProject.ViewModels;

namespace MVCProject.Controllers
{
    public class ExamenController : Controller
    {
        private readonly AppPruebaContext context;

        public ExamenController()
        {
            this.context = new AppPruebaContext();
        }


        [HttpGet]
        public IActionResult Index(int temaId)
        {
            var preguntas = context.Preguntas.Where(o => o.TemaId == temaId)
                .Include(o => o.Alternativas)
                .ToList()
                .OrderBy(o => Guid.NewGuid())
                .Take(5)
                .ToList();

            preguntas.ForEach(x => x.Alternativas = x.Alternativas.OrderBy(o => Guid.NewGuid()).ToList());

            return View(preguntas);
        }

        [HttpPost]
        public IActionResult Create(List<Respuesta> alternativas)
        {
            return null;
        }
    }

    public class Pers
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
