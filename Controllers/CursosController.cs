using System.Diagnostics;
using GestionEscolar.Models.DAO;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.Controllers
{
    public class CursosController : Controller
    {
        public IActionResult Revision(int idMateria)
        {
            Debug.WriteLine("----------------------------------------------");
            Debug.WriteLine(idMateria);
            Debug.WriteLine("----------------------------------------------");
            var materia = MateriaDao.MateriaPorId(idMateria);
            var reporte = EstudianteDao.BuscarEstudiantesPorNivelDeMateria(materia.IdMateria);
            ViewBag.NombreMateria = materia.NombreMateria;
            ViewBag.ListaEstudiantes = reporte;
            return View(ViewBag);
        }
    }
}