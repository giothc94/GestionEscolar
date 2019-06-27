using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GestionEscolar.Models.DAO
{
    public static class MateriaDao
    {
        public static Materia MateriaPorNombre(string nombreMateria)
        {
            Materia materia;
             using (var context = new GestionEscolar())
             {
                materia = context.Materia.Where(m => m.NombreMateria == nombreMateria).FirstOrDefault();
                return materia;
             }
        }
        public static Materia MateriaPorId(int id)
        {
            Materia materia;
            try
            {
                 using (var context = new GestionEscolar())
                 {
                    materia = context.Materia.Where(m => m.IdMateria == id).First();
                    return materia;
                 }
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("*----------*-*--------------------------");
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.InnerException);
                Debug.WriteLine("*----------*-*--------------------------");
                return null;
            }
        }
        public static bool RegistrarMateria(Materia materia)
        {
            var v = false;
            try
            {
                using (var context = new GestionEscolar())
                {
                    context.Materia.Add(materia);
                    context.SaveChanges();
                }
                v = true;
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("-------------------------DEBUGGER INGRESO CARRERA-----------------------------------");
                Debug.WriteLine("DEBUGGER::MESSAGE:: " + e.Message);
                Debug.WriteLine("DEBUGGER::STACKTRACE:: " + e.StackTrace);
                Debug.WriteLine("DEBUGGER::INNEREXCEPTION:: " + e.InnerException);
                Debug.WriteLine("-------------------------DEBUGGER INGRESO CARRERA-----------------------------------");
                v = false;
            }
            return v;
        }
        public static bool ModificarMateria(Materia oldMateria,Materia newMateria)
        {
            var v = false;
            try
            {
                using (var context = new GestionEscolar())
                {
                    var result = context.Materia.Where(m => m.IdMateria == oldMateria.IdMateria).FirstOrDefault();
                    result.NombreMateria = newMateria.NombreMateria;
                    result.IdNivel = newMateria.IdNivel;
                    result.IdDocente = newMateria.IdDocente;
                    context.SaveChanges();
                }
                v = true;
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("-------------------------DEBUGGER INGRESO CARRERA-----------------------------------");
                Debug.WriteLine("DEBUGGER::MESSAGE:: " + e.Message);
                Debug.WriteLine("DEBUGGER::STACKTRACE:: " + e.StackTrace);
                Debug.WriteLine("DEBUGGER::INNEREXCEPTION:: " + e.InnerException);
                Debug.WriteLine("-------------------------DEBUGGER INGRESO CARRERA-----------------------------------");
                v = false;
            }
            return v;
        }
        public static List<Materia> ListarMaterias()
        {
            List<Materia> materias;
            using (var context = new GestionEscolar())
                {
                    materias = context.Materia
                        .Include(m => m.IdNivelNavigation.IdCarreraNavigation)
                        .Include(n => n.IdDocenteNavigation)
                        .OrderByDescending(mi => mi.IdMateria)
                        .ToList();
                }
            return materias;
        }

        public static List<Materia> MateriasPorIdDocente(int idDocente)
        {
            List<Materia> materias;
            using (var context = new GestionEscolar())
                {
                    materias = context.Materia.Include(m => m.IdNivelNavigation).Where(m=>m.IdDocente == idDocente).ToList();
                }
            return materias;
        }
        public static Nivel NivelPorId(int id)
        {
            Nivel nivel;
            try
            {
                 using (var context = new GestionEscolar())
                 {
                    nivel = context.Nivel.Where(m => m.IdNivel == id).First();
                    return nivel;
                 }
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("*----------*-*--------------------------");
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.InnerException);
                Debug.WriteLine("*----------*-*--------------------------");
                return null;
            }
        }
    }
}