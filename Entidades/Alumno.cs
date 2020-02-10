namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueId {get; private set;}

        public string Name {get; set;}

        public Alumno()=> UniqueId = System.Guid.NewGuid().ToString();
    }
}