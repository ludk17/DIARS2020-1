using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class Alternativa
    {
        public int Id { get; set; }
        [Required]
        public string Resumen { get; set; }
        [Required]
        public int PreguntaId { get; set; }
        public bool EsCorrecto { get; set; }
        public Pregunta Pregunta { get; set; }
    }
}
