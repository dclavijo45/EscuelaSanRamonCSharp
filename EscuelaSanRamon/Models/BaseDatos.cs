using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Models
{
    public class BaseDatos
    {
        public MySqlConnection DB { get; set; } = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=escuela;");
    }
}
