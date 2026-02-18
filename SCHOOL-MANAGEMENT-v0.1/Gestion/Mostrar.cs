using BaseDeDatos;
using Extras;
using Gestion_Escuela_Primaria.Menus;
using Npgsql;
using Spectre.Console;
using System.Data;


namespace Datos
{
    /// <summary>
    ///EN proceso hasta que pueda gestionar bien los comandos............
    /// <summary>


    internal class Mostrar
    {
        public void ObtenerEstudiantesPorGrado()
        {
            Utiles acciones = new Utiles();
            Elecciones elecciones = new Elecciones();
            string grado = elecciones.Grado();
            char seccion = elecciones.Seccion();

            int codigo = acciones.ObtenerCodigoGrado(grado, seccion);


            const string sql = @"
            SELECT 
            s.id_estudiante_new AS id,
            s.nombre_completo AS estudiante,
            g.grado,
            g.seccion,
            m.nombre AS maestro
            FROM students s
            INNER JOIN grados g 
            ON s.codigo_gradoperteneciente = g.codigo_grado
            INNER JOIN maestros m
            ON m.codigo_gradoasignado = g.codigo_grado
            WHERE g.codigo_grado = @codigo
            AND g.seccion = @seccion;";

            using var conexion = DbConnection.ConexionBaseDatos();
            using var cmd = new NpgsqlCommand(sql, conexion);

            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@seccion", seccion);

            var tabla = new DataTable();
            using var adaptador = new NpgsqlDataAdapter(cmd);
            adaptador.Fill(tabla);

            if (tabla.Rows.Count == 0)
            {
                AnsiConsole.Markup("[red]No hay registros para ese grado y sección[/]\n");
                acciones.Continuar();
                return;
            }

            var fila = tabla.Rows[0];

            AnsiConsole.Markup($"Maestro(a): [yellow]{fila["maestro"]}[/]  " + $"Grado: [green]{fila["grado"]} {fila["seccion"]}[/]\n\n");

            var table = new Table();
            table.AddColumn("[yellow]ID[/]");
            table.AddColumn("[green]Nombre[/]");

            foreach (DataRow r in tabla.Rows)
             table.AddRow(r["id"].ToString()!, r["estudiante"].ToString()!);

            AnsiConsole.Write(table);
            acciones.Continuar();

        }

    }
}