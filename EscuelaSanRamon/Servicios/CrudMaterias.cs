using EscuelaSanRamon.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Servicios
{
    public class CrudMaterias
    {
        BaseDatos bd = new BaseDatos();

        public IEnumerable<Materias> GetData()
        {
            List<int> id = new List<int>();
            List<string> nombre_materia = new List<string>();
            List<int> profesor = new List<int>();

            string query3 = "SELECT * FROM materias";

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
                    nombre_materia.Add(leer.GetString(1));
                    profesor.Add(leer.GetInt32(2));
                    CountData++;
                }
                leer.Close();

                leer = commandDatabase.ExecuteReader();

                int[] idA = id.ToArray();
                string[] nombre_materiaA = nombre_materia.ToArray();
                int[] profesorA = profesor.ToArray();


                IEnumerable<Materias> data = Enumerable.Range(1, CountData).Select(index => new Materias
                {
                    id = idA[index - 1],
                    nombre_materia = nombre_materiaA[index - 1],
                    profesor = profesorA[index - 1]
                }).ToArray();

                bd.DB.Close();

                return data;
            }
            else
            {
                IEnumerable<Materias> data = Enumerable.Range(1, 1).Select(index => new Materias
                {
                    id = -1,
                    nombre_materia = "NO DATA",
                    profesor = -1
                }).ToArray();

                bd.DB.Close();

                return data;
            }

        }

        public IEnumerable<Materias> GetDataById(int idR)
        {
            List<int> id = new List<int>();
            List<string> nombre_materia = new List<string>();
            List<int> profesor = new List<int>();

            string query3;

            if (idR <= -1)
            {
                query3 = "SELECT * FROM materias";
            }
            else
            {
                query3 = "SELECT * FROM materias WHERE id = '"+ idR +"'";
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
                    nombre_materia.Add(leer.GetString(1));
                    profesor.Add(leer.GetInt32(2));
                    CountData++;
                }
                leer.Close();

                leer = commandDatabase.ExecuteReader();

                int[] idA = id.ToArray();
                string[] nombre_materiaA = nombre_materia.ToArray();
                int[] profesorA = profesor.ToArray();


                IEnumerable<Materias> data = Enumerable.Range(1, CountData).Select(index => new Materias
                {
                    id = idA[index - 1],
                    nombre_materia = nombre_materiaA[index - 1],
                    profesor = profesorA[index - 1]
                }).ToArray();

                bd.DB.Close();

                return data;
            }
            else
            {
                IEnumerable<Materias> data = Enumerable.Range(1, 1).Select(index => new Materias
                {
                    id = -1,
                    nombre_materia = "NO DATA",
                    profesor = -1
                }).ToArray();

                bd.DB.Close();

                return data;
            }

        }
        public void AddData(string nombre_materia = null, int profesor = -1)
        {
            if (nombre_materia != null || profesor != -1)
            {
                string query3 = "INSERT INTO materias(nombre_materia, profesor) VALUES('" + nombre_materia + "','" + profesor + "')";

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

        public void UpdateData(int id = -1, string nombre_materia = null, int profesor = -1)
        {
            if (id != -1 || nombre_materia != null || profesor != -1)
            {
                string query3 = "UPDATE materias SET nombre_materia ='" + nombre_materia + "', profesor = '" + profesor + "' WHERE id = '" + id + "'";

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
                string query3 = "DELETE FROM materias WHERE id='" + id + "'";

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
