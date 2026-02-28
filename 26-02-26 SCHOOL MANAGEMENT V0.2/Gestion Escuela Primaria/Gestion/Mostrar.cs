namespace Gestion;
internal class Mostrar
{
    private readonly IEstudianteRepositorio _estudianteRepositorio;
    private readonly IOperacionesSql _operacionesSql;
    private readonly Utiles _utiles;
    private readonly Estudiante _estudiante;
    
    internal Mostrar
        (
        IEstudianteRepositorio estudianteRepositorio,
        IOperacionesSql operacionesSql,
        Utiles utiles,
        Estudiante estudiante

        )
    {
        _estudianteRepositorio = estudianteRepositorio;
        _operacionesSql = operacionesSql;
        _utiles = utiles;
        _estudiante = estudiante;
    }

    internal async Task ObtenerEstudiantesPorGrado()
    {

        _estudiante.GradoPertenciente = _utiles.Grado();
        _estudiante.Seccion = _utiles.Seccion();

        await _utiles.Cargando("Procesando Consulta...", async () =>
        {
            _estudiante.CodigoGrado = await _operacionesSql.ObtenerCodigoGrado(_estudiante.GradoPertenciente, _estudiante.Seccion);

            await _estudianteRepositorio.MostrarPorGrado(_estudiante.CodigoGrado);
        });

        _utiles.Continuar();


    }
    //EN PROCESO
    internal void MostrarTodosMaestros()
    {
       //en proceso
    }
}