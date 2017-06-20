using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FwsCompiler
{
    public class Compilador : Object
    {

        public char                   [,] Cmp_MatrizResultado;
        public Size                       Cmp_Dims;
        public Point                      Cmp_PosicionActuante;
        public Stack<BloqueControl>       Cmp_PilaLlamadas;
        public char                       Cmp_SimboloActuante;
        public char                       Cmp_ActuanteSimbolo;
        public char                       Cmp_VacioSimbolo;

        public Compilador ( int DimsMatrizX, int DimsMatrizY )
        {
            this.Cmp_MatrizResultado = new char[DimsMatrizX, DimsMatrizY];
            this.Cmp_Dims = new Size(DimsMatrizX, DimsMatrizY);
            this.Cmp_PosicionActuante = new Point(0, 0);
            this.Cmp_PilaLlamadas = new Stack<BloqueControl>();
        }

        public Point BuscarACtuante ( char Crt_SimboloActuante )
        {
            for ( int i = 0; i < this.Cmp_Dims.Height; i ++ )
            {
                for ( int j = 0; j < this.Cmp_Dims.Width; j ++ )
                {
                    char c = this.Cmp_MatrizResultado[j, i];
                    if (c == Crt_SimboloActuante)
                        return new Point(j, i);
                }
            }

            return new Point(-1, -1);
        }

        public void FijarNuevaPosicion( int nuevaX, int nuevaY )
        {
            // borrar al actuente de su pos. Actual y moverla a la indicada
            Point pActual =  this.BuscarACtuante(Cmp_ActuanteSimbolo);
            this.Cmp_MatrizResultado[ (int)pActual.X, (int)pActual.Y] = Cmp_VacioSimbolo;

            // mover el actuante a la nueva posicion 
            this.Cmp_MatrizResultado[nuevaX, nuevaY] = Cmp_SimboloActuante;

            // actualizar la nueva posicion del actuante
            this.Cmp_PosicionActuante.X = nuevaX;
            this.Cmp_PosicionActuante.Y = nuevaY;
        }

        public char [,] InterPretarBloque ( BloqueControl Crt_BloqueEntrada )
        {
            // buscar el actuante en la matriz dentro del compilador
            this.Cmp_PosicionActuante = this.BuscarACtuante(this.Cmp_SimboloActuante);

            // mover al actuante deacurdo al tipo de bloque y asu texto

            // arrancar segun el tipo de bloque
            switch ( Crt_BloqueEntrada.Blq_TipoBloque )
            {
                case TipoBloques.Tipo_Bloque_Lineal:

                    // arrancar segun el texto de la etiqueta
                    switch ( Crt_BloqueEntrada.Blq_EtiquetaInterna.Content.ToString() )
                    {
                        case BloqueControl.Txt_MvArriba:

                            // verificar las dimenciones de la matriz 
                            if (this.Cmp_PosicionActuante.Y >= 1)
                                // mover al actuante a la nueva posicion
                                FijarNuevaPosicion( (int)this.Cmp_PosicionActuante.X, (int)this.Cmp_PosicionActuante.Y - 1);


                        break;

                        case BloqueControl.Txt_MvAbajo:

                            // verificar las dimenciones de la matriz
                            if (this.Cmp_PosicionActuante.Y < this.Cmp_Dims.Height - 1)
                                FijarNuevaPosicion((int)this.Cmp_PosicionActuante.X, (int)this.Cmp_PosicionActuante.Y - 1);
                            break;

                        case BloqueControl.Txt_MvDrch:
                            // verificar las dimenciones de la matriz
                            if (this.Cmp_PosicionActuante.X < this.Cmp_Dims.Width - 1)
                                FijarNuevaPosicion((int)this.Cmp_PosicionActuante.X-1, (int)this.Cmp_PosicionActuante.Y );
                            break;

                        case BloqueControl.Txt_MvIzqrd:
                            // verificar las dimenciones de la matriz 
                            if (this.Cmp_PosicionActuante.X >= 1)
                                FijarNuevaPosicion((int)this.Cmp_PosicionActuante.X+1, (int)this.Cmp_PosicionActuante.Y);
                            break;

                    
                    }

                    break;
            }

            // fijar al actuante en la nueva posicion actual
            return this.Cmp_MatrizResultado;
        }

        public void ConseguirBloques ( Canvas CanvasOrigen)
        {
            // recorrer el canvas de origen en busca de bloques
            foreach( BloqueControl b in CanvasOrigen.Children)
            {
                // agregar los controles a la pila de llamadas 
                if ( b is BloqueControl )
                    this.Cmp_PilaLlamadas.Push(b);

            }
        }

        
        


    }
}
