namespace SistemaEstudiantes
{
    public class NodoEstudiante
    {
        public Estudiante Dato { get; set; }
        public NodoEstudiante Siguiente { get; set; }
        public NodoEstudiante(Estudiante dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}