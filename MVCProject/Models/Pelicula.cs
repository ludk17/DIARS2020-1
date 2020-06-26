using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        [Required]
        public String Code { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Director { get; set; }
        [Required]
        public int Year { get; set; }        
        public bool IsFavorite { get; set; }
        public String Imagen { get; set; }

    }
}
