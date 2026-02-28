namespace Entidades;

public class Estudiante
{
    public string NombreCompleto { get; set; } = "";
    public int CodigoEstudiante { get; set; } = 0;
    public DateTime FechaNacimiento { get; set; }
    public string GradoPertenciente { get; set; } = "";
    public char Seccion { get; set; }= ' ';
    public int CodigoGrado { get; set; } = 0;
}
