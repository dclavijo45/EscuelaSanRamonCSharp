using EscuelaSanRamon.Models;
using EscuelaSanRamon.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaSanRamon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        CrudProfesor Consulta = new CrudProfesor();

        [HttpGet] 
        public IEnumerable<Profesores> Get()
        {
            return Consulta.GetData();
        }

        [HttpGet("{id:int}")]
        public IEnumerable<Profesores> GetById(int id)
        {
            try
            {
                return Consulta.GetDataById(id);
            }
            catch (Exception)
            {
                return Consulta.GetData();
            }
        }

        [HttpPost]
        public IEnumerable<Profesores> Post([FromBody] Profesores Rjson) 
        {
            try
            {
                string nombre = Rjson.nombre;
                string asignatura = Rjson.asignatura;

                Consulta.AddData(nombre, asignatura);

                return Consulta.GetData();
            }
            catch (Exception)
            {
                return Consulta.GetData();
            }
            
        }

        [HttpPut]
        public IEnumerable<Profesores> Put([FromBody] Profesores Rjson)
        {
            try
            {
                int id = Rjson.id;
                string nombre = Rjson.nombre;
                string asignatura = Rjson.asignatura;

                Consulta.UpdateData(id, nombre, asignatura);

                return Consulta.GetData();
            }
            catch (Exception)
            {
                return Consulta.GetData();
            }

        }

        [HttpDelete]
        public IEnumerable<Profesores> PDeleteut([FromBody] Profesores Rjson)
        {
            try
            {
                int id = Rjson.id;

                Consulta.DeleteData(id);

                return Consulta.GetData();
            }
            catch (Exception)
            {
                return Consulta.GetData();
            }

        }
    }
}

