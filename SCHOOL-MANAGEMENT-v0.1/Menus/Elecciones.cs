using Datos;
using Extras;
using Menus;
using Spectre.Console;
using System.Security.Cryptography.X509Certificates;
namespace Gestion_Escuela_Primaria.Menus
{
    internal class Elecciones
    {
        internal string Grado()
        {
            Console.Clear();
            Menu menu = new Menu();
            string[] grados = new string[] { "Primer grado", "Segundo grado", "Tercer grado", "Cuarto grado", "Quinto grado", "Sexto grado" };
            int opcion = menu.MenuSeleccion(grados, "Seleccione el grado del estudiante:", "Sistema escolar");
            Console.Clear();
            switch (opcion)
            {
                case 1:
                    return grados[0];
                case 2:
                    return grados[1];
                case 3:
                    return grados[2];
                case 4:
                    return grados[3];
                case 5:
                    return grados[4];
                case 6:
                    return grados[5];
                default:
                    return "Grado no seleccionado";
            }

        }
        internal char Seccion()
        {
            Console.Clear();
            Menu menu = new Menu();
            string[] opciones = { "Seccion A", "Seccion B" };

            int opcion = menu.MenuSeleccion(opciones, "Seleccione la sección del grado:", "Sistema Escolar");
            Console.Clear();
            switch (opcion)
            {
                case 1:
                    return 'A';
                case 2:
                    return 'B';
                default:
                    return ' ';
            }

        }

        internal async Task ElegirAdmin()
        {
            string[] opciones = { "1. Gestion estudiantes ", "2. Gestion Maestros", "3. Volver menu principal" };
            Utiles U = new Utiles();
            Menu M = new Menu();
            bool salir = false;
            MenuGestionMaestroscs Maestros = new MenuGestionMaestroscs();
            GestionMenuEstudiantes estudiantes = new GestionMenuEstudiantes();

            Console.Clear();

            if (!Usuarios.Acceso )
            {
                if (!U.LOGIN()) { return; }
                else {AnsiConsole.MarkupLine("[green]Acceso concedido. Bienvenido, administrador.[/]"); }
            }
            

            Usuarios.Acceso = true;
            

            while(!salir)
            {
                U.Continuar();
                int opc = M.MenuSeleccion(opciones, "Elija la gestion que va a realizar", "Sistema escolar");
                Console.Clear();

                switch (opc)
                {
                    case 1:
                        await estudiantes.Gestion();
                        break;
                    case 2:
                        await Maestros.Gestion();
                        break;
                    case 3:
                        await U.Cargando("Regresando al menu principal...");
                        return;

                }
            }
            


        }
    }
}