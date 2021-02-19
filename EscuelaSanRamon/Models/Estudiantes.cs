using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Models
{
    public class Estudiantes
    {
        [Key]
        public int id { get; set; }
        public string nombres { get; set; }
        public int curso { get; set; }

        public int documento_identidad { get; set; }
    }
}
