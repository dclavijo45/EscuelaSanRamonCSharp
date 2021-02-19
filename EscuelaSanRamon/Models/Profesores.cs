using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Models
{
    public class Profesores
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string asignatura { get; set; }
    }
}
