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
        public IActionResult Index()
        {
            using (var context = new GestionEscolar.Models.GestionEscolar())
            {
                var user = new SqlParameter("user", "Admin");
                var clave = new SqlParameter("clave", "Admin122");
                var result = context.Administradores.FromSql("EXEC VerificarAdministrador @user,@clave", user, clave).ToList();
                if (result.Any())
                {
                    foreach (var r in result)
                    {
                        Debug.WriteLine("**************-------------------------*****************");
                        Debug.WriteLine(r.Usuario);
                        Debug.WriteLine(r.Clave);
                        Debug.WriteLine(r.Id);
                        Debug.WriteLine("**************-------------------------*****************");
                    }
                }
                else
                {
                    Debug.WriteLine("**************-------------------------*****************");
                    Debug.WriteLine("No se encontraron registros");
                    Debug.WriteLine("**************-------------------------*****************");
                }
            }
            return View("Dashboard");
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Listas()
        {
            return View();
        }
        public IActionResult RegistrarDocente()
        {
            List<Docente> listaDocentes = DocenteDao.ListarDocentes();
            ViewData["listaDocentes"] = listaDocentes;
            return View();

        }
        [HttpPost]
        public IActionResult RegistrarDocente(IFormCollection form)
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
            ViewData["listaEstudiantes"] = EstudianteDao.ListarEstudiantes();
            ViewData["listaCarreras"] = CarreraDao.ListarCarrera();
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarEstudiante(IFormCollection form)
        {
            var cedula = form["cedula"];
            var primerNombre = form["primerNombre"];
            var segundoNombre = form["segundoNombre"];
            var primerApellido = form["primerApellido"];
            var segundoApellido = form["segundoApellido"];
            var carrera = form["carrera"];
            var nivel = form["nivel"];
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
            if (v)
            {
                ViewBag.mensaje = "Estudiante registrado con exito";
            }
            else
            {
                ViewBag.mensaje = "No pudimos registrar al estudiante";
            }
            ViewData["listaEstudiantes"] = EstudianteDao.ListarEstudiantes();
            ViewData["listaCarreras"] = CarreraDao.ListarCarrera();
            return View(ViewBag);
        }
        public IActionResult RegistrarCarrera()
        {
            ViewData["listaDocentes"] = DocenteDao.ListarDocentes();
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarCarrera(IFormCollection form)
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
            ViewData["listaMaterias"] = MateriaDao.ListarMaterias();
            ViewData["listaDocentes"] = DocenteDao.ListarDocentes();
            ViewData["listaCarreras"] = CarreraDao.ListarCarrera();
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarMateria(IFormCollection form)
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
            if(mt == null)
            {
                verif = MateriaDao.RegistrarMateria(m);
                ViewBag.mensaje = "Materia registrada exitosamente";
            }
            else
            {
                verif = MateriaDao.ModificarMateria(mt,m);
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