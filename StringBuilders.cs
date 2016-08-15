using System;
using System.Text;

public class build {


  public static void Main(string[] args)
  {

    /* las instancias de la clase string son inmutables
       es decir, jamas se podran modificar, sin embargo
       la clase stringbuilder si puede ser mutada */

       StringBuilder stb = new StringBuilder();

       Console.WriteLine(stb.capacity);

  }




}
