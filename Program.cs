using System;
using System.Collections.Generic;
using EtapaUno.Entidades;
using static System.Console;

namespace EtapaUno
{
    class Program
    {
        static void Main(string[] args)
        {
            var miEscuela = new Entidades.Escuela("Agusti", 1966);
            miEscuela.Pais = "Colombia";
            miEscuela.ciudad = "Bogota";
            miEscuela.TipoEscuela = Entidades.TiposEscuela.Primaria;

            var arregloCursos = new Entidades.Curso[3];
            var segundaEscuela = new Entidades.Escuela("Calazans", 1980, EtapaUno.Entidades.TiposEscuela.Secundaria, ciudad: "Bogota");
            var curso1 = new Entidades.Curso()
            {
                Nombre = "101",
            };
            var curso2 = new Entidades.Curso()
            {
                Nombre = "201",
            };
            var curso3 = new Entidades.Curso()
            {
                Nombre = "301",
            };

            arregloCursos[0] = curso1;
            arregloCursos[1] = curso2;
            arregloCursos[2] = curso3;

            miEscuela.Cursos = arregloCursos;
            /*Console.WriteLine(miEscuela);
            Console.WriteLine(segundaEscuela);
            WriteLine("==========");
            WriteLine(curso1.Nombre + ", " + curso1.UniqueID);
            WriteLine(curso2.Nombre + ", " + curso2.UniqueID);
            WriteLine($"{curso3.Nombre} , {curso3.UniqueID}");
            Console.ReadLine();
            System.Console.WriteLine("==========");
            imprimirCursosWhile(arregloCursos);
            System.Console.WriteLine("==========");
            imprimirCursosDoWhile(arregloCursos);
            System.Console.WriteLine("==========");
            imprimirCursosForEach(arregloCursos);*/

            imprimirCursosEscuela(miEscuela.Cursos);

            var listaCursos = new List<Curso>(){
                new Curso(){ Nombre = "102", Jornada= TiposJornada.Mañana},
                new Curso(){ Nombre = "202", Jornada= TiposJornada.Mañana},
                new Curso(){ Nombre = "302", Jornada= TiposJornada.Mañana}
            };

            var otraListaCursos = new List<Curso>(){
                new Curso(){ Nombre = "402", Jornada= TiposJornada.Mañana},
                new Curso(){ Nombre = "502", Jornada= TiposJornada.Mañana},
                new Curso(){ Nombre = "103", Jornada= TiposJornada.Tarde}
            };

            /*Remover objetos de una coleccion*/
            //otraListaCursos.Clear();
            miEscuela.CursosList = listaCursos;

            miEscuela.CursosList.Add(new Curso { Nombre = "103", Jornada = TiposJornada.Tarde });
            miEscuela.CursosList.Add(new Curso { Nombre = "203", Jornada = TiposJornada.Tarde });

            miEscuela.CursosList.AddRange(otraListaCursos);

            Curso tmp = new Entidades.Curso() { Nombre = "101-vacacional", Jornada = TiposJornada.Noche };
            miEscuela.CursosList.Add(tmp);
            /*Remover algunos elementos*/
            imprimirSegundosCursos(miEscuela);
            miEscuela.CursosList.Remove(tmp);
            imprimirSegundosCursos(miEscuela);

            /*Remover con delegado*/
            miEscuela.CursosList.RemoveAll(delegate (Curso cur)
            {
                return cur.Nombre == "402";
            });

            /*Expresion lambda*/
            miEscuela.CursosList.RemoveAll((cur) => cur.Nombre == "203" && cur.Jornada == TiposJornada.Tarde ); 
            
            imprimirSegundosCursos(miEscuela);
        }

        private static bool Predicado(Curso cur)
        {
            return cur.Nombre == "402";
        }

        private static void imprimirSegundosCursos(Escuela miEscuela)
        {
            WriteLine("====== Lista de segundos cursos de la escuela ======");
            foreach (var curso in miEscuela.CursosList)
            {
                Console.WriteLine($"Nombre: {curso.Nombre}");
            }
        }
        private static void imprimirCursosEscuela(Curso[] cursos)
        {
            WriteLine("====== Lista de cursos de la escuela ======");
            foreach (var curso in cursos)
            {
                Console.WriteLine($"Nombre: {curso.Nombre}");
            }
        }
        private static void imprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            do
            {
                Console.WriteLine($"Nombre: {arregloCursos[contador].Nombre} , ID: {arregloCursos[contador].UniqueID}");
                contador++;
            } while (contador < arregloCursos.Length);
        }

        private static void imprimirCursosWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, ID {arregloCursos[contador].UniqueID}");
                contador = contador + 1;
            }
        }

        private static void imprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                Console.WriteLine($"Nombre: {curso.Nombre} , ID: {curso.UniqueID}");
            }
        }

    }
}
