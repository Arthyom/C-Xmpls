// hilos de c#
using System;
using System.Threading;
class Suma
{
   int num1, num2, resultado;
   public Suma(int num1, int num2)
   {

      this.num1 = num1;
      this.num2 = num2;
   }
   public void sumar()
   {
     int suma = 0 ;
     while(true) {

      resultado = num1 + num2;

      Console.WriteLine("resultado = {0} {1}", this.resultado, resultado += num2);

    }
   }
   public int getResultado()
   {
      return resultado;
   }
}

public class main{
  public static void Main(string[] args)
  {
    int a = Convert.ToInt32( Console.ReadLine() );
    int b = Convert.ToInt32( Console.ReadLine() );
    int c = Convert.ToInt32( Console.ReadLine() );
    int d = Convert.ToInt32( Console.ReadLine() );

    Suma nuevaSuma1 = new Suma( a,b );
    Suma nuevaSuma2 = new Suma( c,d );

    // crear el hilo
    Thread hilo1 = new Thread ( new ThreadStart(nuevaSuma1.sumar) );
    Thread hilo2 = new Thread ( new ThreadStart(nuevaSuma2.sumar) );

    hilo1.Start();
    //hilo1.Join();

    hilo2.Start();
    //hilo2.Join();


  }
}
