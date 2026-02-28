namespace Gestion
{
    internal class Buscar
    {
        IEstudianteRepositorio _estudianterepositorio;
        private readonly Menu _menu;
        private readonly Utiles _utiles;
        private readonly Validacion _validacion;
        private readonly Mostrar _mostrar;
        private readonly Estudiante _estudiante;

        public Buscar
            (
            IEstudianteRepositorio estudianterepositorio,
            Menu menu,
            Utiles utiles,
            Validacion validacion,
            Mostrar mostrar,
            Estudiante estudiante
            )
        {
            _estudianterepositorio = estudianterepositorio;
            _menu = menu;
            _utiles = utiles;
            _validacion = validacion;
            _mostrar = mostrar;
            _estudiante = estudiante;
        }



        //Arreglos de las opciones y paramteros para los menus o tablas
        internal string[] opciones = { "1. Buscar por ID", "2. Buscar por Nombre", "3. Regresar" };
        internal string[] ParametroEstudiantes = { "Id", "Estudiante", "Grado", "Seccion" };
        internal async Task SeleccionBusqueda()
        {

            while (true)
            {
                Console.Clear();
                int seleccion = _menu.MenuSeleccion(opciones, "Seleccione una opción de búsqueda:", "Búsqueda: ");
                switch (seleccion)
                {
                    case 1:
                        await BuscarPorIdEstudiante();
                        break;
                    case 2:
                        await BuscarPorNombreEstudiante();
                        break;
                    case 3:
                        await _utiles.Cargando("Regresando al menú principal");
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                } 
            }
        }
        internal async Task SeleccionBusquedaMaestro()
        {
            while (true)
            {
                Console.Clear();
                int seleccion = _menu.MenuSeleccion(opciones, "Seleccione una opción de búsqueda:", "Búsqueda: ");
                switch (seleccion)
                {
                    case 1:
                        await BuscarPorIdMaestro();
                        break;
                    case 2:
                        await BuscarPorNombreMaestro();
                        break;
                    case 3:
                        await _utiles.Cargando("Regresando Menu Principal");
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                } 
            }
        }
        internal async Task BuscarPorIdEstudiante()
        {
            Console.Clear();
            await _utiles.Cargando("Cargando Estudiantes....", async () =>
            {
                await _estudianterepositorio.MostrarTodos();
            });

            //Datos
            _estudiante.CodigoEstudiante = _validacion.ValidateInt("Ingrese el ID del estudiante a buscar: ", "ID: ");
            Console.Clear();

            await _utiles.Cargando("Buscando estudiantes....", async () =>
            {
                await _estudianterepositorio.BuscarPorID(_estudiante.CodigoEstudiante);
            });
            
            _utiles.Continuar();

        }

        internal async Task BuscarPorNombreEstudiante()
        {
            Console.Clear();
            await _utiles.Cargando("Cargando Estudiantes...", async () =>
            {
                await _estudianterepositorio.MostrarTodos();
            });

            //Datos
            _estudiante.NombreCompleto = _validacion.ValidateString("Ingrese el nombre del estudiante a buscar", "Nombre:");
            Console.Clear();

            await _utiles.Cargando("Buscando...", async () =>
            {
                await _estudianterepositorio.BuscarPorNombre(_estudiante.NombreCompleto);
            });
            _utiles.Continuar();
          
               

               
           
        }
        internal async Task BuscarPorIdMaestro()
        {
            //EN PROCESO
        }

        internal async Task BuscarPorNombreMaestro()
        {
            //EN PROCESO
        }
    }
}