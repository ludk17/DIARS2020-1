using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class ExamenPregunta
    {
        public int Id { get; set; }
        public int ExamenId { get; set; }
        public int PreguntaId { get; set; }
    }
}
