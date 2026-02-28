using System.Globalization;

namespace Extras
{
    internal class Validacion
    {
        private Utiles _utiles;

        internal Validacion(Utiles utiles)
        {
            _utiles = utiles;
        }
        //Validacion de string
        internal string ValidateString(string mensaje1, string mensaje2)
        { 
            while (true)
            {
                AnsiConsole.MarkupLine($"[green]{mensaje1}[/]");
                AnsiConsole.Markup($"[blue]{mensaje2}[/]");
                string input = Console.ReadLine()!.Trim();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;      
            }
        }
        //Validacion de int
        internal int ValidateInt(string mensaje1, string mensaje2)
        {
            while (true)
            {
                AnsiConsole.MarkupLine($"[green]{mensaje1}[/]");
                AnsiConsole.Markup($"[blue]{mensaje2}[/]");
                string input = Console.ReadLine()!.Trim();
                if (int.TryParse(input, out int result))
                    return result;
            }
        }

        //Validaciones de fechas
        internal DateTime PedirFechaNacimiento()
        {
            Console.Clear();
           
            DateTime fecha;

            int añoMinimo = 2010;   // límite inferior lógico
            int edadMaxima = 15;    // evita fechas absurdamente antiguas
            int añoMayor = 5;      // limite superior lógico
            int añoMaximo = 2019;

            while (true)
            {
                Console.Write("Ingrese la fecha de nacimiento (YYYY-MM-DD): ");
                string input = Console.ReadLine()!;
                _utiles.Cargando("Validando Fecha...").Wait();// Validar formato y parsear fecha

                if (!DateTime.TryParseExact(
                    input,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out fecha))
                {
                    AnsiConsole.MarkupLine("[red]Formato o fecha inválida.[/] [green] Ejemplo válido: 2008-05-12 [/] \n");
                    _utiles.Reintentar();
                    continue;
                }

                //No permitir fechas futuras
                if (fecha > DateTime.Today)
                {
                    AnsiConsole.MarkupLine("[red] La fecha no puede ser en el futuro.[/] ");
                    _utiles.Reintentar();
                    continue;
                }

                // No permitir años demasiado antiguos
                if (fecha.Year < añoMinimo)
                {
                    AnsiConsole.MarkupLine($"[red]El año no puede ser menor a [/]{añoMinimo}.");
                    _utiles.Reintentar();
                    continue;
                }

               
                // Validar edad lógica 
                int edad = DateTime.Today.Year - fecha.Year;
                if (fecha.Date > DateTime.Today.AddYears(-edad)) edad--; // ajustar cálculo

                if (edad > edadMaxima)
                {
                    AnsiConsole.MarkupLine($"[red]El año no puede ser menor a [/]{edadMaxima}.");
                    _utiles.Reintentar();
                    continue;
                }

                if (edad < añoMayor)
                {
                    AnsiConsole.MarkupLine($"[red]El año no puede ser mayor a [/]{añoMaximo}.");
                    _utiles.Reintentar();
                    continue;
                }

                Console.Clear();
                return fecha; // Fecha válida y lógica
            }
        }
    }

 }


