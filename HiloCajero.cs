using System;
using System.Threading;

public class cuentaBanco{
  public   int balance;
  public  int GSbalance{
    get {
      return this.balance;
    }

    set{
      this.balance = cuentaBanco;
    }
  }

  public void retirar ( int retire ){
    this.balance = this.balance - retire;
  }
}

public class ATM : Threading {
  private int cuentaBanco, outBanco;
  public void hacerRetiro ( int retiro ){
    if ( this.cuentaBanco <= retiro ){
      Console.PrintLine(" se esta retirando datos ");
      Thread.sleep(1000);
      CuentaBanco.retirar ( retiro );
    }
    else{
      Console.WriteLine("no se puede hacer el retiro");
    }
  }

/*  public void delegado ( int retire ){
    // crear hilos
    Thread hilo1 = new Thread ( new ThreadStart( this.hacerRetiro(retire) );
    Thread hilo2 = new Thread ( new ThreadStart(nuevaSuma2.sumar) );
  }*/
}



public class m1{
  public static void Main(string[] args)
  {
    // crear hilos
    ATM at1 = new ATM ();
    Thread t1 = new ThreadStart();
    Thread t2 = new ThreadStart();

    t1.Start();
    t2.Start();
  }
}
