// Nodo de la lista enlazada de materias
namespace SistemaEstudiantes
{
    public class NodoMateria
    {
        public Materia Dato { get; set; }
        public NodoMateria Siguiente { get; set; }

        public NodoMateria(Materia dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}