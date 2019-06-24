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
            Materia materia; ;
            using (var context = new GestionEscolar())
            {
                materia = context.Materia.Where(m => m.NombreMateria == nombreMateria).FirstOrDefault();
            }
            return materia;
        }
        public static Materia MateriaPorId(int id)
        {
            Materia materia; ;
            using (var context = new GestionEscolar())
            {
                materia = context.Materia.Where(m => m.IdMateria == id).FirstOrDefault();
            }
            return materia;
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
        public static List<Materia> ListarMaterias()
        {
            List<Materia> materias;
            using (var context = new GestionEscolar())
                {
                    materias = context.Materia.Include(m => m.IdNivelNavigation).ToList();
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
    }
}