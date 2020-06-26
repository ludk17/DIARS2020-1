using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCProject.DB;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class PeliculaController : Controller
    {
        private AppPruebaContext context;
        private IHostingEnvironment env;

        public PeliculaController(IHostingEnvironment env)
        {
            context = new AppPruebaContext();
            this.env = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult _Index(string name = "", bool? esFavorita=null)
        {
            var query = context.Peliculas.AsQueryable();
            if (!String.IsNullOrEmpty(name))
                query = query.Where(o => o.Name.Contains(name));
            if(esFavorita != null)
                query = query.Where(o => o.IsFavorite == esFavorita);

            return View(query.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Directores = GetDirectores();
            return View(new Pelicula());
        }

        [HttpPost]
        public IActionResult Create(Pelicula pelicula, IFormFile imagen)
        {
            if (context.Peliculas.Where(o => o.Code == pelicula.Code).Count() > 0)
                ModelState.AddModelError("Code", "Código ya existe en nuestros registros");

            if(ModelState.IsValid)
            { 

                if (imagen.Length > 0)
                {
                    var filePath = Path.Combine(env.WebRootPath, "images", imagen.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imagen.CopyTo(stream);
                    }
                }

                pelicula.Imagen = imagen.FileName;
                context.Peliculas.Add(pelicula);
                context.SaveChanges();


                return RedirectToAction("Index");
            }

            ViewBag.Directores = GetDirectores();
            return View(pelicula);
        }

        [HttpGet]
        public IActionResult CheckFavorite(int id)
        {
            var pelicula = context.Peliculas.Find(id);
            return View("Check", pelicula);
        }

        [HttpPost]
        public IActionResult CheckFavorite(int id, bool esFavorito)
        {
            var pelicula = context.Peliculas.Find(id);
            pelicula.IsFavorite = esFavorito;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        private List<String> GetDirectores()
        {
            return new List<string>
            {
                "Director 1", "Director 2", "Director 3", "Director 4", "Director 5",
            };
        }
    }
}