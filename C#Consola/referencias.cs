using System;

public class Referencia{

  public static void ModInit ( ref int varInit ){
    varInit = 20;
  }

  public static void ModNtInit ( out int varNtInit ){
    varNtInit = 34;
  }

  // ver como se cambian los valores para un vector
  public static void CambVector ( int [] vector ){
    // poner elementos en un 1
    for ( int i = 0 ; i < vector.Length ; i ++ )
        vector[i] = i + 1;
  }

  public static void PrntVctr ( int [] vector ){
    for ( int i = 0 ; i < vector.Length ; i ++ )
        Console.WriteLine(" {0} ", vector[i] );

  }

}

public class refo{
  public static void Main(string[] args)
  {
    int varInit = 0;
    int varNtInit ;
    int [] vectInit = new int [9];



    Console.WriteLine("La Variable empieza con {0}", varInit);
    Console.WriteLine("La variable no se inicia");
    Referencia.PrntVctr(vectInit);



    Referencia.ModInit( ref varInit);
    Referencia.ModNtInit(out varNtInit);
    Referencia.CambVector(vectInit);
    Referencia.CambVector(vectInit);

    Console.WriteLine("La Variable termina {0}", varInit);
    Console.WriteLine("La variable termina {0}", varNtInit);
    Referencia.PrntVctr(vectInit);



  }
}
