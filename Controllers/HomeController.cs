using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestionEscolar.Models;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionEscolar.Controllers
{
    public class HomeController : Controller
    {
        private GestionEscolar.Models.GestionEscolar context = new GestionEscolar.Models.GestionEscolar();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Docente()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("docente")){
                    return Redirect("/Docente/Index");
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Docente(IFormCollection form)
        {
            try
            {
                var user = new SqlParameter("user", form["user"].ToString());
                var clave = new SqlParameter("clave", form["password"].ToString());
                var result = context.UsuarioDocente.FromSql("EXEC VerificarUsuarioDocente @user,@clave", user, clave).First();
                HttpContext.Session.SetString("username", result.Usuaio);
                HttpContext.Session.SetString("rol", "docente");
                return Redirect("/Docente/Index");
            }
            catch (System.Exception)
            {
                ViewBag.mensaje = "No se encontraron registros, Usuario no autorizado";
                return View(ViewBag);
            }
        }
        public IActionResult Estudiante()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("estudiante"))
                {
                    return Redirect("/Estudiante/Index");
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Estudiante(IFormCollection form)
        {
            try
            {
                var user = new SqlParameter("user", form["user"].ToString());
                var clave = new SqlParameter("clave", form["password"].ToString());
                var result = context.UsuarioEstudiante.FromSql("EXEC VerificarUsuarioEstudiante @user, @clave", user, clave).First();

                HttpContext.Session.SetString("username", result.Usuario);
                HttpContext.Session.SetString("rol", "estudiante");
                return Redirect("/Estudiante/Index");
            }
            catch (System.Exception)
            {
                ViewBag.mensaje = "No se encontraron registros, Usuario no autorizado";
                return View(ViewBag);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult CerrarSession()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("rol");
            return Redirect("/Home/Index");
        }
    }
}
