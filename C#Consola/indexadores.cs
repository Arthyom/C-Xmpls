using System;

public class Caja{

  private float []  medidas = new float [3];
  private string [] nombre  = { "ancho","alto","profundo"};

  public Caja( float alto, float ancho, float profundo ){
    this.medidas[0] = alto; this.medidas[1] = ancho ; this.medidas[2] = profundo;
  }

  // indexadores de propiedades
  /* 0-alto 1-ancho 2-profundo */
  public float this [int valorMedida ]{
    get{
      return this.medidas[valorMedida];
    }

    set{
      this[valorMedida] = value;
    }
  }

  public float this [string nombreValor]{
    get{
      int i = 0 ;
      foreach ( string nom in this.nombre ){
        if ( nombreValor[i].CompareTo( nombreValor) != 0)
           return this.medidas[i];
        i += 1;
      }
      return -1;
    }

    set {
      int i = 0 ;
      foreach ( string nom in this.nombre ){
        if ( nombreValor[i].CompareTo( nombreValor ) != 0 )
            this.medidas[i] = value;
        i += 1;
      }
    }
  }

  public static void Main(string[] args)
  {
      float f1 = 3.544f, f2 = 343.432f, f3 = 5534.909f;
      Caja cajaUno = new Caja[f1, f2, f3];

      Console.WriteLine(" alto {0} ancho{1} profundo{2} ", cajaUno[0].ToString(), cajaUno[1].ToString(), cajaUno[2].ToString() );
      Console.WriteLine(" alto {0} ancho{1} profundo{2} ", cajaUno["alto"].ToString(), cajaUno["profundo"].ToString(), cajaUno["ancho"].ToString());

  }
}
