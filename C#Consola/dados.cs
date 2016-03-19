// simular tirar un dado una cantidad n de veces
using System;

public class Dado{
  private int [] numeroCaras = new int [6];

  public Dado(){
    Random numPuntos = new Random();
    for ( int i = 0 ; i < this.numeroCaras.Length; i ++)
      numeroCaras[i] = 1 + (numPuntos.Next(1,6));
  }

  public int GetCara ( int cara ){
    if ( cara < numeroCaras.Length )
      return this.numeroCaras[cara];

    return 0;
  }

  public int SetCara ( int cara, int valor ){
    if ( cara < this.numeroCaras.Length ){
      numeroCaras[cara] = valor;
      return 0;
    }

    return 1;
  }

  public static void Main(string[] args)
  {
    // pedir numero de tiros
    int numeroTiros = Convert.ToInt16(Console.ReadLine());
    Dado dado1 = new Dado();
    for ( int i = 0 ; i < numeroTiros ; i ++ )
    {
      // tirar el dadi una cantidad numeroTiros y ver que sale en cada cara
      for ( int j = 0 ; j < 6 ; j ++ )
        Console.WriteLine("tiro : {0} -> valor {1}", i+1, dado1.GetCara(j));

      Console.WriteLine(" ");
    }
  }
}
