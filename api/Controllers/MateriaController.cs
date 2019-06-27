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
            try
            {
                var materia = MateriaDao.MateriaPorId(id);
                if(materia == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(materia);
                }
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("*----------*-*--------------------------");
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.InnerException);
                Debug.WriteLine("*----------*-*--------------------------");
                return NotFound();
            }

        }
        [HttpGet("Nivel/ID/{id}")]
        public ActionResult BucarNivelPorId(int id)
        {
            try
            {
                var nivel = MateriaDao.NivelPorId(id);
                if(nivel == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(nivel);
                }
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("*----------*-*--------------------------");
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.InnerException);
                Debug.WriteLine("*----------*-*--------------------------");
                return NotFound();
            }

        }
    }
}