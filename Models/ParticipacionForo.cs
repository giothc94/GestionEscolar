using System;
using System.Collections.Generic;

namespace GestionEscolar.Models
{
    public partial class ParticipacionForo
    {
        public int IdParticipacion { get; set; }
        public int IdEstudiante { get; set; }
        public DateTime HoraPublicado { get; set; }
        public int IdForo { get; set; }
        public string ContenidoParticipacion { get; set; }
        public double? NotaParticipacion { get; set; }

        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual Foro IdForoNavigation { get; set; }
    }
}
