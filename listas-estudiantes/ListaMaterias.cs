using System;

namespace SistemaEstudiantes
{
    public class ListaMaterias
    {
        private NodoMateria cabeza;
        private int contador;

        public ListaMaterias()
        {
            cabeza = null;
            contador = 0;
        }

        public bool Agregar(Materia materia)
        {
            if (ExisteMateria(materia.Nombre)) return false;
            NodoMateria nuevoNodo = new NodoMateria(materia);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                NodoMateria actual = cabeza;
                while (actual.Siguiente != null) actual = actual.Siguiente;
                actual.Siguiente = nuevoNodo;
            }
            contador++;
            return true;
        }

        private bool ExisteMateria(string nombre)
        {
            NodoMateria actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)) return true;
                actual = actual.Siguiente;
            }
            return false;
        }

        public Materia BuscarPorNombre(string nombre)
        {
            NodoMateria actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)) return actual.Dato;
                actual = actual.Siguiente;
            }
            return null;
        }

        public bool ModificarNota(string nombre, double nuevaNota)
        {
            Materia m = BuscarPorNombre(nombre);
            if (m != null) { m.Nota = nuevaNota; return true; }
            return false;
        }

        public bool Eliminar(string nombre)
        {
            if (cabeza == null) return false;
            if (cabeza.Dato.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                cabeza = cabeza.Siguiente;
                contador--;
                return true;
            }
            NodoMateria actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
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
            if (cabeza == null) { Console.WriteLine("No hay materias registradas."); return; }
            NodoMateria actual = cabeza;
            int num = 1;
            while (actual != null)
            {
                Console.WriteLine($"{num}. {actual.Dato}");
                actual = actual.Siguiente;
                num++;
            }
        }

        public int ObtenerCantidad() => contador;
        public bool EstaVacia() => cabeza == null;

        public double CalcularPromedio()
        {
            if (cabeza == null) return 0;
            double suma = 0;
            int cantidad = 0;
            NodoMateria actual = cabeza;
            while (actual != null)
            {
                suma += actual.Dato.Nota;
                cantidad++;
                actual = actual.Siguiente;
            }
            return cantidad > 0 ? suma / cantidad : 0;
        }
    }
}