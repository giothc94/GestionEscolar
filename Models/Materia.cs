using System;
using System.Collections.Generic;

namespace GestionEscolar.Models
{
    public partial class Materia
    {
        public Materia()
        {
            Foro = new HashSet<Foro>();
            Reporte = new HashSet<Reporte>();
            Tarea = new HashSet<Tarea>();
        }

        public int IdMateria { get; set; }
        public string NombreMateria { get; set; }
        public int IdNivel { get; set; }
        public int? IdDocente { get; set; }

        public virtual Docente IdDocenteNavigation { get; set; }
        public virtual Nivel IdNivelNavigation { get; set; }
        public virtual ICollection<Foro> Foro { get; set; }
        public virtual ICollection<Reporte> Reporte { get; set; }
        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
