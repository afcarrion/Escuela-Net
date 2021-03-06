using static System.Console;

namespace CoreEscuela.Util{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 10){
            WriteLine("".PadLeft(tam, '='));
        }
        public static void WriteTitle(string title){

            var tamanoTitle = title.Length + 4;
            DibujarLinea(tamanoTitle);
            WriteLine($"| {title} |");
            DibujarLinea(tamanoTitle);
        }
    }
}