using EscuelaSanRamon.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Servicios
{
    public class CrudCurso
    {
        BaseDatos bd = new BaseDatos();

        public IEnumerable<Cursos> GetData()
        {
            List<int> id = new List<int>();
            List<int> profesor_encargado = new List<int>();
            List<int> grado = new List<int>();

            string query3 = "SELECT * FROM cursos";

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
                    profesor_encargado.Add(leer.GetInt32(1));
                    grado.Add(leer.GetInt32(2));
                    CountData++;
                }
                leer.Close();

                leer = commandDatabase.ExecuteReader();

                int[] idA = id.ToArray();
                int[] profesor_encargadoA = profesor_encargado.ToArray();
                int[] gradoA = grado.ToArray();

                IEnumerable<Cursos> data = Enumerable.Range(1, CountData).Select(index => new Cursos
                {
                    id = idA[index - 1],
                    profesor_encargado = profesor_encargadoA[index - 1],
                    grado = gradoA[index - 1]
                }).ToArray();

                bd.DB.Close();

                return data;
            }
            else
            {
                IEnumerable<Cursos> data = Enumerable.Range(1, 1).Select(index => new Cursos
                {
                    id = -1,
                    profesor_encargado = -1,
                    grado = -1
                }).ToArray();

                bd.DB.Close();

                return data;
            }

        }

        public IEnumerable<Cursos> GetDataById(int idR = -1)
        {
            List<int> id = new List<int>();
            List<int> profesor_encargado = new List<int>();
            List<int> grado = new List<int>();

            string query3;

            if (idR <= -1)
            {
                query3 = "SELECT * FROM cursos";
            }
            else
            {
                query3 = "SELECT * FROM cursos WHERE id = '"+ idR +"'";
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
                    profesor_encargado.Add(leer.GetInt32(1));
                    grado.Add(leer.GetInt32(2));
                    CountData++;
                }
                leer.Close();

                leer = commandDatabase.ExecuteReader();

                int[] idA = id.ToArray();
                int[] profesor_encargadoA = profesor_encargado.ToArray();
                int[] gradoA = grado.ToArray();

                IEnumerable<Cursos> data = Enumerable.Range(1, CountData).Select(index => new Cursos
                {
                    id = idA[index - 1],
                    profesor_encargado = profesor_encargadoA[index - 1],
                    grado = gradoA[index - 1]
                }).ToArray();

                bd.DB.Close();

                return data;
            }
            else
            {
                IEnumerable<Cursos> data = Enumerable.Range(1, 1).Select(index => new Cursos
                {
                    id = -1,
                    profesor_encargado = -1,
                    grado = -1
                }).ToArray();

                bd.DB.Close();

                return data;
            }

        }
        public void AddData(int profesor_encargado = -1, int grado = -1)
        {
            if (profesor_encargado != -1 || grado != -1)
            {
                string query3 = "INSERT INTO cursos(profesor_encargado, grado) VALUES('" + profesor_encargado + "','" + grado + "')";

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

        public void UpdateData(int id = -1, int profesor_encargado = -1, int grado = -1)
        {
            if (id != -1 || profesor_encargado != -1 || grado != -1)
            {
                string query3 = "UPDATE cursos SET profesor_encargado ='" + profesor_encargado + "', grado = '" + grado + "' WHERE id = '" + id + "'";

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
                string query3 = "DELETE FROM cursos WHERE id='" + id + "'";

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
