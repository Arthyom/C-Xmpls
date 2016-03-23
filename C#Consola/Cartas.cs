using System;


  public class Cartas{
    private string palo;
    private string cara;

    public Cartas(  string carta, string palo){
      this.cara = carta;
      this.palo  = palo;
    }

    public void imprimirCarta (){
      Console.WriteLine("{0} de {1}", this.cara, this.palo);
    }
  }

  public class Baraja{
    private const int NumCartas = 52;
    public  Cartas [] cartas ;
    private Random randGen ;

    private string []caras = {"Ass","Dos","Tres","Cuatro","Cinco","Seis"};
    private string []palos = {"Corazones", "Diamantes","Treboles","Espadas"};

    public Baraja( ){
      /// darle un valor a cada Carta
      this.cartas  = new Cartas[52];
      this.randGen = new Random();

      for ( int i = 0 ; i < NumCartas  ; i ++ ){
          cartas[i] = new Cartas( caras[randGen.Next(0,6)], palos[randGen.Next(0,3)] );
      }
    }

    public void Barajear(){
      //Barajear el paquete de cartas
      int segunda;
      Cartas CartaAux;
      for ( int primera = 0 ; primera < 52  ; primera ++ ){
           CartaAux = cartas[primera];
           segunda = randGen.Next(NumCartas);
           cartas[primera] = cartas[segunda];
           cartas[segunda] = CartaAux;
      }
    }
  }


public class mn {
  public static void Main(string[] args)
  {
    Baraja baraja = new Baraja ();
    baraja.Barajear();

    for ( int i = 0 , k = 1 ; i < 52 ; i ++ , k++ ){

      baraja.cartas[i].imprimirCarta();
      if ( k % 5 == 0 )
        Console.WriteLine(" ");

    }

  }
}
