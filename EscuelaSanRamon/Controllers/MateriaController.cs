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
    public class MateriaController : ControllerBase
    {
        CrudMaterias Consulta = new CrudMaterias();

        [HttpGet]
        public IEnumerable<Materias> Get()
        {
            return Consulta.GetData();
        }

        [HttpGet("{id:int}")]
        public IEnumerable<Materias> GetById(int id)
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
        public IEnumerable<Materias> Post([FromBody] Materias Rjson)
        {
            try
            {
                string nombre_materia = Rjson.nombre_materia;

                int profesor = Rjson.profesor;

                Consulta.AddData(nombre_materia, profesor);

                return Consulta.GetData();
            }
            catch (Exception)
            {
                return Consulta.GetData();
            }

        }

        [HttpPut]
        public IEnumerable<Materias> Put([FromBody] Materias Rjson)
        {
            try
            {
                int id = Rjson.id;
                string nombre_materia = Rjson.nombre_materia;
                int profesor = Rjson.profesor;

                Consulta.UpdateData(id, nombre_materia, profesor);

                return Consulta.GetData();
            }
            catch (Exception)
            {
                return Consulta.GetData();
            }

        }

        [HttpDelete]
        public IEnumerable<Materias> Delete([FromBody] Materias Rjson)
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
