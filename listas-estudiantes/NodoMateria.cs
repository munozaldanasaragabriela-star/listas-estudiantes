namespace SistemaEstudiantes
{
    public class Materia
    {
        public string Nombre { get; set; }
        public double Nota { get; set; }

        public Materia(string nombre, double nota = 0.0)
        {
            Nombre = nombre;
            Nota = nota;
        }

        public override string ToString()
        {
            return $"{Nombre} - Nota: {Nota:F2}";
        }
    }
}