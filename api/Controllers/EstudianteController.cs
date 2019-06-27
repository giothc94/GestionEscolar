
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
    public class EstudianteController : ControllerBase
    {
        [HttpGet("Cedula/{cedula}")]
        public ActionResult EstudianteCedula(string cedula)
        {
            var estudiante = EstudianteDao.BuscarEstudiantePorCedula(cedula);
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrWhiteSpace(cedula))
            {
                return NotFound();
            }
            else
            {
                return Ok(estudiante);
            }

        }
        [HttpGet("id/{id}")]
        public ActionResult DocenteId(int id)
        {
            var docente = DocenteDao.BuscarDocentePorId(id);
            if (id < 0)
            {
                return NotFound(id);
            }
            else
            {
                return Ok(docente);
            }

        }
        [HttpGet("Lista/")]
        public ActionResult ListaEstudiante()
        {
            List<Estudiante> estudiantes = EstudianteDao.ListarEstudiantes();
            if (!estudiantes.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(estudiantes);
            }

        }
    }
}