using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Curso:ObjetoEscuelaBase, ILugar
    {
        public TiposJornada Jornada { get; set; }

        public List<Asignatura> Asignaturas{get; set;}
        public List<Alumno> Alumnos{get; set;}
        //public Curso() => UniqueId = Guid.NewGuid().ToString();

        public string Direccion { get; set; }

        public void Limpiar()
        {
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando Establecimiento...");
            Console.WriteLine($"Curso {Nombre} Limpio");
        }
    }
}