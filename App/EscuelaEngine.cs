using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
namespace CoreEscuela
{
    public sealed class EscuelaEngine
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

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            bool traeEvaluaciones = true,
            bool traerAlumnos = true,
            bool traerCursos = true,
            bool traerAsignaturas = true
        ){
            return GetObjetoEscuela(out int dummy, out dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traerAlumnos = true,
            bool traerCursos = true,
            bool traerAsignaturas = true
        ){
            return GetObjetoEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traerAlumnos = true,
            bool traerCursos = true,
            bool traerAsignaturas = true
            ){
            
            conteoCursos = 0;
            conteoAsignaturas = 0;
            conteoAlumnos = 0;
            conteoEvaluaciones = 0;

            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);

            if(traerCursos)
                listaObj.AddRange(Escuela.CursosList);

            conteoCursos += Escuela.CursosList.Count;

            foreach(var curso in Escuela.CursosList){
                
                conteoAsignaturas += curso.Asignaturas.Count;
                if(traerAsignaturas)
                listaObj.AddRange(curso.Asignaturas);

                conteoAlumnos += curso.Alumnos.Count;
                if(traerAlumnos)
                listaObj.AddRange(curso.Alumnos);

                if(traeEvaluaciones){
                    foreach(var alumno in curso.Alumnos){
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count(); 
                    }
                }
            }
            return listaObj.AsReadOnly();
        }
        
#region Metodos de Carga
        private void CargarEvaluaciones()
        {
            var lista = new List<Evaluacion>();
            foreach (var curso in Escuela.CursosList)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        //Numero de segundos desde que se inicio el S.O
                        var rnd = new Random(System.Environment.TickCount);
                        for (int i = 0; i < 5; i++){
                            var ev = new Evaluacion{
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
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
#endregion
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


    }
}
