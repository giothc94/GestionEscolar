using System;
using System.Collections.Generic;

namespace GestionEscolar.Models
{
    public partial class Nota
    {
        public int IdNota { get; set; }
        public int IdTarea { get; set; }
        public int IdEstudiante { get; set; }
        public double? CalificacionNota { get; set; }
        public string UriAdjunto { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual Tarea IdTareaNavigation { get; set; }
    }
}
