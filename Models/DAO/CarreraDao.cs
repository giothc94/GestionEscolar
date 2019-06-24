using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GestionEscolar.Models.DAO
{
    public static class CarreraDao
    {
        public static bool IngresarCarrera(Carrera carrera)
        {
            var v = false;
            try
            {
                using (var context = new GestionEscolar())
                {
                    context.Carrera.Add(carrera);
                    for (int i = 1; i <= 6; i++)
                    {
                        var n = new Nivel(){
                            Nivel1 = i,
                            IdCarrera = carrera.IdCarrera
                        };
                        context.Nivel.Add(n);
                    }
                    context.SaveChanges();
                };
                v = true;
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("-------------------------DEBUGGER INGRESO CARRERA-----------------------------------");
                Debug.WriteLine("DEBUGGER::MESSAGE:: "+e.Message);
                Debug.WriteLine("DEBUGGER::STACKTRACE:: "+e.StackTrace);
                Debug.WriteLine("DEBUGGER::INNEREXCEPTION:: "+e.InnerException);
                Debug.WriteLine("-------------------------DEBUGGER INGRESO CARRERA-----------------------------------");
                v = false;
            }
            return v;
        }

        public static List<Carrera> ListarCarrera()
        {
            List<Carrera> listaCarrera;
            using (var context = new GestionEscolar())
            {
                listaCarrera = context.Carrera.Include(c => c.Nivel).ToList();
            }
            return listaCarrera;
        }
        public static List<Nivel> ListaNivelYCarrera(int idCarrera)
        {
            List<Nivel> niveles;
            using (var context = new GestionEscolar())
            {
                niveles = context.Nivel.Where(nivel => nivel.IdCarrera == idCarrera).ToList();
            }
            return niveles;
        }
        
    }
}