using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Models
{
    public class Cursos
    {
        [Key]
        public int id { get; set; }

        public int profesor_encargado { get; set; }
        public int grado { get; set; }
    }
}
