using System;

public class str{

  public static void Main(string[] args)
  {
    string c1  = "Cadena1";
    string c2 = "Cadena1";

    if ( c1 == "Cadena1" )
      Console.WriteLine("son iguales");
      else
      Console.WriteLine("N0 son iguales");

      /* el operador igualdad permite comparar cadenas, los numeros
         estan dentro de lo reconocible, tambien son capces de comparar
         letras mayusculas y minusculas, tambien puede diferenciar entre
         instancias de la clase string y simples strings

      */

      string C3 = "Cad2";
      string C4 = "Cad3";

      if ( C3.Equals(C4) )
        Console.WriteLine("Las cadenas son iguales");
      else
      Console.WriteLine("Las cadenas NO son iguales");

      /* el comportamiento de Equals, es el mismo que el comparador == */


      string C5 = "cadena";
      string C6 = "cadena";

      if ( C5.CompareTo(C6) == 0 )
        Console.WriteLine("Cadena Cmp es igual");
      else
        Console.WriteLine("las cadenas con CMO NO son iguales");



        /* malavares con strings */

     /* los metods ends, starts */
     string [] cad  = {"string","stringdos","stringtres"};

     Console.WriteLine(cad[1]);

     foreach ( string st in cad )
            if ( st.EndsWith("res") )
                Console.WriteLine("si comienza");

    /* extracion de subcadenas */
    string cadenainicio = "cadena de inicio y de final";

    Console.WriteLine(cadenainicio.Substring(3));
    Console.WriteLine( cadenainicio.ToUpper());
    Console.WriteLine( cadenainicio.Replace("cad","no"));
    Console.WriteLine( cadenainicio.Trim());
    Console.WriteLine( String.Concat(cadenainicio,C5) );

  }
}
