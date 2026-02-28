namespace Datos;

internal class Agregar
{
    //DI (Inyeccion de clase)
    private readonly IOperacionesSql _operacionesSql;
    private readonly IEstudianteRepositorio _estudianteRepositorio;
    private readonly Utiles _utiles;
    private readonly Validacion _validacion;
    private readonly Menu _menu;
    private readonly Estudiante _estudiante;

    public Agregar
        (
        IOperacionesSql operacionesSql,
        IEstudianteRepositorio estudianteRepositorio,
        Utiles utiles,
        Validacion validacion,
        Menu menu,
        Estudiante estudiante
        )
    {
        _operacionesSql = operacionesSql;
        _estudianteRepositorio = estudianteRepositorio;
        _utiles = utiles;
        _validacion = validacion;
        _menu = menu;  
        _estudiante = estudiante;
    }


    internal async Task AgregarEstudiante()
    {
        //se seleccionan los grados y secciones del estudiante que se agregara 
        _estudiante.GradoPertenciente =_utiles.Grado();
        _estudiante.Seccion = _utiles.Seccion();

        //se pone un await para que el programa no se quede en pausa en negro mientras se conecta a la base de datos
        //Con la funcion lambda esperamos al comando de sql para continuar y evitar pantalla en negro durante ejecucion.
        await _utiles.Cargando("Cargando Datos...", async () =>
        {
            //se obtienen el codigo de grado segund seccion y grado mediante un metodo
            _estudiante.CodigoGrado = await _operacionesSql.ObtenerCodigoGrado(_estudiante.GradoPertenciente, _estudiante.Seccion);
        });

        //se verifica que codigo exista
        if (_estudiante.CodigoGrado == -1) { _utiles.Continuar(); return; }

        //Datos estudiante
        _estudiante.NombreCompleto = _validacion.ValidateString("Ingrese el nombre completo del estudiante: ", "Nombre Completo: ");
        _estudiante.FechaNacimiento = _validacion.PedirFechaNacimiento();

        //Confirmacion
        AnsiConsole.MarkupLine("Desea ingresar los siguientes datos: ");
        AnsiConsole.MarkupLineInterpolated($"ESTUDIANTE: [blue] {_estudiante.NombreCompleto} [/]");
        AnsiConsole.MarkupInterpolated($"GRADO: [blue] {_estudiante.GradoPertenciente} [/]SECCION: [blue] {_estudiante.Seccion} [/]\n");
        bool DesicionIngreso = !_utiles.Decision("¿Desea agregar al estudiante?");

        if (DesicionIngreso)
        {
            AnsiConsole.MarkupLine("Operacion[red] Cancelada[/]"); return;
        }

        bool resultado = false;

        //Se da un mensaje hasta que ingrese los datos a la base de datos
        await _utiles.Cargando("Ingresando Estudiante....", async () =>
        {
            resultado = await _estudianteRepositorio.Agregar(_estudiante.NombreCompleto, _estudiante.FechaNacimiento, _estudiante.CodigoGrado);
        });

        //Mensaje de exito o error
        if (resultado) 
        {
            AnsiConsole.MarkupLine("Estudiante agregado [green]exitosamente[/].");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]ERROR [/]AL INGRESAR ESTUDIANTE.[/]");
        }
        _utiles.Continuar();
    }

    //Muy verde aun, no se puede comprobar se tiene que manejar el sql o comprobar pero esta planteado ya
    internal async Task AgregarMaestro()
    {

    }

}