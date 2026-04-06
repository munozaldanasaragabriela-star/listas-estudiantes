using System;

namespace SistemaEstudiantes
{
    class Program
    {
        static ListaEstudiantes listaEstudiantes = new ListaEstudiantes();
        static int codigoAutoinc = 1;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool salir = false;

            while (!salir)
            {
                MostrarMenuPrincipal();
                int opcion = LeerEntero("Seleccione una opción: ");
                Console.WriteLine();

                switch (opcion)
                {
                    case 1: AgregarEstudiante(); break;
                    case 2: ListarEstudiantes(); break;
                    case 3: BuscarEstudiante(); break;
                    case 4: EliminarEstudiante(); break;
                    case 5: GestionarMaterias(); break;
                    case 6: salir = true; break;
                    default: MostrarError("Opción no válida."); break;
                }

                if (!salir)
                {
                     Console.WriteLine("\nPresione cualquier tecla para continuar...");
                     Console.ReadKey();
                     Console.Clear();
                }
            }
        }

        static void MostrarMenuPrincipal()
        {
            Console.WriteLine("SISTEMA DE GESTIÓN DE ESTUDIANTES");
            Console.WriteLine("\n1. Agregar estudiante");
            Console.WriteLine("2. Listar estudiantes");
            Console.WriteLine("3. Buscar estudiante");
            Console.WriteLine("4. Eliminar estudiante");
            Console.WriteLine("5. Gestionar materias de un estudiante");
            Console.WriteLine("6. Salir\n");
        }

        static void AgregarEstudiante()
        {
            Console.WriteLine("--- AGREGAR NUEVO ESTUDIANTE ---\n");
            string codigo = "EST" + codigoAutoinc.ToString("D4");
            codigoAutoinc++;
            Console.WriteLine($"Código asignado: {codigo}");
            string nombre = LeerTextoNoVacio("Nombre: ");
            string apellido = LeerTextoNoVacio("Apellido: ");
            string direccion = LeerTextoNoVacio("Dirección: ");
            string celular = LeerTextoNoVacio("Celular: ");
            string email = LeerTextoNoVacio("Email: ");
            listaEstudiantes.Agregar(new Estudiante(codigo, nombre, apellido, direccion, celular, email));
            MostrarExito($"Estudiante {nombre} {apellido} agregado con código {codigo}.");
        }

        static void ListarEstudiantes()
        {
            Console.WriteLine("--- LISTA DE ESTUDIANTES ---\n");
            listaEstudiantes.Listar();
        }

        static void BuscarEstudiante()
        {
            Console.WriteLine("--- BUSCAR ESTUDIANTE ---\n");
            string codigo = LeerTextoNoVacio("Ingrese el código: ");
            Estudiante e = listaEstudiantes.BuscarPorCodigo(codigo);
            if (e != null) { Console.WriteLine("\n--- ESTUDIANTE ENCONTRADO ---"); Console.WriteLine(e); }
            else MostrarError($"No se encontró el código {codigo}.");
        }

        static void EliminarEstudiante()
        {
            Console.WriteLine("--- ELIMINAR ESTUDIANTE ---\n");
            string codigo = LeerTextoNoVacio("Ingrese el código: ");
            Estudiante e = listaEstudiantes.BuscarPorCodigo(codigo);
            if (e != null)
            {
                Console.WriteLine(e);
                Console.Write("\n¿Está seguro? (S/N): ");
                if (Console.ReadLine().Trim().ToUpper() == "S")
                {
                    listaEstudiantes.Eliminar(codigo);
                    MostrarExito("Estudiante eliminado.");
                }
                else Console.WriteLine("Cancelado.");
            }
            else MostrarError($"No se encontró el código {codigo}.");
        }

        static void GestionarMaterias()
        {
            Console.WriteLine("--- GESTIONAR MATERIAS ---\n");
            string codigo = LeerTextoNoVacio("Ingrese el código del estudiante: ");
            Estudiante e = listaEstudiantes.BuscarPorCodigo(codigo);
            if (e == null) { MostrarError("Estudiante no encontrado."); return; }

            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine($"--- MATERIAS DE {e.Nombre} {e.Apellido} ---\n");
                Console.WriteLine("1. Agregar materia");
                Console.WriteLine("2. Listar materias");
                Console.WriteLine("3. Modificar nota");
                Console.WriteLine("4. Eliminar materia");
                Console.WriteLine("5. Volver\n");

                switch (LeerEntero("Opción: "))
                {
                    case 1:
                        string nom = LeerTextoNoVacio("Nombre materia: ");
                        double nota = LeerDouble("Nota (0-5): ", 0, 5);
                        if (e.Materias.Agregar(new Materia(nom, nota))) MostrarExito("Materia agregada.");
                        else MostrarError("Esa materia ya existe.");
                        break;
                    case 2:
                        e.Materias.Listar();
                        if (!e.Materias.EstaVacia()) Console.WriteLine($"\nPromedio: {e.Materias.CalcularPromedio():F2}");
                        break;
                    case 3:
                        e.Materias.Listar();
                        string nomMod = LeerTextoNoVacio("Materia a modificar: ");
                        double nuevaNota = LeerDouble("Nueva nota (0-5): ", 0, 5);
                        if (e.Materias.ModificarNota(nomMod, nuevaNota)) MostrarExito("Nota modificada.");
                        else MostrarError("Materia no encontrada.");
                        break;
                    case 4:
                        e.Materias.Listar();
                        string nomElim = LeerTextoNoVacio("Materia a eliminar: ");
                        Console.Write("¿Seguro? (S/N): ");
                        if (Console.ReadLine().Trim().ToUpper() == "S")
                        {
                            if (e.Materias.Eliminar(nomElim)) MostrarExito("Materia eliminada.");
                            else MostrarError("Materia no encontrada.");
                        }
                        break;
                    case 5:
                        volver = true;
                        break;
                    default:
                        MostrarError("Opción no válida.");
                        break;
                }

                if (!volver)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static int LeerEntero(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out int r)) return r;
                MostrarError("Ingrese un número válido.");
            }
        }

        static double LeerDouble(string mensaje, double min, double max)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (double.TryParse(Console.ReadLine(), out double r) && r >= min && r <= max) return r;
                MostrarError($"Ingrese un número entre {min} y {max}.");
            }
        }

        static string LeerTextoNoVacio(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string input = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(input)) return input;
                MostrarError("Este campo no puede estar vacío.");
            }
        }

        static void MostrarExito(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✓ {msg}");
            Console.ResetColor();
        }

        static void MostrarError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"✗ {msg}");
            Console.ResetColor();
        }
    }
}