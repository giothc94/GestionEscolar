using GestionEscolar.Models.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.Controllers
{
    public class DocenteController : Controller
    {
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("docente"))
                {
                    var docente = DocenteDao.BuscarDocentePorCedula(HttpContext.Session.GetString("username"));
                    ViewBag.Nombre = docente.ApellidoUno + " " + docente.ApellidoDos + " " + docente.NombreUno;
                    ViewBag.listaMaterias = MateriaDao.MateriasPorIdDocente(docente.IdDocente);
                    return View("Index", ViewBag);
                }
            }
            return Redirect("/Home/Docente");
        }
        public IActionResult Notas()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("docente"))
                {
                    var docente = DocenteDao.BuscarDocentePorCedula(HttpContext.Session.GetString("username"));
                    ViewBag.listaMaterias = MateriaDao.MateriasPorIdDocente(docente.IdDocente);
                    ViewBag.Nombre = docente.ApellidoUno + " " + docente.ApellidoDos + " " + docente.NombreUno;
                    return View(ViewBag);
                }
            }
            return Redirect("/Home/Docente");
        }

        // public IActionResult Tareas()
        // {
        //     return View();
        // }

        // public IActionResult Foros()
        // {
        //     return View();
        // }
    }
}