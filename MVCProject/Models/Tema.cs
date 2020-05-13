using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class Tema
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public List<Pregunta> Preguntas { get; set; }
    }
}
