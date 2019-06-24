using System;
using System.Collections.Generic;

namespace GestionEscolar.Models
{
    public partial class UsuarioDocente
    {
        public int IdUsuarioDocente { get; set; }
        public string Usuaio { get; set; }
        public string Clave { get; set; }
        public int IdDocente { get; set; }

        public virtual Docente IdDocenteNavigation { get; set; }
    }
}
