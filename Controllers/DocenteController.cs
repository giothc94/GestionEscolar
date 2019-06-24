using GestionEscolar.Models.DAO;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.Controllers
{
    public class DocenteController : Controller
    {
        public IActionResult Index()
        {   
            
            ViewData["listaMaterias"] = MateriaDao.MateriasPorIdDocente(6);
            return View(ViewBag);
        }
        public IActionResult Notas()
        {
            return View();
        }

        public IActionResult Tareas()
        {
            return View();
        }

        public IActionResult Foros()
        {
            return View();
        }
    }
}