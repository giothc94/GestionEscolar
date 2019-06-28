namespace GestionEscolar.Models
{
    public class EstudianteFull
    {
        public int IdEstudiante { get; set; }
        public string CedulaEstudiante { get; set; }
        public string NombreUno { get; set; }
        public string NombreDos { get; set; }
        public string ApellidoUno { get; set; }
        public string ApellidoDos { get; set; }
        public int IdCarrera { get; set; }
        public int IdNivel { get; set; }
        public Nivel nivel { get; set; }
    }
}