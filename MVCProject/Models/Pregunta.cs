using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class Pregunta
    {
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int TemaId { get; set; }
        public Tema Tema { get; set; }
        public List<Alternativa> Alternativas { get; set; }
    }
}
