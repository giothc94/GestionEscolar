using System.Collections.Generic;
using System.Web.Helpers;
using GestionEscolar.Models;
using GestionEscolar.Models.DAO;
using Microsoft.AspNetCore.Mvc;
namespace GestionEscolar.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController: ControllerBase
    {
        [HttpGet("DocenteCedula")]
        public ActionResult DocenteCedula()
        {
            var docentes = DocenteDao.ListarDocentes();
            return Ok(docentes);
        }
    }
}