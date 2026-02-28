using Spectre.Console;
namespace Menus
{
    internal class Menu 
    {
        internal int MenuSeleccion(string[]opciones, string indicaciones,string TextoFormato)
        {
            //*************************************************************************
            //Esto se ha utilizado para dar formato al texto del menú principal
            //para mostrar un menu que pueda ser dirigido con mayor claridad al usuario
            //dando facilidad el poder mover de opcion con las flechas del teclado
            //*************************************************************************

            AnsiConsole.Write(new FigletText(TextoFormato.ToUpper()).Centered().Color(Color.Green));
            var opcion = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title(indicaciones)
                .WrapAround()
                .PageSize(10)
                .AddChoices(opciones)   );

            return Array.IndexOf(opciones, opcion) + 1;
        }
    }
}
