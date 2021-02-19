using EscuelaSanRamon.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Servicios
{
    public class CrudDirectorGInfo
    {
        BaseDatos bd = new BaseDatos();
        public IEnumerable<DirectorGInfoM> GetDataById(int idR = -1)
        {
            List<string> nombre_profesor = new List<string>();
            List<string> asignatura = new List<string>();
            List<int> grado_encargado = new List<int>();

            string query3;

            if (idR <= -1)
            {
                query3 = "SELECT * FROM estudiantes";
            }
            else
            {
                query3 = "SELECT p.nombre AS nombre_profesor, p.asignatura, c.grado AS grado_encargado FROM profesores p, cursos c WHERE c.profesor_encargado = p.id and p.id = '" + idR + "';";
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
                    nombre_profesor.Add(leer.GetString(0));
                    asignatura.Add(leer.GetString(1));
                    grado_encargado.Add(leer.GetInt32(2));
                    CountData++;
                }
                leer.Close();

                leer = commandDatabase.ExecuteReader();

                string[] nombre_profesorA = nombre_profesor.ToArray();
                string[] asignaturaA = asignatura.ToArray();
                int[] grado_encargadoA = grado_encargado.ToArray();

                IEnumerable<DirectorGInfoM> data = Enumerable.Range(1, CountData).Select(index => new DirectorGInfoM
                {
                    nombre_profesor = nombre_profesorA[index - 1],
                    asignatura = asignaturaA[index - 1],
                    grado_encargado = grado_encargadoA[index - 1]
                }).ToArray();

                bd.DB.Close();

                return data;
            }
            else
            {
                IEnumerable<DirectorGInfoM> data = Enumerable.Range(1, 1).Select(index => new DirectorGInfoM
                {
                    nombre_profesor = "NO DATA",
                    asignatura = "NO DATA",
                    grado_encargado = -1
                }).ToArray();

                bd.DB.Close();

                return data;
            }

        }

        public IEnumerable<DirectorGInfoM> Error()
        {
            IEnumerable<DirectorGInfoM> data = Enumerable.Range(1, 1).Select(index => new DirectorGInfoM
            {
                nombre_profesor = "NO DATA",
                asignatura = "NO DATA",
                grado_encargado = -1
            }).ToArray();

            return data;
        }
    }
}
