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
        
        Printer.WriteTitle("Prueba de Poliformismo");
        var alumnoTest = new Alumno{Nombre = "Claire UnderWood"};

        ObjetoEscuelaBase ob = alumnoTest;
        
        Printer.WriteTitle("Alumno");
        WriteLine($"Alumno = {alumnoTest.Nombre}");
        WriteLine($"Alumno = {alumnoTest.UniqueId}");
        WriteLine($"Alumno = {alumnoTest.GetType()}");

        Printer.WriteTitle("ob");
        WriteLine($"Alumno = {ob.Nombre}");
        WriteLine($"Alumno = {ob.UniqueId}");
        WriteLine($"Alumno = {ob.GetType()}");

        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Los cursos de la escuela");   

            if (escuela?.CursosList != null)
            {
                foreach (var curso in escuela.CursosList)
                {
                    WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");
                }
            }
        }
    }
}
