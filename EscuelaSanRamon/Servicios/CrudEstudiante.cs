using EscuelaSanRamon.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Servicios
{
    public class CrudEstudiante
    {
        BaseDatos bd = new BaseDatos();

        public IEnumerable<Estudiantes> GetData()
        {
            List<int> id = new List<int>();
            List<int> documento_identidad = new List<int>();
            List<string> nombres = new List<string>();
            List<int> curso = new List<int>();

            string query3 = "SELECT * FROM estudiantes";

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
                    nombres.Add(leer.GetString(1));
                    curso.Add(leer.GetInt32(2));
                    documento_identidad.Add(leer.GetInt32(3));
                    CountData++;
                }
                leer.Close();

                leer = commandDatabase.ExecuteReader();

                int[] idA = id.ToArray();
                string[] nombresA = nombres.ToArray();
                int[] cursoA = curso.ToArray();
                int[] documento_identidadA = documento_identidad.ToArray();

                IEnumerable<Estudiantes> data = Enumerable.Range(1, CountData).Select(index => new Estudiantes
                {
                    id = idA[index - 1],
                    nombres = nombresA[index - 1],
                    curso = cursoA[index - 1],
                    documento_identidad = documento_identidadA[index - 1]
                }).ToArray();

                bd.DB.Close();

                return data;
            }
            else
            {
                IEnumerable<Estudiantes> data = Enumerable.Range(1, 1).Select(index => new Estudiantes
                {
                    id = -1,
                    nombres = "NO DATA",
                    curso = -1,
                    documento_identidad = -1
                }).ToArray();

                bd.DB.Close();

                return data;
            }

        }

        public IEnumerable<Estudiantes> GetDataById(int idR = -1)
        {
            List<int> id = new List<int>();
            List<int> documento_identidad = new List<int>();
            List<string> nombres = new List<string>();
            List<int> curso = new List<int>();

            string query3;

            if (idR <= -1)
            {
                query3 = "SELECT * FROM estudiantes";
            }
            else
            {
                query3 = "SELECT * FROM estudiantes WHERE id= '"+ idR +"'";
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
                    nombres.Add(leer.GetString(1));
                    curso.Add(leer.GetInt32(2));
                    documento_identidad.Add(leer.GetInt32(3));
                    CountData++;
                }
                leer.Close();

                leer = commandDatabase.ExecuteReader();

                int[] idA = id.ToArray();
                string[] nombresA = nombres.ToArray();
                int[] cursoA = curso.ToArray();
                int[] documento_identidadA = documento_identidad.ToArray();

                IEnumerable<Estudiantes> data = Enumerable.Range(1, CountData).Select(index => new Estudiantes
                {
                    id = idA[index - 1],
                    nombres = nombresA[index - 1],
                    curso = cursoA[index - 1],
                    documento_identidad = documento_identidadA[index - 1]
                }).ToArray();

                bd.DB.Close();

                return data;
            }
            else
            {
                IEnumerable<Estudiantes> data = Enumerable.Range(1, 1).Select(index => new Estudiantes
                {
                    id = -1,
                    nombres = "NO DATA",
                    curso = -1,
                    documento_identidad = -1
                }).ToArray();

                bd.DB.Close();

                return data;
            }

        }
        public void AddData(string nombres = null, int curso = -1, int documento_identidad = -1)
        {
            if (nombres != null || curso != -1 || documento_identidad != -1)
            {
                string query3 = "INSERT INTO estudiantes(nombres, curso, documento_identidad) VALUES('" + nombres + "','" + curso + "', '" + documento_identidad + "')";

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

        public void UpdateData(int id = -1, string nombres = null, int curso = -1, int documento_identidad = -1)
        {
            if (id != -1 || nombres != null || curso != -1 || documento_identidad == -1)
            {
                string query3 = "UPDATE estudiantes SET nombres ='" + nombres + "', curso = '" + curso + "', documento_identidad = '" + documento_identidad + "' WHERE id = '" + id + "'";

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
                string query3 = "DELETE FROM estudiantes WHERE id='" + id + "'";

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
