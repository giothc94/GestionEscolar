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
            HttpContext.Session.Remove("rol");
            return View("Index");
        }
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("admin"))
                {
                    ViewData["listaCarreras"] = CarreraDao.ListaCarreraFull();
                    return View("Dashboard");
                }
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
                HttpContext.Session.SetString("rol", "admin");
                ViewBag.session = HttpContext.Session.GetString("username");
                ViewData["listaCarreras"] = CarreraDao.ListaCarreraFull();
                return View("Dashboard", ViewBag);
            }
            catch (System.Exception)
            {
                ViewBag.mensaje = "No se encontraron registros, Usuario no autorizado";
                return View(ViewBag);

            }
        }
        public IActionResult Dashboard()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("admin"))
                {
                    ViewData["listaCarreras"] = CarreraDao.ListaCarreraFull();
                    return View();
                }
            }
            return View("Index");
        }
        // public IActionResult Listas()
        // {
        //     if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
        //     {
        //         return View("Index");
        //     }
        //     return View();
        // }
        public IActionResult RegistrarDocente()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("admin"))
                {
                    List<Docente> listaDocentes = DocenteDao.ListarDocentes();
                    ViewData["listaDocentes"] = listaDocentes;
                    return View();
                }
            }
            return View("Index");

        }
        [HttpPost]
        public IActionResult RegistrarDocente(IFormCollection form)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("admin"))
                {
                    var cedulaDocente = form["cedulaDocente"];
                    var primerNombre = form["primerNombre"];
                    var segundoNombre = form["segundoNombre"];
                    var primerApellido = form["primerApellido"];
                    var segundoApellido = form["segundoApellido"];
                    var titulo = form["titulo"];

                    var docente = DocenteDao.BuscarDocentePorCedula(cedulaDocente);

                    if (docente != null)
                    {
                        var verif = DocenteDao.ModificarDocente(docente, new Docente()
                        {
                            CedulaDocente = cedulaDocente,
                            NombreUno = primerNombre,
                            NombreDos = segundoNombre,
                            ApellidoUno = primerApellido,
                            ApellidoDos = segundoApellido,
                            Titulo = titulo
                        });
                        ViewBag.mensaje = verif ? "Docente modificado exitosamente" : "No se modifico al docente";
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
                        ViewBag.mensaje = v ? "Docente registrado exitosamente" : "No se registro al docente";
                    }
                    List<Docente> listaDocentes = DocenteDao.ListarDocentes();
                    ViewData["listaDocentes"] = listaDocentes;
                    return View(ViewBag);
                }
            }
            return View("Index");
        }
        public IActionResult RegistrarEstudiante()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("admin"))
                {
                    var niveles = new List<Nivel>();
                    var estudiantesFull = new List<EstudianteFull>();
                    using (var context = new GestionEscolar.Models.GestionEscolar())
                    {
                        niveles = context.Nivel.Include(n => n.IdCarreraNavigation).ToList();
                    };
                    var l = EstudianteDao.ListarEstudiantes();
                    foreach (var estudiante in l)
                    {
                        estudiantesFull.Add(new EstudianteFull()
                        {
                            IdEstudiante = estudiante.IdEstudiante,
                            CedulaEstudiante = estudiante.CedulaEstudiante,
                            NombreUno = estudiante.NombreUno,
                            NombreDos = estudiante.NombreDos,
                            ApellidoUno = estudiante.ApellidoUno,
                            ApellidoDos = estudiante.ApellidoDos,
                            IdCarrera = estudiante.IdCarrera,
                            IdNivel = estudiante.IdNivel,
                            nivel = niveles.Find(n => n.IdNivel == estudiante.IdNivel)
                        });
                    }
                    ViewData["listaEstudiantes"] = estudiantesFull;
                    ViewData["listaCarreras"] = CarreraDao.ListarCarrera();
                    return View();
                }
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult RegistrarEstudiante(IFormCollection form)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("admin"))
                {
                    var cedula = form["cedula"];
                    var primerNombre = form["primerNombre"];
                    var segundoNombre = form["segundoNombre"];
                    var primerApellido = form["primerApellido"];
                    var segundoApellido = form["segundoApellido"];
                    var carrera = form["carrera"];
                    var nivel = form["nivel"];
                    try
                    {
                        var estudiante = EstudianteDao.BuscarEstudiantePorCedula(cedula);
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
                    var niveles = new List<Nivel>();
                    var estudiantesFull = new List<EstudianteFull>();
                    using (var context = new GestionEscolar.Models.GestionEscolar())
                    {
                        niveles = context.Nivel.Include(n => n.IdCarreraNavigation).ToList();
                    };
                    var l = EstudianteDao.ListarEstudiantes();
                    foreach (var estudiante in l)
                    {
                        estudiantesFull.Add(new EstudianteFull()
                        {
                            IdEstudiante = estudiante.IdEstudiante,
                            CedulaEstudiante = estudiante.CedulaEstudiante,
                            NombreUno = estudiante.NombreUno,
                            NombreDos = estudiante.NombreDos,
                            ApellidoUno = estudiante.ApellidoUno,
                            ApellidoDos = estudiante.ApellidoDos,
                            IdCarrera = estudiante.IdCarrera,
                            IdNivel = estudiante.IdNivel,
                            nivel = niveles.Find(n => n.IdNivel == estudiante.IdNivel)
                        });
                    }
                    ViewData["listaEstudiantes"] = estudiantesFull;
                    ViewData["listaCarreras"] = CarreraDao.ListarCarrera();
                    return View(ViewBag);

                }
            }
            return View("Index");
        }
        public IActionResult RegistrarCarrera()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("admin"))
                {
                    ViewData["listaDocentes"] = DocenteDao.ListarDocentes();
                    ViewData["listaCarreras"] = CarreraDao.ListaCarreraFull();
                    return View();
                }
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult RegistrarCarrera(IFormCollection form)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("admin"))
                {
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
                    ViewBag.mensaje = v ? "Carrera creada con exito" : "No se registro la carrera";
                    return View(ViewBag);

                }
            }
            return View("Index");
        }
        public IActionResult RegistrarMateria()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("admin"))
                {
                    ViewData["listaMaterias"] = MateriaDao.ListarMaterias();
                    ViewData["listaDocentes"] = DocenteDao.ListarDocentes();
                    ViewData["listaCarreras"] = CarreraDao.ListarCarrera();
                    return View();
                }
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult RegistrarMateria(IFormCollection form)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("username")) || !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("username")))
            {
                if (HttpContext.Session.GetString("rol").Equals("admin"))
                {
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
            return View("Index");
        }
    }
}