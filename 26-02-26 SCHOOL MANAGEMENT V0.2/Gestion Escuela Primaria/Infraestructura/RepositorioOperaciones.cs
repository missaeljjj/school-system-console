
using Npgsql;

namespace Repositorio
{
    internal class RepositorioOperaciones : IOperacionesSql
    {
        private DbConnection _ConexionDb;

        public RepositorioOperaciones(DbConnection ConexionDb)
        {
            _ConexionDb = ConexionDb;
        }

        public async Task<int> ObtenerCodigoGrado(string grado, char seccion)
        {
            using var conexion = await _ConexionDb.ConexionBaseDatos();
            {

                using var comando = new NpgsqlCommand(ComandoSql.SqlObtenerCodigoGrado, conexion);
                {
                    comando.Parameters.AddWithValue("@grado", grado);
                    comando.Parameters.AddWithValue("@seccion", seccion);

                    var resultado = await comando.ExecuteScalarAsync();
                    if (resultado != null && int.TryParse(resultado.ToString(), out int codigoGrado))
                    {
                        return codigoGrado;
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[red]No se encontró el código de grado para el grado y sección proporcionados.[/]");
                        return -1; // O cualquier valor que indique que no se encontró el código
                    }
                }

            }
        }

        public async Task MostrarTabla(NpgsqlDataReader reader, string[] parametros)
        {
            if (!reader.HasRows)
            {
                AnsiConsole.MarkupLine("[red]No hay registros para mostrar[/]");
                return;
            }

            Table Tabla = new Table();
            foreach (string parametro in parametros)
            {
                Tabla.AddColumn($"[green]{parametro}[/]");
            }

            while (await reader.ReadAsync())
            {
                var fila = new List<string>();
                for (int i = 0; i < parametros.Length; i++)
                {
                    // Se obtiene el valor por índice según el orden del SELECT,
                    // evitando depender del nombre exacto de la columna.
                    fila.Add(reader.GetValue(i).ToString()!);
                }
                Tabla.AddRow(fila.ToArray());
            }
            AnsiConsole.Write(Tabla);
        }
    }
}
