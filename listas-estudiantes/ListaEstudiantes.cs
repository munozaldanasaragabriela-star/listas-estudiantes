using System;

namespace SistemaEstudiantes
{
    public class ListaEstudiantes
    {
        private NodoEstudiante cabeza;
        private int contador;

        public ListaEstudiantes()
        {
            cabeza = null;
            contador = 0;
        }

        public void Agregar(Estudiante estudiante)
        {
            NodoEstudiante nuevoNodo = new NodoEstudiante(estudiante);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                NodoEstudiante actual = cabeza;
                while (actual.Siguiente != null) actual = actual.Siguiente;
                actual.Siguiente = nuevoNodo;
            }
            contador++;
        }

        public Estudiante BuscarPorCodigo(string codigo)
        {
            NodoEstudiante actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.Codigo == codigo) return actual.Dato;
                actual = actual.Siguiente;
            }
            return null;
        }

        public bool Eliminar(string codigo)
        {
            if (cabeza == null) return false;
            if (cabeza.Dato.Codigo == codigo)
            {
                cabeza = cabeza.Siguiente;
                contador--;
                return true;
            }
            NodoEstudiante actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato.Codigo == codigo)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    contador--;
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        public void Listar()
        {
            if (cabeza == null) { Console.WriteLine("No hay estudiantes registrados."); return; }
            NodoEstudiante actual = cabeza;
            int num = 1;
            while (actual != null)
            {
                Console.WriteLine($"\n--- Estudiante {num} ---");
                Console.WriteLine(actual.Dato);
                actual = actual.Siguiente;
                num++;
            }
        }

        public int ObtenerCantidad() => contador;
        public bool EstaVacia() => cabeza == null;
    }
}