using Menus;
using Extras;
using Spectre.Console;
using Gestion_Escuela_Primaria.Menus;
using Datos;
namespace BaseDeDatos;

public class Pricipal
{
    internal static async Task Main(string[] args)
    {
        //abrimos conexion con la base de datos
        
        //Crear instancias de las clases necesarias
        
        Menu menu = new Menu(); Utiles Acciones = new Utiles();
        Validacion Validacion = new Validacion();
        Elecciones elecciones = new Elecciones();

        int opcion = 0;
            string[] OpcionesPrincipales = { "1. Gestionar", "2. Consultar", "3. Salir" };

            while (opcion != 3)
            {
                opcion = menu.MenuSeleccion(OpcionesPrincipales, "Seleccione una opción", "Sistema Escolar");

                switch (opcion)
                {
                    case 1:
                        GestionMenuEstudiantes menuEst = new GestionMenuEstudiantes();
                        await elecciones.ElegirAdmin();
                        Acciones.Continuar();
                        break;

                    case 2:
                        Consultas menuConsultas = new Consultas();
                        menuConsultas.Consultar();
                    Acciones.Continuar();
                        break;

                    case 3:
                        await Acciones.Cargando("Saliendo del sistema...");
                        break;

                    default:
                        AnsiConsole.MarkupLine("[red]Opción no válida. Por favor, intente de nuevo.[/]");
                        Acciones.Reintentar();
                        break;
            }
            }
        Console.Clear();
    }
       
        }
    
