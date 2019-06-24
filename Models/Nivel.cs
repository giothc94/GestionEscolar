using System;
using System.Collections.Generic;

namespace GestionEscolar.Models
{
    public partial class Nivel
    {
        public Nivel()
        {
            Materia = new HashSet<Materia>();
        }

        public int IdNivel { get; set; }
        public int Nivel1 { get; set; }
        public int IdCarrera { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; }
        public virtual ICollection<Materia> Materia { get; set; }
    }
}
