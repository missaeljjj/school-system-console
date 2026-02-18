using Spectre.Console;
using System.Globalization;

namespace Extras
{
    internal class Validacion
    {
        internal T Validaciones <T> (string mensaje1, string mensaje2)
        {
            Utiles util = new Utiles();
            while (true)
            {
                try
                {
                    Console.WriteLine(mensaje1); Console.Write(mensaje2);
                    string entrada = Console.ReadLine()!.Trim();

                    if(typeof(T) == typeof(int))
                    {
                        if (int.TryParse(entrada, out int resultado))
                            return (T)(object)resultado;

                        throw new FormatException();

                    }
                    else if(typeof(T) == typeof(double))
                    {
                        if (double.TryParse(entrada, out double resultado))
                            return (T)(object)resultado;

                        throw new FormatException();

                    }
                    else if(typeof(T) == typeof(string))
                    {
                        if (!string.IsNullOrEmpty(entrada))                        
                            return (T)(object)entrada;

                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    AnsiConsole.MarkupLine("[red]ERROR. Formato no valido[/] ");
                    util.Reintentar();

                    
                }
                util.Continuar();
            }        
        }

        internal DateTime PedirFechaNacimiento()
        {
            Console.Clear();
            Utiles util = new Utiles();
            DateTime fecha;

            int añoMinimo = 2010;   // límite inferior lógico
            int edadMaxima = 15;    // evita fechas absurdamente antiguas
            int añoMayor = 5;      // limite superior lógico
            int añoMaximo = 2019;

            while (true)
            {
                Console.Write("Ingrese la fecha de nacimiento (YYYY-MM-DD): ");
                string input = Console.ReadLine()!;
                util.Cargando("Validando Fecha...").Wait();// Validar formato y parsear fecha

                if (!DateTime.TryParseExact(
                    input,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out fecha))
                {
                    AnsiConsole.MarkupLine("[red]Formato o fecha inválida.[/] [green] Ejemplo válido: 2008-05-12 [/] \n");
                    util.Reintentar();
                    continue;
                }

                //No permitir fechas futuras
                if (fecha > DateTime.Today)
                {
                    AnsiConsole.MarkupLine("[red] La fecha no puede ser en el futuro.[/] ");
                    util.Reintentar();
                    continue;
                }

                // No permitir años demasiado antiguos
                if (fecha.Year < añoMinimo)
                {
                    AnsiConsole.MarkupLine($"[red]El año no puede ser menor a [/]{añoMinimo}.");
                    util.Reintentar();
                    continue;
                }

               
                // Validar edad lógica 
                int edad = DateTime.Today.Year - fecha.Year;
                if (fecha.Date > DateTime.Today.AddYears(-edad)) edad--; // ajustar cálculo

                if (edad > edadMaxima)
                {
                    AnsiConsole.MarkupLine($"[red]El año no puede ser menor a [/]{edadMaxima}.");
                    util.Reintentar();
                    continue;
                }

                if (edad < añoMayor)
                {
                    AnsiConsole.MarkupLine($"[red]El año no puede ser mayor a [/]{añoMaximo}.");
                    util.Reintentar();
                    continue;
                }

                Console.Clear();
                return fecha; // Fecha válida y lógica
            }
        }
    }

 }


