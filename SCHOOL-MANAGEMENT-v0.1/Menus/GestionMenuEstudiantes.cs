//Namespace para que los menus esten presente en este espacio
using Datos;
using Extras;
using Gestion_Escuela_Primaria.Menus;
using Spectre.Console;

namespace Menus
{
    internal class GestionMenuEstudiantes
    {
        internal async Task Gestion()
        {
            //***************************************************************
            //           Menu para la gestion de estudiantes
            //***************************************************************

            // Instancia de la clase Menu
            Menu menu = new Menu();
            Validacion Validacion = new Validacion();

            Utiles utiles = new Utiles();

            int opcionMenu = 0;
            string[] opcionesGestionEstudiantes =
            {
                "1. Agregar Estudiante",
                "2. Modificar Estudiante",
                "3. Eliminar Estudiante",
                "4. Ver Estudiantes",
                "5. Buscar Estudiante",
                "6. Regresar al Menú administrador"
            };

            Console.Clear();
            await utiles.Cargando("Iniciando sistema de gestion de estudiantes...");

            

            while (true)
            {
                opcionMenu = menu.MenuSeleccion(opcionesGestionEstudiantes, "Seleccione una operacion para la gestion", "Gestion de estudiantes");

                switch (opcionMenu)
                {
                    case 1:
                        // Lógica para agregar estudiante

                        //=/=/=/=/==/=/=/=/=/==/=/=/==/=/=/=/=/==/=/=/=/=/==/=/=/==/=/=/==/=/=/=
                        //Instacia de la clase AgregarEstudiante para llamar al metodo Agg
                        //=/=/=/=/==/=/=/=/=/==/=/=/==/=/=/=/=/==/=/=/=/=/==/=/=/==/=/=/==/=/=/=

                        Agregar Agregar = new Agregar();
                        await Agregar.AgregarEstdiante();

                        break;
                    case 2:
                        // Lógica para modificar estudiante
                        AnsiConsole.MarkupLine("[yellow]Funcionalidad de modificar estudiante en desarrollo...[/]");
                        break;
                    case 3:
                        // Lógica para eliminar estudiante
                        AnsiConsole.MarkupLine("[yellow]Funcionalidad de eliminar estudiante en desarrollo...[/]");
                        break;
                    case 4:
                       
                        //funcion de prueba
                        Mostrar mos = new Mostrar();
                        mos.ObtenerEstudiantesPorGrado();
                        break;
                    case 5:
                        // Lógica para buscar estudiante
                        AnsiConsole.MarkupLine("[yellow]Funcionalidad de buscar estudiante en desarrollo...[/]");
                        break;
                    case 6:
                        return;
                        
                
                default:
                        // Manejo de opción no válida
                        break;

                } 
            }
        }
    }
}