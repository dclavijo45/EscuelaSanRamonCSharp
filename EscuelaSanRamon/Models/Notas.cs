using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Models
{
    public class Notas
    {
        [Key]
        public int id { get; set; }
        public double nota1 { get; set; }
        public double nota2 { get; set; }
        public double nota3 { get; set; }
        public double nota4 { get; set; }
        public double promedio { get; set; }
        public int estudiante { get; set; }
        public int materia { get; set; }
    }
}
