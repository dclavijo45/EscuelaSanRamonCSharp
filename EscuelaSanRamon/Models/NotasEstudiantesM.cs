using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Models
{
    public class NotasEstudiantesM
    {
        public string nombre_estudiante { get; set; }
        public double nota1 { get; set; }
        public double nota2 { get; set; }
        public double nota3 { get; set; }
        public double nota4 { get; set; }
        public double promedio { get; set; }
        public string nombre_materia { get; set; }
        public string profesor_encargado { get; set; }
    }
}
