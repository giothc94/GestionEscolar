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
                        var n = new Nivel()
                        {
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
                Debug.WriteLine("DEBUGGER::MESSAGE:: " + e.Message);
                Debug.WriteLine("DEBUGGER::STACKTRACE:: " + e.StackTrace);
                Debug.WriteLine("DEBUGGER::INNEREXCEPTION:: " + e.InnerException);
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

        public static List<CarreraFull> ListaCarreraFull()
        {
            var lista = new List<Carrera>();
            var niveles = new List<Nivel>();
            var carreras = new List<CarreraFull>();
            using (var context = new GestionEscolar())
            {
                lista = context.Carrera.ToList();
                
                foreach (var carrera in lista)
                {
                    CarreraFull cf = new CarreraFull()
                    {
                        IdCarrera = carrera.IdCarrera,
                        NombreCarrera = carrera.NombreCarrera,
                        DescripcionCarrera = carrera.DescripcionCarrera,
                        DirectorCarrera = carrera.DirectorCarrera,
                        Docente = context.Docente.Find(carrera.DirectorCarrera),
                        Niveles = context.Nivel.Include(n=>n.Materia).Where(n=>n.IdCarrera == carrera.IdCarrera).ToList()
                    };
                    carreras.Add(cf);
                }
                    foreach (var c in carreras)
                    {
                        foreach(var nivel in c.Niveles)
                        {
                            foreach (var m in nivel.Materia)
                            {
                                m.IdDocenteNavigation = context.Docente.Find(m.IdDocente);
                            }
                        }
                    }
            }
            return carreras;
        }
    }
}