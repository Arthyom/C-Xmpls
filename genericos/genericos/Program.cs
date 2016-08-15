using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace genericos
{
    class Program
    {
        static void Main(string[] args)
        {

            // implementar colas 
            Queue miCola = new Queue();

            // encolar objetos
            miCola.Enqueue("esta");
            miCola.Enqueue("es");
            miCola.Enqueue("una");
            miCola.Enqueue("cola");

            foreach (string cadena in miCola)
                Console.WriteLine(cadena);

            Console.WriteLine(miCola.Count);
            Console.WriteLine(miCola.Contains("esta"));

            Console.WriteLine(miCola.Dequeue());
            Console.WriteLine(miCola.Dequeue());

            Console.WriteLine(miCola.Count);

            foreach (string cadena in miCola)
                Console.WriteLine(cadena);




            Console.Read();





          



        }
    }
}
