using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HilosConsola
{
    class impresor
    {
        public void imprimir()
        {
            Console.WriteLine("imprimiendo un hilo");
            while (true)
            {
                // crear una cantidad de numeros aleatorios
                Random inactividad = new Random();
                int descansav = inactividad.Next(5000);

                // poner a dormir al hilo una cantidad de incatividad
                Thread hiloActual = Thread.CurrentThread;

                Console.WriteLine("El hilo {0} Dormira {1}", hiloActual.Name, descansav);
                Thread.Sleep(descansav);
                Console.WriteLine("El hilo {0} dejara de estar inactivo, han pasado {1} segundos", hiloActual.Name, descansav);
            }
        }
    }



    class ProbadorHilos
    {
        static void Main(string[] args)
        {
            // definir un objato impresora para probar los hilos
            impresor imp1 = new impresor();
            impresor imp2 = new impresor();
            impresor imp3 = new impresor();

            // crear hilos y pasarles sus delegados 
            Thread SubProceso1 = new Thread( new ThreadStart( imp1.imprimir ) );
            Thread SubProceso2 = new Thread(new ThreadStart(imp2.imprimir));
            Thread SubProceso3 = new Thread(new ThreadStart(imp3.imprimir));

            SubProceso1.Name = "Sub1";
            SubProceso2.Name = "Sub2";
            SubProceso3.Name = "Sub3";

            Console.WriteLine("Se va a correr un nuevo subproceso");

        
                SubProceso1.Start();
                SubProceso2.Start();
                SubProceso3.Start();
        
        
           

            Console.WriteLine("subprocesos iniciados");

            Console.ReadLine();






        }
    }
}
