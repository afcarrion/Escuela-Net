using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
        }

        public void Inicializar()
        {
            Escuela = new Escuela("Agustiniano", 1966, TiposEscuela.Secundaria, ciudad: "Bogota", Pais: "Colombia");
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            throw new NotImplementedException();
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.CursosList)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre = "Matematicas"},
                    new Asignatura{Nombre = "Educación Fisica"},
                    new Asignatura{Nombre = "Castellano"},
                    new Asignatura{Nombre = "Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosRandom(int cantidad)
        {
            string[] nombre1 = {"Alba", "Andres", "Eusebio", "Felipe", "Juan", "Juana", "Fer", "Jeimmy"};
            string[] nombre2 = {"Freddy", "Fernando", "Javier", "Ricky", "Milena", "Hernan", "Dary"};
            string[] apellido1 = {"Ruiz", "Sarmiento", "Uribe", "Velez", "Petro", "Trump", "Maduro", "Chavez"}; 

            var listaAlumnos =  from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno{Nombre=$"{n1} {n2} {a1}"};
            return listaAlumnos.OrderBy((al)=>al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.CursosList = new List<Curso>(){
                new Curso(){Nombre= "101", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre= "201", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre= "301", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre= "401", Jornada = TiposJornada.Tarde},
                new Curso(){Nombre= "501", Jornada = TiposJornada.Tarde}
            };
            Random rnd = new Random();
            foreach (var curso in Escuela.CursosList)
            {
                int cantidadRandom = rnd.Next(10,30);
                curso.Alumnos = GenerarAlumnosRandom(cantidadRandom);
            }
        }
    }
}
