
namespace Menus;

internal class Consultas
{
    internal void Consultar()
    {
        Menu menu = new Menu();
        string[] opciones = { "1. Consultar por ID", "2. Consultar por Nombre", "3. Consultar por Fecha" };

        int seleccion = menu.MenuSeleccion(opciones, "Seleccione una opción de consulta:", "Consultas: ");
        switch (seleccion)
        {
            case 1:
                Console.WriteLine("Has seleccionado: Consultar por ID");
                // Lógica para consultar por ID
                break;
            case 2:
                Console.WriteLine("Has seleccionado: Consultar por Nombre");
                // Lógica para consultar por Nombre
                break;
            case 3:
                Console.WriteLine("Has seleccionado: Consultar por Fecha");
                // Lógica para consultar por Fecha
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
}
