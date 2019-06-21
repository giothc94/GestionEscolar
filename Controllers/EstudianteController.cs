using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.Controllers
{
    public class EstudianteController : Controller
    {
        public IActionResult Index()
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
        [Route("Estudiante/ParticipacionForos/")]
        [Route("Estudiante/ParticipacionForos/{idForo}")]
        public IActionResult ParticipacionForos(string idForo)
        {
            if(string.IsNullOrEmpty(idForo) || string.IsNullOrWhiteSpace(idForo))
            {
                return View("Foros");
            }
            else
            {
                Debug.WriteLine("PARAMETRO: "+idForo);
                return View("Index");
            }
        }
    }
}