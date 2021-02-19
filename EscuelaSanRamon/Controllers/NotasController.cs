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
    public class NotasController : ControllerBase
    {
        CrudNotas Consulta = new CrudNotas();

        [HttpGet]
        public IEnumerable<Notas> Get()
        {
            return Consulta.GetData();
        }

        [HttpGet("{id:int}")]
        public IEnumerable<Notas> GetById(int id)
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
        public IEnumerable<Notas> Post([FromBody] Notas Rjson)
        {
            try
            {
                double nota1 = Rjson.nota1;
                double nota2 = Rjson.nota2;
                double nota3 = Rjson.nota3;
                double nota4 = Rjson.nota4;
                int estudiante = Rjson.estudiante;
                int materia = Rjson.materia;

                Consulta.AddData(nota1, nota2, nota3, nota4, estudiante, materia);

                return Consulta.GetData();
            }
            catch (Exception)
            {
                return Consulta.GetData();
            }

        }

        [HttpPut]
        public IEnumerable<Notas> Put([FromBody] Notas Rjson)
        {
            try
            {
                int id = Rjson.id;
                double nota1 = Rjson.nota1;
                double nota2 = Rjson.nota2;
                double nota3 = Rjson.nota3;
                double nota4 = Rjson.nota4;
                int estudiante = Rjson.estudiante;
                int materia = Rjson.materia;

                Consulta.UpdateData(id, nota1, nota2, nota3, nota4, estudiante,materia);

                return Consulta.GetData();
            }
            catch (Exception)
            {
                return Consulta.GetData();
            }

        }

        [HttpDelete]
        public IEnumerable<Notas> Delete([FromBody] Notas Rjson)
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
