using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CargadorImagenes2._0
{
    class nodo
    {
        public string          nombreNodo;
        public double          valor;
        public List<nodo>      nodosHijos;
        public nodo            nodoPadre;
        public char[,]         tablero;
        public bool            visitado;

        public      nodo()
        {
              this.nodosHijos = new List<nodo>();
        }

        public      nodo                    ( int dimsTablero, string nombreNodo )
        {
            this.tablero = new char[dimsTablero, dimsTablero];
            this.nodoPadre = new nodo();
            this.nodosHijos = new List<nodo>();
            this.nombreNodo = nombreNodo;
        }

        public void conectarNodosHijos      ( nodo  nodosHijos )
        {
            this.nodosHijos.Add(nodosHijos);
        }

        public void conectarPadre           ( nodo nodoPadre )
        {
            this.nodoPadre = nodoPadre;
        }


        public void VisitarNodo             ( )
        {
            Console.WriteLine               ( this.nombreNodo );
        }

    }
}
