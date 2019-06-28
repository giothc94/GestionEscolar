using System.Collections.Generic;

namespace GestionEscolar.Models
{
    public class CarreraFull
    {
        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }
        public string DescripcionCarrera { get; set; }
        public int DirectorCarrera { get; set; }
        public Docente Docente { get; set; }
        public List<Nivel> Niveles {get;set;}
    }
}