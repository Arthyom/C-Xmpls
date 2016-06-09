using System;

public class Excpt{
  public static void Main(string[] args)
  {
    //quiebre(0,0);
    try {
      // provocar expceciones
      // lanzar Excepciones propias
      throw new Exception("Esta es una nueva Exception!!!");

      quiebre(0,0);
      int num = 1, den =1;
      int res = num / den;
      int [] vector = new int [3];
      vector [6] =34;
      Console.WriteLine("{0} {1}",res);
    }

    catch (DivideByZeroException){
      Console.WriteLine("NO SE PUEDE DIVIDIR POR CERO!!!");
    }
    catch(FormatException){
      Console.WriteLine("la cadena no tiene el formato Correcto!!!!");
    }
    // bloque cath generico
    catch(Exception e ){
      Console.WriteLine("HA OCURRID UN ERROR GRAVE!!! "+ e.Message);
    }
    // puede exitir un siguiente bloque el finaly
    finally {
      Console.WriteLine("SE  HA TERMINADO LA PRUEBA");
    }


  }
  public static void quiebre( int den, int num){
    Console.WriteLine("{0}",num/den);
  }
}
