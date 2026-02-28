namespace Entidades;

public class Maestros
{
    public string NombreCompleto { get; set; } = "";
    public int CodigoMaestro { get; set; } = 0;
    public DateTime FechaNacimiento { get; set; }
    public string GradoAsignado { get; set; } = "";
    public char SeccionAsignada { get; set; } = ' ';
    public int CodigoGradoAsignado { get; set; } = 0;
}
