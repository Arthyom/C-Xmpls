using System;

public class Estudiante{
  private string nombre;
  public  string GSnombre{
    set{
      this.nombre = value;
    }
    get{
      return this.nombre;
    }
  }

  private int calificacion;
  public  int GScalificacion{
    set{
      this.calificacion = value;
    }

    get{
      return this.calificacion;
    }
  }

  public Estudiante(){
    this.calificacion = 0;
    this.nombre       = "ninguno";
  }
}

public class LibroCalif{
  public static void Main(string[] args)
  {
    // crear un libro de calificaciones
    Estudiante [] VectorEstudiantes = new Estudiante [10];

    for ( int i = 0 ; i < VectorEstudiantes.Length ;i ++ )
        VectorEstudiantes[i] = new Estudiante();

    // darle valores a las calificaciones
    for (int i = 0 ;i < VectorEstudiantes.Length ; i ++ ){
         VectorEstudiantes[i].GScalificacion = i ;
         VectorEstudiantes[i].GSnombre       = "Estudiante " + i.ToString();
    }

    // mostrar distrubucion de Estudiante
    int [] CalifDistr = new int[10];


    for ( int i = 0 ; i < VectorEstudiantes.Length ; i ++ ){
      int suma = 1;
      for (int j = 0 ; j < VectorEstudiantes.Length ; j ++ ){
        if ( VectorEstudiantes[j].GScalificacion == VectorEstudiantes[i].GScalificacion ){
            CalifDistr[i] += suma;
            suma += 1;
        }
      }
    }

    CalifDistr[0] += 1;
    CalifDistr[0] += 1;
    CalifDistr[0] += 1;
    CalifDistr[0] += 1;

    CalifDistr[4] += 1;
    CalifDistr[4] += 1;
    CalifDistr[4] += 1;

    CalifDistr[8] += 1;
    CalifDistr[8] += 1;


    // mostrar las calificaciones de los Estudiante
    foreach ( Estudiante est in VectorEstudiantes )
            Console.WriteLine( "Estudiante:  {0}   calificacion:  {1}", est.GSnombre,est.GScalificacion);

    // mostrar la distrubucion
    foreach( int est in CalifDistr )
            Console.WriteLine(" distrubucion {0} ", est );

   // mostrar la distrubucion con asteriscos
   foreach( int est in CalifDistr ){
     Console.Write("distrubucion : ");
     for ( int j = 0 ; j< est ; j++ )
         Console.Write("*");
    Console.WriteLine(" ");

   }





  }
}
