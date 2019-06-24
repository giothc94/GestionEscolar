
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Helpers;
using GestionEscolar.Models;
using GestionEscolar.Models.DAO;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        [HttpGet("Cedula/{cedula}")]
        public ActionResult DocenteCedula(string cedula)
        {
            var docente = DocenteDao.BuscarDocentePorCedula(cedula);
            if(string.IsNullOrEmpty(cedula) || string.IsNullOrWhiteSpace(cedula))
            {
                return NotFound(cedula);
            }
            else
            {
                Debug.WriteLine("PARAMETRO: "+cedula);
                return Ok(docente);
            }

        }
        [HttpGet("Lista/")]
        public ActionResult ListaDocentes()
        {
            List<Docente> docentes = DocenteDao.ListarDocentes();
            if(!docentes.Any())
            {
                return NotFound(docentes);
            }
            else
            {
                return Ok(docentes);
            }

        }
    }
}