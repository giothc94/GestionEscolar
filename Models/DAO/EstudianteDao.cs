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
                listaEstudiantes = context.Estudiante.OrderByDescending(d => d).ToList();
            }
            return listaEstudiantes;
        }
        public static Estudiante BuscarEstudiantePorCedula(string cedula)
        {
            Estudiante estudiante;
            using (var context = new GestionEscolar())
            {
                estudiante = context.Estudiante.Where(e => e.CedulaEstudiante == cedula).FirstOrDefault();
            }
            return estudiante;
        }
        public static bool ModificarEstudiante(Estudiante oldEstudiante, Estudiante newEstudiante)
        {
            var v = false;
            try
            {
                using (var context = new GestionEscolar())
                {
                    var result = context.Estudiante.Where(d => d.CedulaEstudiante == oldEstudiante.CedulaEstudiante).FirstOrDefault();
                    result.CedulaEstudiante = newEstudiante.CedulaEstudiante;
                    result.NombreUno = newEstudiante.NombreUno;
                    result.NombreDos = newEstudiante.NombreDos;
                    result.ApellidoUno = newEstudiante.ApellidoUno;
                    result.ApellidoDos = newEstudiante.ApellidoDos;
                    result.IdCarrera = newEstudiante.IdCarrera;
                    result.IdNivel = newEstudiante.IdNivel;
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