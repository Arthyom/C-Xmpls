using System;
/// ejemplo de herencia en c#
public class Vehiculo{
    private string marca;
    public string  marca{
        set {
            this.marca = value;
        }
        get{
            return this.marca;
        }
    }
    private string modelo;
    public  string modelo{
        set{
            this.modelo = value;
        }
        get{
            return this.modelo;
        }
    }
    private int    numLlantas;
    public  int    numLlantas{
        set{
            this.numLlantas = value,
        }
        get{
            return this.numLlantas;
        }
    }
    
    // constructor 
    public Vehiculo(){
        this.marca = "ninguna",
        this.modelo = "ninguna";
        this.numLlantas = 0,
    }   
}