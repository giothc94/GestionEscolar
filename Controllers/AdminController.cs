using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionEscolar.Models;
using GestionEscolar.Models.DAO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace GestionEscolar.Controllers
{
    public class AdminController : Controller
    {
        private GestionEscolar.Models.GestionEscolar context = new GestionEscolar.Models.GestionEscolar();
        
        public IActionResult CerrarSession()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("id");
            return View("Index");
        }
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                return View("Dashboard");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            var user = new SqlParameter("user", form["user"].ToString());
            var clave = new SqlParameter("clave", form["password"].ToString());
            try
            {
                var result = context.Administradores.FromSql("EXEC VerificarAdministrador @user,@clave", user, clave).First();

                HttpContext.Session.SetString("username", result.Usuario);
                HttpContext.Session.SetString("id", result.Id.ToString());
                Debug.WriteLine("**************-------------------------*****************");
                Debug.WriteLine(result.Usuario);
                Debug.WriteLine(result.Clave);
                Debug.WriteLine(result.Id);
                Debug.WriteLine("**************-------------------------*****************");
                ViewBag.session = HttpContext.Session.GetString("username");
                return View("Dashboard",ViewBag);
            }
            catch (System.Exception)
            {
                ViewBag.mensaje = "No se encontraron registros, Usuario no autorizado";
                Debug.WriteLine("**************-------------------------*****************");
                Debug.WriteLine("No se encontraron registros");
                Debug.WriteLine("**************-------------------------*****************");
                return View(ViewBag);

            }
        }
        public IActionResult Dashboard()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                return View("Index");
            }
            return View();
        }
        public IActionResult Listas()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                return View("Index");
            }
            return View();
        }
        public IActionResult RegistrarDocente()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                return View("Index");
            }
            List<Docente> listaDocentes = DocenteDao.ListarDocentes();
            ViewData["listaDocentes"] = listaDocentes;
            return View();

        }
        [HttpPost]
        public IActionResult RegistrarDocente(IFormCollection form)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                return View("Index");
            }
            var cedulaDocente = form["cedulaDocente"];
            var primerNombre = form["primerNombre"];
            var segundoNombre = form["segundoNombre"];
            var primerApellido = form["primerApellido"];
            var segundoApellido = form["segundoApellido"];
            var titulo = form["titulo"];

            var docente = DocenteDao.BuscarDocentePorCedula(cedulaDocente);

            if (docente != null)
            {
                var v = DocenteDao.ModificarDocente(docente, new Docente()
                {
                    CedulaDocente = cedulaDocente,
                    NombreUno = primerNombre,
                    NombreDos = segundoNombre,
                    ApellidoUno = primerApellido,
                    ApellidoDos = segundoApellido,
                    Titulo = titulo
                });
                if (v)
                {
                    ViewBag.mensaje = "Docente modificado exitosamente";
                }
                else
                {
                    ViewBag.mensaje = "No se modifico al docente";
                }
            }
            else
            {
                var v = DocenteDao.IngresarDocente(new Docente()
                {
                    CedulaDocente = cedulaDocente,
                    NombreUno = primerNombre,
                    NombreDos = segundoNombre,
                    ApellidoUno = primerApellido,
                    ApellidoDos = segundoApellido,
                    Titulo = titulo
                });
                if (v)
                {
                    ViewBag.mensaje = "Docente registrado exitosamente";
                }
                else
                {
                    ViewBag.mensaje = "No se registro al docente";
                }
            }
            List<Docente> listaDocentes = DocenteDao.ListarDocentes();
            ViewData["listaDocentes"] = listaDocentes;

            return View(ViewBag);
        }
        public IActionResult RegistrarEstudiante()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                return View("Index");
            }
            ViewData["listaEstudiantes"] = EstudianteDao.ListarEstudiantes();
            ViewData["listaCarreras"] = CarreraDao.ListarCarrera();
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarEstudiante(IFormCollection form)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                return View("Index");
            }
            var cedula = form["cedula"];
            var primerNombre = form["primerNombre"];
            var segundoNombre = form["segundoNombre"];
            var primerApellido = form["primerApellido"];
            var segundoApellido = form["segundoApellido"];
            var carrera = form["carrera"];
            var nivel = form["nivel"];

            var estudiante = EstudianteDao.BuscarEstudiantePorCedula(cedula);
            try
            {
                if (estudiante == null)
                {
                    var v = EstudianteDao.IngresarEstudiante(new Estudiante()
                    {
                        CedulaEstudiante = cedula,
                        NombreUno = primerNombre,
                        NombreDos = segundoNombre,
                        ApellidoUno = primerApellido,
                        ApellidoDos = segundoApellido,
                        IdCarrera = Convert.ToInt32(carrera),
                        IdNivel = Convert.ToInt32(nivel)
                    });
                    ViewBag.mensaje = "Estudiante registrado con exito";
                }
                else
                {
                    var v = EstudianteDao.ModificarEstudiante(estudiante, new Estudiante()
                    {
                        CedulaEstudiante = cedula,
                        NombreUno = primerNombre,
                        NombreDos = segundoNombre,
                        ApellidoUno = primerApellido,
                        ApellidoDos = segundoApellido,
                        IdCarrera = Convert.ToInt32(carrera),
                        IdNivel = Convert.ToInt32(nivel)
                    });
                    ViewBag.mensaje = "Estudiante Modificado con exito";
                }

            }
            catch (System.Exception)
            {
                ViewBag.mensaje = "No pudimos registrar al estudiante";
            }
            ViewData["listaEstudiantes"] = EstudianteDao.ListarEstudiantes();
            ViewData["listaCarreras"] = CarreraDao.ListarCarrera();
            return View(ViewBag);
        }
        public IActionResult RegistrarCarrera()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                return View("Index");
            }
            ViewData["listaDocentes"] = DocenteDao.ListarDocentes();
            ViewData["listaCarreras"] = CarreraDao.ListaCarreraFull();
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarCarrera(IFormCollection form)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                return View("Index");
            }
            ViewData["listaDocentes"] = DocenteDao.ListarDocentes();
            var nombreCarrera = form["nombreCarrera"];
            var descripcionCarrera = form["descripcionCarrera"];
            var idDocente = form["idDocente"];

            var v = CarreraDao.IngresarCarrera(new Carrera()
            {
                NombreCarrera = nombreCarrera,
                DescripcionCarrera = descripcionCarrera,
                DirectorCarrera = Convert.ToInt32(idDocente)
            });

            if (v)
            {
                ViewBag.mensaje = "Carrera creada con exito";
            }
            else
            {
                ViewBag.mensaje = "No se registro la carrera";
            }


            return View(ViewBag);
        }
        public IActionResult RegistrarMateria()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                return View("Index");
            }
            ViewData["listaMaterias"] = MateriaDao.ListarMaterias();
            ViewData["listaDocentes"] = DocenteDao.ListarDocentes();
            ViewData["listaCarreras"] = CarreraDao.ListarCarrera();
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarMateria(IFormCollection form)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                return View("Index");
            }
            var materiaNombre = form["materiaNombre"];
            var carrera = form["carrera"];
            var nivel = form["nivel"];
            var docente = form["docente"];
            var m = new Materia()
            {
                NombreMateria = materiaNombre,
                IdNivel = Convert.ToInt32(nivel),
                IdDocente = Convert.ToInt32(docente)
            };
            var mt = MateriaDao.MateriaPorNombre(m.NombreMateria);
            var verif = false;
            if (mt == null)
            {
                verif = MateriaDao.RegistrarMateria(m);
                ViewBag.mensaje = "Materia registrada exitosamente";
            }
            else
            {
                verif = MateriaDao.ModificarMateria(mt, m);
                ViewBag.mensaje = "Materia MODIFICADA exitosamente";
            }
            if (!verif)
            {
                ViewBag.mensaje = "NO SE REGISTRO LA MATERIA*";
            }
            ViewData["listaDocentes"] = DocenteDao.ListarDocentes();
            ViewData["listaCarreras"] = CarreraDao.ListarCarrera();
            ViewData["listaMaterias"] = MateriaDao.ListarMaterias();
            return View(ViewBag);
        }
    }
}