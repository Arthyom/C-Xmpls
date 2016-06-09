using System;
using System.Text;

public class build {


  public static void Main(string[] args)
  {

    /* las instancias de la clase string son inmutables
       es decir, jamas se podran modificar, sin embargo
       la clase stringbuilder si puede ser mutada */

       StringBuilder stb = new StringBuilder("este es un constructor de textos");
       Console.WriteLine(stb.Length);

   /* los metodos del stringbuilder permiten imitar el tipado dinamico
      ejemplo es el metodo append */

      stb.Append("hola");
      stb.Append(true);
      stb.Append(3);
      stb.Append(23.43);
      stb.Append(false);

      Console.WriteLine(stb.ToString());

  /* mas metodos como insert, remove y Replace reciben dos parametros */

    stb.Insert(0,"hola");
    stb.Insert(0,"adios");
      Console.WriteLine(stb.ToString());


    stb.Remove(3,6);
    stb.Remove(4,8);
      Console.WriteLine(stb.ToString());

    stb.Replace('a','P');
      Console.WriteLine(stb.ToString());

  }




}
