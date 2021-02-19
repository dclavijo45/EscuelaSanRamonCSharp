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
    public class EstudianteController : ControllerBase
    {
        CrudEstudiante Consulta = new CrudEstudiante();

        [HttpGet]
        public IEnumerable<Estudiantes> Get()
        {
            return Consulta.GetData();
        }

        [HttpGet("{id:int}")]
        public IEnumerable<Estudiantes> GetById(int id)
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
        public IEnumerable<Estudiantes> Post([FromBody] Estudiantes Rjson)
        {
            try
            {
                string nombres = Rjson.nombres;
                int curso = Rjson.curso;
                int documento_identidad = Rjson.documento_identidad;

                Consulta.AddData(nombres, curso, documento_identidad);

                return Consulta.GetData();
            }
            catch (Exception)
            {
                return Consulta.GetData();
            }

        }

        [HttpPut]
        public IEnumerable<Estudiantes> Put([FromBody] Estudiantes Rjson)
        {
            try
            {
                int id = Rjson.id;
                string nombres = Rjson.nombres;
                int curso = Rjson.curso;
                int documento_identidad = Rjson.documento_identidad;

                Consulta.UpdateData(id, nombres, curso, documento_identidad);

                return Consulta.GetData();
            }
            catch (Exception)
            {
                return Consulta.GetData();
            }

        }

        [HttpDelete]
        public IEnumerable<Estudiantes> Delete([FromBody] Estudiantes Rjson)
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
