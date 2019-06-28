using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEscolar.Controllers
{
    public class NotasController : Controller
    {
        public IActionResult Index(int idMateria)
        {
            using (var context = new GestionEscolar.Models.GestionEscolar())
            {
                ViewBag.lista = context.Reporte.Include(r=>r.IdEstudianteNavigation).Where(r=>r.IdMateria == idMateria).ToList();
                ViewBag.materia = context.Materia.Where(m=>m.IdMateria == idMateria).FirstOrDefault();
            }
            return View(ViewBag);
        }
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            var notaDeberes = Double.Parse(form["notaDeberes"].ToString().Replace(',','.'),System.Globalization.CultureInfo.InvariantCulture);
            var notaNotaForos = Double.Parse(form["notaNotaForos"].ToString().Replace(',','.'),System.Globalization.CultureInfo.InvariantCulture);
            var notaNotaPrueba = Double.Parse(form["notaNotaPrueba"].ToString().Replace(',','.'),System.Globalization.CultureInfo.InvariantCulture);
            var notaNotaProyecto = Double.Parse(form["notaNotaProyecto"].ToString().Replace(',','.'),System.Globalization.CultureInfo.InvariantCulture);
            var cedulaReporte = form["cedulaReporte"];
            var idReporte = form["idReporte"];

            using (var context = new GestionEscolar.Models.GestionEscolar())
            {
                var r = context.Reporte.Find(Convert.ToInt32(idReporte));
                if(r != null)
                {
                    r.NotaDeberes = notaDeberes;
                    r.NotaForos = notaNotaForos;
                    r.NotaProyecto = notaNotaProyecto;
                    r.NotaPrueba = notaNotaPrueba;
                }
                ViewBag.lista = context.Reporte.Include(re=>re.IdEstudianteNavigation).Where(re=>re.IdMateria == r.IdMateria).ToList();
                ViewBag.materia = context.Materia.Where(m=>m.IdMateria == r.IdMateria).FirstOrDefault();
                context.SaveChanges();
            }
            return View(ViewBag);
        }
    }
}