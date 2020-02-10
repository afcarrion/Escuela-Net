using System.Collections.Generic;
namespace CoreEscuela.Entidades
{
    public class Escuela
    {
        string nombre;
        public string Nombre{
            get{return nombre;}
            set{nombre  = value;}
        }

        public int AñoDeCreacion{get;set;}

        public string Pais { get; set; } 
        public string ciudad { get; set; }

        public TiposEscuela TipoEscuela{get;set;}

        public Curso[] Cursos{ get; set;}

        public List<Curso> CursosList{get; set;}

        /*public Escuela(string nombre, int anoFundacion){
            this.nombre = nombre;
            AñoDeCreacion = anoFundacion;
        }*/
        //Otra forma de implementar un constructor
        public Escuela(string nombre, int año) => (Nombre,AñoDeCreacion) = (nombre,año);

        public Escuela(string nombre, int año, TiposEscuela tipos, string Pais="", string ciudad = ""){
            this.Nombre = nombre;
            AñoDeCreacion = año;
            this.Pais = Pais;
            this.ciudad = ciudad;
            TipoEscuela = tipos;
        }

        public override string ToString(){
            return $"Nombre: {Nombre}, Tipo: {TipoEscuela} \nPais: {Pais}, Ciudad: {ciudad}"; 
        }
    }
}