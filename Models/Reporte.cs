using System;
using System.Collections.Generic;

namespace GestionEscolar.Models
{
    public partial class Reporte
    {
        public int IdReporte { get; set; }
        public double? NotaDeberes { get; set; }
        public double? NotaForos { get; set; }
        public double? NotaPrueba { get; set; }
        public double? NotaProyecto { get; set; }
        public int IdMateria { get; set; }
        public int IdEstudiante { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual Materia IdMateriaNavigation { get; set; }
    }
}
