using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Helpers;
using GestionEscolar.Models;
using GestionEscolar.Models.DAO;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        [HttpGet("ID/{id}")]
        public ActionResult BucarMateriaPorId(int id)
        {
            var materia = MateriaDao.MateriaPorId(id);
            if(materia == null)
            {
                return NotFound(id);
            }
            else
            {
                return Ok(materia);
            }

        }
    }
}