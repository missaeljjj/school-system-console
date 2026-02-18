namespace Datos
{
    
        internal class Persona
        {
            internal string NombreCompleto { get; set; } = "";
        }

        internal class Estudiante : Persona
        {
            internal DateTime FechaNacimiento { get; set; } 
            internal int CodigoEstudiante { get; set; } = 0;
            internal int CodigoGrado { get; set; }  = 0;
        }

        internal class Profesor : Persona
        {
            internal int CodigoProfesor { get; set; } = 0;
            internal int CodigoGradoPertenciente { get; set; } = 0;

        }   
        internal class Usuarios 
        {
            internal string NombreGestion { get; set; } = "MM";
            internal string ContraseñaGestion { get; set; } = "280125";

            internal static bool Acceso = false;
        }
    }
