namespace SistemaEstudiantes
{
    public class Estudiante
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public ListaMaterias Materias { get; set; }

        public Estudiante(string codigo, string nombre, string apellido, string direccion, string celular, string email)
        {
            Codigo = codigo;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Celular = celular;
            Email = email;
            Materias = new ListaMaterias();
        }

        public override string ToString()
        {
            return $"Código: {Codigo}\n" +
                   $"Nombre: {Nombre} {Apellido}\n" +
                   $"Dirección: {Direccion}\n" +
                   $"Celular: {Celular}\n" +
                   $"Email: {Email}\n" +
                   $"Materias registradas: {Materias.ObtenerCantidad()}";
        }
    }
}