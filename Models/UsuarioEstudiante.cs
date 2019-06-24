using System;
using System.Collections.Generic;

namespace GestionEscolar.Models
{
    public partial class UsuarioEstudiante
    {
        public int IdUsuarioEstudiante { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int IdEstudiante { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
    }
}
