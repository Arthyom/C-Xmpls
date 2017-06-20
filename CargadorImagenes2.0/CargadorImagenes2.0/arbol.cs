using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CargadorImagenes2._0
{
    class arbol
    {

        public const char ColorBlanco = 'B';
        public const char ColorNegroo = 'N';

        public const char CasillaVacia = '0';

        public char[] PiesasBlanco = { 'P', 'A', 'T', 'R', 'K', 'C' };
        public char[] PiesasNegro  = { '6', '3', '1', '4', '5', '2' };

        public char[,] TabEjemplo = {
              {  '1','6','0','0','0','0','P','T' },
              {  '2','6','0','0','0','0','P','2' },
              {  '3','6','0','0','0','0','P','A' },
              {  '4','6','0','0','0','0','P','R' },
              {  '5','6','0','0','0','0','P','5' },
              {  '3','6','0','0','0','0','P','A' },
              {  '2','6','0','0','0','0','P','2' },
              {  '1','6','0','0','0','0','P','T' }
            };


        int numeroNodos;
        public nodo raiz;

        public arbol()
        {
            this.numeroNodos = 0;
            this.raiz = new nodo(8, "raiz estado inicial");
        }

        public arbol(nodo raiz)
        {
            this.raiz = raiz;
            this.numeroNodos = 1;
        }

        public void insertarNodo(nodo padre, nodo vectorHijos)
        {
            // conectar al padre con sus hijos 
            padre.nodosHijos.Add(vectorHijos);

            // aumentar el numero de nodos en el arbol 
            this.numeroNodos += 1;
        }

        public void insertarNodos(nodo[] nuevosNodos)
        {
            // la insercion se realiza por defecto en la raiz 
            for (int i = 0; i < nuevosNodos.Length; i++)
            {
                nuevosNodos[i].nodoPadre = this.raiz;
                this.raiz.nodosHijos.Add(nuevosNodos[i]);
            }

            /// aumentar las dimenciones del arbol 
            this.numeroNodos += nuevosNodos.Length;
        }

        public void insertarNodo(nodo nuevoNodo)
        {
            // la insercion se realiza por defecto en la raiz 
           
                nuevoNodo.nodoPadre = this.raiz;

            // padre con hijos
            raiz.nodosHijos.Add( nuevoNodo);

            /// aumentar las dimenciones del arbol 
            this.numeroNodos += 1;

        }

        public void insertarNodoEn(nodo nuevoNodo ,nodo padre)
        {
            // la insercion se realiza por defecto en la raiz 

            nuevoNodo.nodoPadre = padre;

            // padre con hijos
            padre.nodosHijos.Add(nuevoNodo);

        }

        // buscar al nodo con la mejor euristica 
        public nodo MejorEstado(nodo padre)
        {
            nodo n =  new nodo();
            n.valor = 0;

            // iterar para nodo hijo de la raiz 
            for (int i = 0; i < padre.nodosHijos.Count; i++)
            {
                nodo ns = padre.nodosHijos[i];
                if (ns.valor > n.valor)
                    n = ns;
            }
            return n;
        }

        public int calcularHeuristicas ( char pieza )
        {
            int t = 0;
            switch (pieza)
            {
                case 'P':
                case '6':
                    t = 10;
                    break;

                case 'A':
                case '3':
                    t = 7;
                    break;

                case 'T':
                case '1':
                    t = 4;
                    break;

                case 'R':
                case '4':
                    t = 2;
                    break;
            }
            return t;
        }


        // realiza un movimiento a partir de un estado actual 
        public nodo  generarMovimientos( nodo nodoActual, char turno )
        {
            Console.WriteLine("Antes del movimiento ");
            imprimirTablero(nodoActual.tablero);
            // recorrer el tablero en busca de una pieza para el turno indicado
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    nodo nuevo = new nodo();
                    nuevo.nodoPadre = nodoActual;

                    char[,] TableroACtual = copiarTablero( nodoActual.tablero );             
                    char[,] NuevoTAblero = null;

                    char c = TableroACtual[j, i];
                    nuevo.nombreNodo = c.ToString();
                    nuevo.valor = this.calcularHeuristicas(c);

                    if (turno == arbol.ColorBlanco)
                    {
                        if (this.PiesasBlanco.Contains(c))
                            NuevoTAblero=MovimientoValido(TableroACtual, turno, new Point(j,i),c);
                    }
                    else
                    {
                        if (this.PiesasNegro.Contains(c))
                            NuevoTAblero = MovimientoValido(TableroACtual, turno,new Point(j, i),c);
                    }

                    if (NuevoTAblero != null)
                    {
                        nuevo.tablero = NuevoTAblero;
                        this.insertarNodoEn(nuevo, nodoActual);
                        
                    }
                }
            }

            // buscar al mejor movimiento del arbol
            nodo m = this.MejorEstado(nodoActual);
            Console.WriteLine("Despues del movimiento ");
            imprimirTablero(m.tablero);
            return m;
        }

        public char[,] MovimientoValido( char[,] TableroACtual, char turno, Point PuntoOrigen, char pieza )
        {
            char[,] t = null;
            switch (pieza)
            {
                case 'P' :
                case '6' :
                    t = MoverPeon(new int[] { PuntoOrigen.X, PuntoOrigen.Y }, TableroACtual, pieza);
                    break;

                case 'A':
                case '3':
                    t = MoverAlfl(new int[] { PuntoOrigen.X, PuntoOrigen.Y }, TableroACtual, pieza);
                    break;

                case 'T':
                case '1':
                    t = MoverTorr(new int[] { PuntoOrigen.X, PuntoOrigen.Y }, TableroACtual, pieza);
                    break;

                case 'R':
                case '4':
                    t = MoverRina(new int[] { PuntoOrigen.X, PuntoOrigen.Y }, TableroACtual, pieza);
                    break;
            }
            return t;
        }

        public char[,] MoverPeon( int[] posOrigen, char[,] tablero, char pieza )
        {
            char[,] t = null;

            // ver si se no se sale de las dimenciones del tablero
            if ( posOrigen[1] - 1 > 0 )
            {
                // ver si no esta ocupada la casilla 
                char c = tablero[ posOrigen[0], posOrigen[1]-1 ];

                if ( c == arbol.CasillaVacia )
                {
                    tablero[posOrigen[0], posOrigen[1]] = arbol.CasillaVacia;
                   // Console.WriteLine("Antes del movimiento ");
                    //imprimirTablero(tablero);
                    tablero[posOrigen[0], posOrigen[1] - 1] = pieza;
                   // Console.WriteLine("Despues del movimiento ");
                   // imprimirTablero(tablero);
                    t = tablero;
                    return t;

                }           
            }

            // ver si se no se sale de las dimenciones del tablero
            if ( posOrigen[1] + 1 < 8 )
            {
                // ver si no esta ocupada la casilla 
                char c = tablero[posOrigen[0], posOrigen[1] + 1];

                if (c == arbol.CasillaVacia)
                {
                    tablero[posOrigen[0], posOrigen[1]] = arbol.CasillaVacia;
                    //Console.WriteLine("Antes del movimiento ");
                   // imprimirTablero(tablero);
                    tablero[posOrigen[0], posOrigen[1] + 1] = pieza;
                  //  Console.WriteLine("Despues del movimiento ");
                  //  imprimirTablero(tablero);

                    t = tablero;
                    return t;
                }
            }

            return tablero;
        }

        public char[,] MoverTorr( int[] posOrigen, char[,] tablero, char pieza )
        {
            char[,] t = null;
            for (int i = posOrigen[0]; i < -posOrigen[0]+(8-1); i++)
            {
                
                    int c = tablero[i, posOrigen[1]];
                    if (c == arbol.CasillaVacia)
                    {
                        tablero[i, posOrigen[1]] = pieza;
                        tablero[posOrigen[0], posOrigen[1]] = arbol.CasillaVacia;
                        t = tablero;
                        return t;
                    }
                              
            }

            for (int i = posOrigen[0]; i > 0; i--)
            {
                
                    int c = tablero[i, posOrigen[1]];
                    if (c == arbol.CasillaVacia)
                    {
                        tablero[i, posOrigen[1]] = pieza;
                        tablero[posOrigen[0], posOrigen[1]] = arbol.CasillaVacia;
                        t = tablero;
                        return t;
                    }
                
            }



            for (int i = posOrigen[1]; i < -posOrigen[1] + (8-1) ; i++)
            {
                int c = tablero[posOrigen[0],i];
                if (c == arbol.CasillaVacia)
                {
                    tablero[ posOrigen[0],i] = pieza;
                    tablero[posOrigen[0], posOrigen[1]] = arbol.CasillaVacia;
                    t = tablero;
                    return t;
                }
            }

            for (int i = posOrigen[1]; i > 0; i--)
            {
                int c = tablero[ posOrigen[0],i];
                if (c == arbol.CasillaVacia)
                {
                    tablero[ posOrigen[0],i] = pieza;
                    tablero[posOrigen[0], posOrigen[1]] = arbol.CasillaVacia;
                    t = tablero;
                    return t;
                }
            }



            return tablero;
        }

        public char[,] MoverRina( int[] posOrigen, char[,] tablero, char pieza )
        {
            char[,] t = null;
            for (int i = 0; i < 8; i++)
            {
                int c = tablero[i, posOrigen[1]];
                if (c == arbol.CasillaVacia)
                {
                    tablero[i, posOrigen[1]] = pieza;
                    tablero[posOrigen[0], posOrigen[1]] = arbol.CasillaVacia;
                    t = tablero;
                    return t;
                }

                int c2 = tablero[posOrigen[0], i];
                if (c2 == arbol.CasillaVacia)
                {
                    tablero[posOrigen[0], i] = pieza;
                    tablero[posOrigen[0], posOrigen[1]] = arbol.CasillaVacia;
                    t = tablero;
                    return t;
                }

                int c3 = tablero[i, posOrigen[1]];
                if (c3 == arbol.CasillaVacia)
                {
                    tablero[i, i] = pieza;
                    tablero[posOrigen[0], posOrigen[1]] = arbol.CasillaVacia;
                    t = tablero;
                    return t;
                }

                int c4 = tablero[posOrigen[0], i];
                if (c4 == arbol.CasillaVacia)
                {
                    tablero[7-i, i] = pieza;
                    tablero[posOrigen[0], posOrigen[1]] = arbol.CasillaVacia;
                    t = tablero;
                    return t;
                }
            }
            return tablero;
        }

        public char[,] MoverAlfl( int[] posOrigen, char[,] tablero, char pieza )
        {
            char[,] t = null;
            for (int i = 0; i < 8; i++)
            {
                int c3 = tablero[i, posOrigen[1]];
                if (c3 == arbol.CasillaVacia)
                {
                    tablero[i, i] = pieza;
                    tablero[posOrigen[0], posOrigen[1]] = arbol.CasillaVacia;
                    t = tablero;
                    return t;
                }

                int c4 = tablero[posOrigen[0], i];
                if (c4 == arbol.CasillaVacia)
                {
                    tablero[7 - i, i] = pieza;
                    tablero[posOrigen[0], posOrigen[1]] = arbol.CasillaVacia;
                    t = tablero;
                    return t;
                }
            }
            return tablero;
        }

        public void imprimirTablero ( char [,]tab)
        {
            for ( int i = 0; i < 8; i ++ )
            {
                for ( int j = 0; j < 8; j ++)
                {
                    Console.Write(tab[j, i]+ " ");
                }
                Console.WriteLine(" ");
            }
        }

        public char[,] copiarTablero ( char [,]tab)
        {
            char[,] nt = new char[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    nt[j, i] = tab[j, i];
            return nt;
        }

    }
}
