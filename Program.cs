using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
         var engine = new EscuelaEngine();
         engine.Inicializar();  
         Printer.WriteTitle("Bienvenidos a la Escuela"); 
         ImprimirCursosEscuela(engine.Escuela);
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Los cursos de la escuela");   

            if (escuela?.CursosList != null)
            {
                foreach (var curso in escuela.CursosList)
                {
                    WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueID}");
                }
            }
        }
    }
}
