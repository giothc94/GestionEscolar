using System;
using System.Collections.Generic;

namespace GestionEscolar.Models
{
    public partial class Foro
    {
        public Foro()
        {
            ParticipacionForo = new HashSet<ParticipacionForo>();
        }

        public int IdForo { get; set; }
        public int IdMateria { get; set; }
        public string TemaForo { get; set; }
        public string DescripcionForo { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }

        public virtual Materia IdMateriaNavigation { get; set; }
        public virtual ICollection<ParticipacionForo> ParticipacionForo { get; set; }
    }
}
