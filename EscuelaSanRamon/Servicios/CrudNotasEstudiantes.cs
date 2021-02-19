using EscuelaSanRamon.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Servicios
{
    public class CrudNotasEstudiantes
    {
        BaseDatos bd = new BaseDatos();
        public IEnumerable<NotasEstudiantesM> GetDataById(int idR = -1)
        {
            List<string> nombre_estudiante = new List<string>();
            List<double> nota1 = new List<double>();
            List<double> nota2 = new List<double>();
            List<double> nota3 = new List<double>();
            List<double> nota4 = new List<double>();
            List<double> promedio = new List<double>();
            List<string> nombre_materia = new List<string>();
            List<string> profesor_encargado = new List<string>();

            string query3;

            if (idR <= -1)
            {
                query3 = "SELECT * FROM estudiantes";
            }
            else
            {
                query3 = "SELECT e.nombres AS nombre_estudiante, n.nota1, n.nota2, n.nota3, n.nota4, m.nombre_materia, p.nombre AS profesor_encargado FROM estudiantes e, notas n, profesores p, materias m WHERE e.id = n.estudiante AND p.id = m.profesor AND n.materia = m.id AND e.documento_identidad = '" + idR + "';";
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
                    nota1.Add(leer.GetFloat(1));
                    nota2.Add(leer.GetFloat(2));
                    nota3.Add(leer.GetFloat(3));
                    nota4.Add(leer.GetFloat(4));
                    nombre_materia.Add(leer.GetString(5));
                    profesor_encargado.Add(leer.GetString(6));
                    promedio.Add((leer.GetFloat(1) + leer.GetFloat(2) + leer.GetFloat(3) + leer.GetFloat(3)) / 4);
                    CountData++;
                }
                leer.Close();

                leer = commandDatabase.ExecuteReader();

                string[] nombre_estudianteA = nombre_estudiante.ToArray();
                double[] nota1A = nota1.ToArray();
                double[] nota2A = nota2.ToArray();
                double[] nota3A = nota3.ToArray();
                double[] nota4A = nota4.ToArray();
                double[] promeioA = promedio.ToArray();
                string[] nombre_materiaA = nombre_materia.ToArray();
                string[] profesor_encargadoA = profesor_encargado.ToArray();

                IEnumerable<NotasEstudiantesM> data = Enumerable.Range(1, CountData).Select(index => new NotasEstudiantesM
                {
                    nombre_estudiante = nombre_estudianteA[index - 1],
                    nota1 = nota1A[index - 1],
                    nota2 = nota2A[index - 1],
                    nota3 = nota3A[index - 1],
                    nota4 = nota4A[index - 1],
                    nombre_materia = nombre_materiaA[index - 1],
                    profesor_encargado = profesor_encargadoA[index - 1],
                    promedio = nota1A[index - 1],
                }).ToArray();

                bd.DB.Close();

                return data;
            }
            else
            {
                IEnumerable<NotasEstudiantesM> data = Enumerable.Range(1, 1).Select(index => new NotasEstudiantesM
                {
                    nombre_estudiante = "NO DATA",
                    nota1 = -1,
                    nota2 = -1,
                    nota3 = -1,
                    nota4 = -1,
                    nombre_materia = "NO DATA",
                    profesor_encargado = "NO DATA",
                    promedio = -1,
                }).ToArray();

                bd.DB.Close();

                return data;
            }

        }

        public IEnumerable<NotasEstudiantesM> Error()
        {
            IEnumerable<NotasEstudiantesM> data = Enumerable.Range(1, 1).Select(index => new NotasEstudiantesM
            {
                nombre_estudiante = "NO DATA",
                nota1 = -1,
                nota2 = -1,
                nota3 = -1,
                nota4 = -1,
                nombre_materia = "NO DATA",
                profesor_encargado = "NO DATA",
                promedio = -1,
            }).ToArray();

            return data;
        }
    }
}
