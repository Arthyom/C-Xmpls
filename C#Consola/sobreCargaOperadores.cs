using System;

public class NumImg{
  public int real;
  public int img;
  public NumImg( int real, int img ){
    this.real = real;
    this.img  = img;
  }

  // sobrecargar operadores
  public static NumImg operator + ( NumImg n1 , NumImg n2 ){
    NumImg nuevo = new NumImg( n1.real + n2.real, n1.img + n2.img );
    return nuevo;
  }

  public override string ToString (){
    string cadena = string.Format( "{0}.{1}i", this.real, this.img);
    return cadena;
  }
}

public class main {
  public static void Main(string[] args)
  {
    // crear dos numeros
    NumImg n1 = new NumImg(-9,-9);
    NumImg n2 = new NumImg(3,3);

    NumImg n3 = n1 + n2 ;

    Console.WriteLine( "la suma de n1 + n2 = {0}", (n1+n2).ToString());
    Console.WriteLine(" {0} ", n1.ToString());
  }
}
