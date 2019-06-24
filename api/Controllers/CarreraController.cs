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
    public class CarreraController : ControllerBase
    {
        [HttpGet("Nivel/{idCarrera}")]
        public ActionResult DocenteCedula(int idCarrera)
        {
            var nivel = CarreraDao.ListaNivelYCarrera(idCarrera);
            if(nivel == null)
            {
                return NotFound(idCarrera);
            }
            else
            {
                return Ok(nivel);
            }

        }
    }
}