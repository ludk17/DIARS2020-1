using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.ViewModels
{
    public class Respuesta
    {
        public int PreguntaId { get; set; }
        public List<Valor> Valor { get; set; }
    }

    public class Valor
    {
        public int AlternativaId { get; set; }
        public bool EstaMarcada { get; set; }
    }
}
