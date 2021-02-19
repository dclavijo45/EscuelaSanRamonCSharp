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
    public class DirectorGInfo : ControllerBase
    {
        CrudDirectorGInfo Consulta = new CrudDirectorGInfo();

        [Route("api/[controller]")]

        [HttpGet("{id:int}")]
        public IEnumerable<DirectorGInfoM> GetById(int id)
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
