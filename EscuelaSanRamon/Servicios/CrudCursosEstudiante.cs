using EscuelaSanRamon.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Servicios
{
    public class CrudCursosEstudiante
    {
        BaseDatos bd = new BaseDatos();
        public IEnumerable<CursosEstudiante> GetDataById(int idR = -1)
        {
            List<string> nombre_estudiante = new List<string>();
            List<int> grado = new List<int>();
            List<string> nombre_profesor = new List<string>();

            string query3;

            if (idR <= -1)
            {
                query3 = "SELECT * FROM estudiantes";
            }
            else
            {
                query3 = "SELECT e.nombres AS nombre_estudiante, c.grado, p.nombre AS nombre_profesor FROM cursos c, estudiantes e, profesores p WHERE p.id = c.profesor_encargado and documento_identidad = '" + idR +"';";
            }

            MySqlDataReader leer;

            bd.DB.Open();

            MySqlCommand commandDatabase = new MySqlCommand(query3, bd.DB);

            leer = commandDatabase.ExecuteReader();

            if (leer.HasRows)
            {
                int CountData = 0;
                while (leer.Read())
                {
                    nombre_estudiante.Add(leer.GetString(0));
                    grado.Add(leer.GetInt32(1));
                    nombre_profesor.Add(leer.GetString(2));
                    CountData++;
                }
                leer.Close();

                leer = commandDatabase.ExecuteReader();

                string[] nombre_estudianteA = nombre_estudiante.ToArray();
                int[] gradoA = grado.ToArray();
                string[] nombre_profesorA = nombre_profesor.ToArray();

                IEnumerable<CursosEstudiante> data = Enumerable.Range(1, CountData).Select(index => new CursosEstudiante
                {
                    nombre_estudiante = nombre_estudianteA[index - 1],
                    grado = gradoA[index - 1],
                    nombre_profesor = nombre_profesorA[index - 1]
                }).ToArray();

                bd.DB.Close();

                return data;
            }
            else
            {
                IEnumerable<CursosEstudiante> data = Enumerable.Range(1, 1).Select(index => new CursosEstudiante
                {
                    nombre_estudiante = "NO DATA",
                    grado = -1,
                    nombre_profesor = "NO DATA"
                }).ToArray();

                bd.DB.Close();

                return data;
            }

        }

        public IEnumerable<CursosEstudiante> Error()
        {
            IEnumerable<CursosEstudiante> data = Enumerable.Range(1, 1).Select(index => new CursosEstudiante
            {
                nombre_estudiante = "NO DATA",
                grado = -1,
                nombre_profesor = "NO DATA"
            }).ToArray();

            return data;
        }
    }
}
