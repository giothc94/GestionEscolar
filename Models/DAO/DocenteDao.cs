using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GestionEscolar.Models.DAO
{
    public static class DocenteDao
    {
        public static bool IngresarDocente(Docente docente)
        {
            var v = false;
            try
            {
                using (var context = new GestionEscolar())
                {
                    context.Docente.Add(docente);
                    var UD = new UsuarioDocente()
                    {
                        Usuaio = docente.CedulaDocente,
                        Clave = docente.CedulaDocente.Substring(0, 4),
                        IdDocente = docente.IdDocente
                    };
                    context.UsuarioDocente.Add(UD);
                    context.SaveChanges();
                };
                v = true;
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("-------------------------DEBUGGER INGRESO DOCENTE-----------------------------------");
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
                Debug.WriteLine(e.InnerException);
                Debug.WriteLine("-------------------------DEBUGGER INGRESO DOCENTE-----------------------------------");
                v = false;
            }
            return v;
        }

        public static List<Docente> ListarDocentes()
        {
            List<Docente> listaDocentes;
            using (var context = new GestionEscolar())
            {
                listaDocentes = context.Docente.OrderByDescending(d => d).ToList();
            }
            return listaDocentes;
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
        public static Docente BuscarDocentePorId(int id)
        {
            Docente docente;
            using (var context = new GestionEscolar())
            {
                docente = context.Docente.Where(d => d.IdDocente == id).FirstOrDefault();
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