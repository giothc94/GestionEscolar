using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GestionEscolar.Models.DAO
{
    public static class EstudianteDao
    {
        public static bool IngresarEstudiante(Estudiante estudiante)
        {
            var v = false;
            try
            {
                using (var context = new GestionEscolar())
                {
                    context.Estudiante.Add(estudiante);
                    context.SaveChanges();
                };
                v = true;
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("-------------------------DEBUGGER INGRESO ESTUDIANTE-----------------------------------");
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
                Debug.WriteLine(e.InnerException);
                Debug.WriteLine("-------------------------DEBUGGER INGRESO ESTUDIANTE-----------------------------------");
                v = false;
            }
            return v;
        }

        public static List<Estudiante> ListarEstudiantes()
        {
            List<Estudiante> listaEstudiantes;
            using (var context = new GestionEscolar())
            {
                listaEstudiantes = context.Estudiante.ToList();
            }
            return listaEstudiantes;
        }
        public static Docente BuscarDocentePorCedula(string cedula)
        {
            Docente docente;
            using (var context = new GestionEscolar())
            {
                docente = context.Docente.Where(d => d.CedulaDocente == cedula).FirstOrDefault();
            }
            return docente;
        }
        public static bool ModificarDocente(Docente oldDocente, Docente newDocente)
        {
            var v = false;
            try
            {
                using (var context = new GestionEscolar())
                {
                    var result = context.Docente.Where(d => d.CedulaDocente == oldDocente.CedulaDocente).FirstOrDefault();
                    result.CedulaDocente = newDocente.CedulaDocente;
                    result.NombreUno = newDocente.NombreUno;
                    result.NombreDos = newDocente.NombreDos;
                    result.ApellidoUno = newDocente.ApellidoUno;
                    result.ApellidoDos = newDocente.ApellidoDos;
                    result.Titulo = newDocente.Titulo;
                    context.SaveChanges();
                }
                v = true;
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("**************-------------------------*****************");
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
                Debug.WriteLine(e.InnerException);
                Debug.WriteLine("**************-------------------------*****************");
                v = false;
            }
            return v;
        }
    }
}