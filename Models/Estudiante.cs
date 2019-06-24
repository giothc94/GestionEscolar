using System;
using System.Collections.Generic;

namespace GestionEscolar.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Nota = new HashSet<Nota>();
            ParticipacionForo = new HashSet<ParticipacionForo>();
            Reporte = new HashSet<Reporte>();
            UsuarioEstudiante = new HashSet<UsuarioEstudiante>();
        }

        public int IdEstudiante { get; set; }
        public string CedulaEstudiante { get; set; }
        public string NombreUno { get; set; }
        public string NombreDos { get; set; }
        public string ApellidoUno { get; set; }
        public string ApellidoDos { get; set; }
        public int IdCarrera { get; set; }
        public int IdNivel { get; set; }

        public virtual ICollection<Nota> Nota { get; set; }
        public virtual ICollection<ParticipacionForo> ParticipacionForo { get; set; }
        public virtual ICollection<Reporte> Reporte { get; set; }
        public virtual ICollection<UsuarioEstudiante> UsuarioEstudiante { get; set; }
    }
}
