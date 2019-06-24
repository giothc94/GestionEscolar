using System;
using System.Collections.Generic;

namespace GestionEscolar.Models
{
    public partial class Tarea
    {
        public Tarea()
        {
            Nota = new HashSet<Nota>();
        }

        public int IdTarea { get; set; }
        public int IdMateria { get; set; }
        public string TituloTarea { get; set; }
        public string DescripcionTarea { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
        public string UriAdjunto { get; set; }
        public int Estado { get; set; }

        public virtual Materia IdMateriaNavigation { get; set; }
        public virtual ICollection<Nota> Nota { get; set; }
    }
}
