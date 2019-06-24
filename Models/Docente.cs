using System;
using System.Collections.Generic;

namespace GestionEscolar.Models
{
    public partial class Docente
    {
        public Docente()
        {
            Materia = new HashSet<Materia>();
            UsuarioDocente = new HashSet<UsuarioDocente>();
        }

        public int IdDocente { get; set; }
        public string CedulaDocente { get; set; }
        public string NombreUno { get; set; }
        public string NombreDos { get; set; }
        public string ApellidoUno { get; set; }
        public string ApellidoDos { get; set; }
        public string Titulo { get; set; }

        public virtual ICollection<Materia> Materia { get; set; }
        public virtual ICollection<UsuarioDocente> UsuarioDocente { get; set; }
    }
}
