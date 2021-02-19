using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Models
{
    public class Materias
    {
        [Key]
        public int id { get; set; }
        public string nombre_materia { get; set; }
        public int profesor { get; set; }
    }
}
