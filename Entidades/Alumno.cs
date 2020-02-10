using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueId {get; private set;}

        public string Nombre {get; set;}

        public List<Evaluacion> Evaluacion {get; set;}

        public Alumno()=> UniqueId = System.Guid.NewGuid().ToString();
    }
}