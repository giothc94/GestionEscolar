using System;
using System.Collections.Generic;

namespace GestionEscolar.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Nivel = new HashSet<Nivel>();
        }

        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }
        public string DescripcionCarrera { get; set; }
        public int DirectorCarrera { get; set; }

        public virtual ICollection<Nivel> Nivel { get; set; }
    }
}
