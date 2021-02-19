using EscuelaSanRamon.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Servicios
{
    public class CrudProfesor
    {
        BaseDatos bd = new BaseDatos();

        public IEnumerable<Profesores> GetData()
        {
            List<int> id = new List<int>();
            List<string> nombre = new List<string>();
            List<string> asignatura = new List<string>();

            string query3 = "SELECT * FROM profesores";

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
                    nombre.Add(leer.GetString(1));
                    asignatura.Add(leer.GetString(2));
                    CountData++;
                }
                leer.Close();

                leer = commandDatabase.ExecuteReader();

                int[] idA = id.ToArray();
                string[] nombreA = nombre.ToArray();
                string[] asignaturaA = asignatura.ToArray();

                IEnumerable<Profesores> data = Enumerable.Range(1, CountData).Select(index => new Profesores
                {
                    id = idA[index - 1],
                    nombre = nombreA[index - 1],
                    asignatura = asignaturaA[index - 1]
                }).ToArray();

                bd.DB.Close();

                return data;
            }
            else
            {
                IEnumerable<Profesores> data = Enumerable.Range(1, 1).Select(index => new Profesores
                {
                    id = -1,
                    nombre = "NO DATA",
                    asignatura = "NO DATA"
                }).ToArray();

                bd.DB.Close();

                return data;
            }

        }
        public IEnumerable<Profesores> GetDataById(int idR = -1)
        {
            List<int> id = new List<int>();
            List<string> nombre = new List<string>();
            List<string> asignatura = new List<string>();

            string query3;
            if (idR <= -1)
            {
                 query3 = "SELECT * FROM profesores";
            }
            else
            {
                 query3 = "SELECT * FROM profesores WHERE id = '" + idR + "'";
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
                    nombre.Add(leer.GetString(1));
                    asignatura.Add(leer.GetString(2));
                    CountData++;
                }
                leer.Close();

                leer = commandDatabase.ExecuteReader();

                int[] idA = id.ToArray();
                string[] nombreA = nombre.ToArray();
                string[] asignaturaA = asignatura.ToArray();

                IEnumerable<Profesores> data = Enumerable.Range(1, CountData).Select(index => new Profesores
                {
                    id = idA[index - 1],
                    nombre = nombreA[index - 1],
                    asignatura = asignaturaA[index - 1]
                }).ToArray();

                bd.DB.Close();

                return data;
            }
            else
            {
                IEnumerable<Profesores> data = Enumerable.Range(1, 1).Select(index => new Profesores
                {
                    id = -1,
                    nombre = "NO DATA",
                    asignatura = "NO DATA"
                }).ToArray();

                bd.DB.Close();

                return data;
            }

        }
        public void AddData(string nombre = null, string asignatura = null)
        {
            if (nombre != null || asignatura != null)
            {
                string query3 = "INSERT INTO profesores(nombre, asignatura) VALUES('" + nombre + "','" + asignatura + "')";

                MySqlDataReader leer;

                bd.DB.Open();

                MySqlCommand commandDatabase = new MySqlCommand(query3, bd.DB);

                leer = commandDatabase.ExecuteReader();

                bd.DB.Close();
            }
        }

        public void UpdateData(int id = -1, string nombre = null, string asignatura = null)
        {
            if (nombre != null || id != -1 || asignatura != null)
            {
                string query3 = "UPDATE profesores SET nombre ='" + nombre + "', asignatura = '" + asignatura + "' WHERE id = '" + id + "'";

                MySqlDataReader leer;

                bd.DB.Open();

                MySqlCommand commandDatabase = new MySqlCommand(query3, bd.DB);

                leer = commandDatabase.ExecuteReader();

                bd.DB.Close();
            }
        }

        public void DeleteData(int id = -1)
        {
            if (id != -1)
            {
                string query3 = "DELETE FROM profesores WHERE id='" + id + "'";

                MySqlDataReader leer;

                bd.DB.Open();

                MySqlCommand commandDatabase = new MySqlCommand(query3, bd.DB);

                leer = commandDatabase.ExecuteReader();

                leer.Close();

                bd.DB.Close();
            }
        }
    }
}
