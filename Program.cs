using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
         var engine = new EscuelaEngine();
         engine.Inicializar();   
         ImprimirCursosEscuela(engine.Escuela);
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("===========");
            WriteLine("Los cursos de la escuela");
            WriteLine("===========");
            
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
