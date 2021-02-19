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
    public class CursosEstudianteController : ControllerBase
    {
        CrudCursosEstudiante Consulta = new CrudCursosEstudiante();

        [Route("api/[controller]")]

        [HttpGet("{id:int}")]
        public IEnumerable<CursosEstudiante> GetById(int id)
        {
            try
            {
                return Consulta.GetDataById(id);
            }
            catch (Exception)
            {
                return Consulta.Error();
            }
        }
    }
}
