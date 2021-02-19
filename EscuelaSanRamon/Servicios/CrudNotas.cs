using EscuelaSanRamon.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Servicios
{
    public class CrudNotas
    {
        BaseDatos bd = new BaseDatos();

        public IEnumerable<Notas> GetData()
        {
            List<int> id = new List<int>();
            List<double> nota1 = new List<double>();
            List<double> nota2 = new List<double>();
            List<double> nota3 = new List<double>();
            List<double> nota4 = new List<double>();
            List<double> promedio = new List<double>();
            List<int> estudiante = new List<int>();
            List<int> materia = new List<int>();

            string query3 = "SELECT * FROM notas";

            MySqlDataReader leer;

            bd.DB.Open();

            MySqlCommand commandDatabase = new MySqlCommand(query3, bd.DB);

            leer = commandDatabase.ExecuteReader();

            if (leer.HasRows)
            {
                int CountData = 0;
                while (leer.Read())
                {
                    id.Add(leer.GetInt32(0));
                    nota1.Add(leer.GetFloat(1));
                    nota2.Add(leer.GetFloat(2));
                    nota3.Add(leer.GetFloat(3));
                    nota4.Add(leer.GetFloat(4));
                    promedio.Add((leer.GetFloat(1)+ leer.GetFloat(2)+ leer.GetFloat(3)+ leer.GetFloat(4)) / 4);
                    estudiante.Add(leer.GetInt32(5));
                    materia.Add(leer.GetInt32(6));
                    CountData++;
                }
                leer.Close();

                leer = commandDatabase.ExecuteReader();

                int[] idA = id.ToArray();
                double[] nota1A = nota1.ToArray();
                double[] nota2A = nota2.ToArray();
                double[] nota3A = nota3.ToArray();
                double[] nota4A = nota4.ToArray();
                double[] promedioA = promedio.ToArray();
                int[] estudianteA = estudiante.ToArray();
                int[] materiaA = materia.ToArray();


                IEnumerable<Notas> data = Enumerable.Range(1, CountData).Select(index => new Notas
                {
                    id = idA[index - 1],
                    nota1 = nota1A[index - 1],
                    nota2 = nota2A[index - 1],
                    nota3 = nota3A[index - 1],
                    nota4 = nota4A[index - 1],
                    promedio = promedioA[index - 1],
                    estudiante = estudianteA[index - 1],
                    materia = materiaA[index - 1]
                }).ToArray();

                bd.DB.Close();

                return data;
            }
            else
            {
                IEnumerable<Notas> data = Enumerable.Range(1, 1).Select(index => new Notas
                {
                    id = -1,
                    nota1 = -1,
                    nota2 = -1,
                    nota3 = -1,
                    nota4 = -1,
                    promedio = -1,
                    estudiante = -1,
                    materia = -1
                }).ToArray();

                bd.DB.Close();

                return data;
            }

        }

        public IEnumerable<Notas> GetDataById(int idR = -1)
        {
            List<int> id = new List<int>();
            List<double> nota1 = new List<double>();
            List<double> nota2 = new List<double>();
            List<double> nota3 = new List<double>();
            List<double> nota4 = new List<double>();
            List<double> promedio = new List<double>();
            List<int> estudiante = new List<int>();
            List<int> materia = new List<int>();

            string query3;

            if (idR <= -1)
            {
                query3 = "SELECT * FROM notas";
            }
            else
            {
                query3 = "SELECT * FROM notas WHERE id = '"+ idR +"'";
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
                    id.Add(leer.GetInt32(0));
                    nota1.Add(leer.GetFloat(1));
                    nota2.Add(leer.GetFloat(2));
                    nota3.Add(leer.GetFloat(3));
                    nota4.Add(leer.GetFloat(4));
                    promedio.Add((leer.GetFloat(1) + leer.GetFloat(2) + leer.GetFloat(3) + leer.GetFloat(4)) / 4);
                    estudiante.Add(leer.GetInt32(5));
                    materia.Add(leer.GetInt32(6));
                    CountData++;
                }
                leer.Close();

                leer = commandDatabase.ExecuteReader();

                int[] idA = id.ToArray();
                double[] nota1A = nota1.ToArray();
                double[] nota2A = nota2.ToArray();
                double[] nota3A = nota3.ToArray();
                double[] nota4A = nota4.ToArray();
                double[] promedioA = promedio.ToArray();
                int[] estudianteA = estudiante.ToArray();
                int[] materiaA = materia.ToArray();


                IEnumerable<Notas> data = Enumerable.Range(1, CountData).Select(index => new Notas
                {
                    id = idA[index - 1],
                    nota1 = nota1A[index - 1],
                    nota2 = nota2A[index - 1],
                    nota3 = nota3A[index - 1],
                    nota4 = nota4A[index - 1],
                    promedio = promedioA[index - 1],
                    estudiante = estudianteA[index - 1],
                    materia = materiaA[index - 1]
                }).ToArray();

                bd.DB.Close();

                return data;
            }
            else
            {
                IEnumerable<Notas> data = Enumerable.Range(1, 1).Select(index => new Notas
                {
                    id = -1,
                    nota1 = -1,
                    nota2 = -1,
                    nota3 = -1,
                    nota4 = -1,
                    promedio = -1,
                    estudiante = -1,
                    materia = -1
                }).ToArray();

                bd.DB.Close();

                return data;
            }

        }
        public void AddData(double nota1 = -1, double nota2 = -1, double nota3 = -1, double nota4 = -1, int estudiante = -1, int materia = -1)
        {
            if (nota1 != -1 || nota2 != -1 || nota3 != -1 || nota4 != -1 || estudiante != -1 || materia == -1)
            {
                string query3 = "INSERT INTO notas(nota1, nota2, nota3, nota4, estudiante, materia) VALUES('" + nota1 + "','" + nota2 + "','" + nota3 + "','" + nota4 + "','" + estudiante + "', '" +  materia + "')";

                MySqlDataReader leer;

                bd.DB.Open();

                try
                {
                    MySqlCommand commandDatabase = new MySqlCommand(query3, bd.DB);

                    leer = commandDatabase.ExecuteReader();

                    bd.DB.Close();
                }
                catch (Exception)
                {
                    bd.DB.Close();
                }
            }
        }

        public void UpdateData(int id = -1, double nota1 = -1, double nota2 = -1, double nota3 = -1, double nota4 = -1, int estudiante = -1, int materia = -1)
        {
            if (id != -1 || nota1 != -1 || nota2 != -1 || nota3 != -1 || nota4 != -1 || estudiante != -1 || materia == -1)
            {
                string query3 = "UPDATE notas SET nota1 ='" + nota1 + "', nota2 = '" + nota2 + "' , nota3 = '" + nota3 + "' , nota4 = '" + nota4 + "' , estudiante = '" + estudiante + "', materia = '" + materia + "' WHERE id = '" + id + "'";

                MySqlDataReader leer;

                bd.DB.Open();

                try
                {
                    MySqlCommand commandDatabase = new MySqlCommand(query3, bd.DB);

                    leer = commandDatabase.ExecuteReader();

                    bd.DB.Close();
                }
                catch (Exception)
                {
                    bd.DB.Close();
                }
            }
        }

        public void DeleteData(int id = -1)
        {
            if (id != -1)
            {
                string query3 = "DELETE FROM notas WHERE id='" + id + "'";

                MySqlDataReader leer;

                bd.DB.Open();

                try
                {
                    MySqlCommand commandDatabase = new MySqlCommand(query3, bd.DB);

                    leer = commandDatabase.ExecuteReader();

                    leer.Close();

                    bd.DB.Close();

                }
                catch (Exception)
                {
                    bd.DB.Close();
                }
            }
        }
    }
}
