using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEscolar.Controllers
{
    public class EstudianteController : Controller
    {
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("estudiante"))
                {
                    using (var context = new GestionEscolar.Models.GestionEscolar())
                    {
                        var estudiante = context.Estudiante.Where(e=>e.CedulaEstudiante == HttpContext.Session.GetString("username")).FirstOrDefault();
                        var reporte = context.Reporte
                                        .Include(r => r.IdMateriaNavigation)
                                        .Include(r => r.IdEstudianteNavigation)
                                        .Where(r=>r.IdEstudianteNavigation.CedulaEstudiante == estudiante.CedulaEstudiante)
                                        .ToList();
                        ViewBag.reporte = reporte;
                        ViewBag.estudiante = estudiante;
                        ViewData["nameUser"] = estudiante.ApellidoUno + " " + estudiante.NombreUno;
                        ViewData["ciUser"] = estudiante.CedulaEstudiante;
                        return View(ViewBag);
                    }
                }
            }
            return Redirect("/Home/Estudiante");
        }
        // public IActionResult Tareas()
        // {
        //     return View();
        // }
        // public IActionResult Foros()
        // {
        //     return View();
        // }
        // [Route("Estudiante/ParticipacionForos/")]
        // [Route("Estudiante/ParticipacionForos/{idForo}")]
        // public IActionResult ParticipacionForos(string idForo)
        // {
        //     if(string.IsNullOrEmpty(idForo) || string.IsNullOrWhiteSpace(idForo))
        //     {
        //         return View("Foros");
        //     }
        //     else
        //     {
        //         Debug.WriteLine("PARAMETRO: "+idForo);
        //         return View("Index");
        //     }
        // }
    }
}