using Datos;
using Extras;
using Menus;

namespace Gestion_Escuela_Primaria.Menus
{
    internal class MenuGestionMaestroscs
    {
        internal async Task Gestion()
        {
            Utiles utiles = new Utiles();
            Menu menu = new Menu();
            
            Console.Clear();
            string[] opciones = {"1. Agregar Maestro","2. Eliminar Maestro","3. Modificar Maestro","4. Listar Maestros","5. Regresar al menu administrador"};

            await utiles.Cargando("Cargando Gestión de Maestros...");
           
                int opcion = menu.MenuSeleccion(opciones, "Seleccione una opción para gestionar los maestros:", "Gestión de Maestros");

                switch (opcion)
                {
                    case 1:
                        Agregar agregar = new Agregar();
                        await agregar.AgregarMaestro();
                        // Lógica para agregar maestro
                        break;
                    case 2:
                        break;
                    case 5:
                        return;
                } 
           



        }
    }
}
