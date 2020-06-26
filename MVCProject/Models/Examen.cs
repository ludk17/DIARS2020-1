using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class Examen
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TemaId { get; set; }
        public int Nota { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
