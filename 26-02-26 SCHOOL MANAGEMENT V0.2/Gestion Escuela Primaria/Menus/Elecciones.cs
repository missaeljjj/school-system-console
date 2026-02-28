namespace elecciones;

internal class Elecciones
{
    private readonly Menu _menu;
    private readonly Utiles _utiles;
    private readonly MenuGestionMaestroscs _menugestionmaestroscs;
    private readonly GestionMenuEstudiantes _menugestionestudiantes;
    private readonly Consultas _consultas;

    internal Elecciones
        (
        Menu menu,
        Utiles utiles,
        MenuGestionMaestroscs menugestionmaestroscs,
        GestionMenuEstudiantes menugestionestudiantes,
        Consultas consultas 
        )
    {
        _menu = menu;
        _utiles = utiles;
        _menugestionmaestroscs = menugestionmaestroscs;
        _menugestionestudiantes = menugestionestudiantes;
        _consultas = consultas;
    }


    internal async Task ElegirAdmin()
    {
        Usuario _usuario = new Usuario();
        string[] opciones = { "1. Gestion estudiantes ", "2. Gestion Maestros", "3. Volver menu principal" };
       
        bool salir = false;

        Console.Clear();

        if (!_usuario.Acceso)
        {
            if (!await _utiles.LOGIN()) { return; }
            else { AnsiConsole.MarkupLine("[green]Acceso concedido. Bienvenido, administrador.[/]"); }
        }

        _usuario.Acceso = true;

        while (!salir)
        {
            _utiles.Continuar();
            int opcionesMenu = _menu.MenuSeleccion(opciones, "Elija la gestion que va a realizar", "SISTEMA ESCOLAR");
            Console.Clear();

            switch (opcionesMenu)
            {
                case 1:
                    await _menugestionestudiantes.Gestion();
                    break;
                case 2:
                    await _menugestionmaestroscs.Gestion();
                    break;
                case 3:
                    await _utiles.Cargando("Regresando al menu principal...");
                    return;

            }
        }
    }

    internal async Task ElegirConsulta()
    {
        string[] opciones = { "1. Consultar estudiantes ", "2. Consultar Maestros", "3. Volver menu principal" };
        
        bool salir = false;
        
        while (!salir)
        {
            Console.Clear();
            int opcionesMenu = _menu.MenuSeleccion(opciones, "Elija la consulta que va a realizar", "CONSULTAS");
            Console.Clear();
            switch (opcionesMenu)
            {
                case 1:
                    await _consultas.ConsultaEstudiante();
                    break;
                case 2:
                    _consultas.ConsultaDocente();
                    break;
                case 3:
                    await _utiles.Cargando("Regresando al menu principal...");
                    return;
            }

        }
    }
}