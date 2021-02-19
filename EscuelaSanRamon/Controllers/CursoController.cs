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
    public class CursoController : ControllerBase
    {
        CrudCurso Consulta = new CrudCurso();

        [HttpGet]
        public IEnumerable<Cursos> Get()
        {
            return Consulta.GetData();
        }

        [HttpGet("{id:int}")]
        public IEnumerable<Cursos> GetById(int id)
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
        public IEnumerable<Cursos> Post([FromBody] Cursos Rjson)
        {
            try
            {
                int profesor_encargado = Rjson.profesor_encargado;
                int grado = Rjson.grado;

                Consulta.AddData(profesor_encargado, grado);

                return Consulta.GetData();
            }
            catch (Exception)
            {
                return Consulta.GetData();
            }

        }

        [HttpPut]
        public IEnumerable<Cursos> Put([FromBody] Cursos Rjson)
        {
            try
            {
                int id = Rjson.id;
                int profesor_encargado = Rjson.profesor_encargado;
                int grado = Rjson.grado;

                Consulta.UpdateData(id, profesor_encargado, grado);

                return Consulta.GetData();
            }
            catch (Exception)
            {
                return Consulta.GetData();
            }

        }

        [HttpDelete]
        public IEnumerable<Cursos> Delete([FromBody] Cursos Rjson)
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
