// calculadora barcosa en c#
using System;
public class calculadora{
  private int resultado;
  public  int GSresultado{
    get {
      return resultado;
    }
    set{
      resultado = value;
    }
  }
  public calculadora (){
    resultado = 0;
  }



  public void suma    ( int a,int b ){
    resultado = a+b;
  }

  public void resta   ( int a, int b){
    resultado = a-b;
  }

  public void mult   ( int a, int b){
    resultado = a*b;
  }

  public void div   ( int a, int b){
    resultado = a/b;
  }

  public void imprimir ( int a, int b, int operacion ){
    switch( operacion ){
      case 1:
        Console.WriteLine( "{0} + {1} = {2}", a,b, a+b);
      break;

      case 2:
        Console.WriteLine( "{0} + {1} = {2}", a,b, a+b);
      break;

      case 3:
        Console.WriteLine( "{0} + {1} = {2}", a,b, a+b);
      break;

      case 4:
        Console.WriteLine( "{0} + {1} = {2}", a,b, a+b);
      break;
    }
  }
}

public class principal{
  public static void Main(string[] args)
  {
    // crear calculadora
    char s = Console.ReadLine();
    do{

      s = Console.ReadLine();
      int a = Convert.ToInt16( Console.ReadLine() );
      int b = Convert.ToInt16( Console.ReadLine() );
      calculadora c1 = new calculadora();

      switch (s){
        case '+':
          c1.suma(a,b );
          c1.imprimir(a,b,1);
        break;

        case '-':
          c1.resta(a,b );
          c1.imprimir(a,b,2);
        break;

        case '*':
          c1.mult(a,b );
          c1.imprimir(a,b,3);
        break;

        case '/':
          c1.div(a,b );
          c1.imprimir(a,b,1);
        break;
      }
    }while( s != 's');
  }
}
