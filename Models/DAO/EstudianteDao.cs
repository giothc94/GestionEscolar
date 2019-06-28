using System.Collections.Generic;
using System.Data.SqlClient;
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
                    var list = context.Materia.Where(m=>m.IdNivel == estudiante.IdNivel).ToList();
                    if(list.Any())
                    {
                        foreach (var item in list)
                        {
                            context.Reporte.Add(new Reporte(){
                                NotaDeberes = 0,
                                NotaForos = 0,
                                NotaPrueba = 0,
                                NotaProyecto = 0,
                                IdMateria = item.IdMateria,
                                IdEstudiante = estudiante.IdEstudiante
                            });
                        }
                        context.SaveChanges();
                    }
                    var user = new SqlParameter("usuario", estudiante.CedulaEstudiante);
                    var clave = new SqlParameter("clave", estudiante.CedulaEstudiante.Substring(0,4));
                    var idEstudiante = new SqlParameter("idEstudiante", estudiante.IdEstudiante);
                    var ud = context.UsuarioDocente.FromSql("EXEC AgregarUsuarioEstudiante @usuario, @clave, @idEstudiante",user,clave,idEstudiante).First();
                    v = true;
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
        public static List<Reporte> BuscarEstudiantesPorNivelDeMateria(int idMateria)
        {
            List<Reporte> reportes;
            using (var context = new GestionEscolar())
            {
                reportes = context.Reporte.Include(rp=>rp.IdEstudianteNavigation).Where(r=>r.IdMateria == idMateria).ToList();

            }
            return reportes;
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