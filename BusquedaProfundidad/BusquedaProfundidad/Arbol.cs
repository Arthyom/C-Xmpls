using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BusquedaProfundidad
{
    class Arbol
    {
       public int Dims;
       public Estado Raiz;

        public Queue ColaUsados;
        public Stack PilaSuc;

        public Arbol()
        {
            this.Dims = 0;
            this.Raiz = null;
            this.ColaUsados = new Queue();
            this.PilaSuc = new Stack();
        }

        public void InsertarRaiz ( Estado Raiz)
        {
            this.Raiz = Raiz;
            this.PilaSuc.Push(Raiz);
        }

        // sobre cargar el operador ==
        public  bool Comparar ( Estado EstadoEntrada, Estado EstadoFinal )
        {
            int cosas = 0;
            // comparar 
            if (EstadoEntrada.LadoDer == EstadoFinal.LadoDer && EstadoEntrada.LadoIzq == EstadoFinal.LadoIzq)
            {
                for(int i = 0; i < EstadoFinal.CosasLadoDer.Length; i ++)
                {
                    if (EstadoFinal.CosasLadoDer[i] == EstadoEntrada.CosasLadoDer[i] && EstadoFinal.CosasLadoIzq[i] == EstadoEntrada.CosasLadoIzq[i])
                        cosas++;
                }

                if (cosas == EstadoFinal.CosasLadoIzq.Length)
                    return true;
            }

            return false;

        }
        /*
        public static bool operator != ( Estado EstadoEntrada, Estado EstadoFinal ) 
        
            int cosas = 0;
            // comparar 
            if (EstadoEntrada.LadoDer != EstadoFinal.LadoDer && EstadoEntrada.LadoIzq != EstadoFinal.LadoIzq)
            {
                for (int i = 0; i < EstadoFinal.CosasLadoDer.Length; i++)
                {
                    if (EstadoFinal.CosasLadoDer[i] != EstadoEntrada.CosasLadoDer[i] && EstadoFinal.CosasLadoIzq[i] != EstadoEntrada.CosasLadoIzq[i])
                        cosas++;
                }

                if (cosas != EstadoFinal.CosasLadoIzq.Length)
                    return true;
            }

            return false;
        }
        */

        // generar estados sucesores a partir del estado padre 
        public void GenerarSucesores ( Estado EstadoPadre)
        {

            // identificar de que lado esta el estado padre
            Estado[] EstadosHijos = new Estado[4];



            if (EstadoPadre.LadoDer)
            {
                EstadosHijos[0] = Estado.CrearEstadoSimplo('H', EstadoPadre);
                // pasar al nuevo estado al lado izquierdo 
                for (int i = 1; i < EstadosHijos.Length; i++)
                {
                    // crear un nuevo Estado a partir del estado padre
                    EstadosHijos[i] = Estado.GenerarNuevoEstado(EstadoPadre, 'H', i );


                }
            }
            else
            {
                EstadosHijos[0] =  Estado.CrearEstadoSimplo('H', EstadoPadre);
                // pasar al nuevo estado al lado derecho 
                for (int i = 1; i < EstadosHijos.Length; i++)
                {
                    // crear un nuevo Estado a partir del estado padre
                    EstadosHijos[i] = Estado.GenerarNuevoEstado(EstadoPadre, 'H', i );


                }

            }

            // conectar al padre con los hijos y a los hijos con su padre
            EstadoPadre.ConectarEstados(EstadosHijos);

            // agregar los nodos generados a la pila de sucesores 
            foreach (Estado estHijo in EstadosHijos)
            {
                this.PilaSuc.Push(estHijo);
                this.Dims += 1;

            }      
        }

        // ver si el estado extraido ya fue usado
        public bool BuscarEstadoUsado ( Estado EstadoExtraido)
        {
            
            if (ColaUsados.Count == 0)
                return false;

            // COMPARAR ESTADOS CON EL ESTADO EXTRAIDO
            foreach (Estado E in this.ColaUsados)
            {
                string cadDer = new string(E.CosasLadoDer);
                string cadIzq = new string(E.CosasLadoIzq);

                if ( cadDer.CompareTo( new string(EstadoExtraido.CosasLadoDer)) == 0&& cadIzq.CompareTo(new string(EstadoExtraido.CosasLadoIzq)) ==0)
                {
                    if (E.LadoDer == EstadoExtraido.LadoDer && E.LadoIzq == EstadoExtraido.LadoIzq)
                        return true;
                }
            }

          
            return false;
        }

        // meter a la cola de usados
        public void EncolarEstado ( Estado EstadoGenerado)
        {
            this.ColaUsados.Enqueue(EstadoGenerado);
        }

        public bool Reglas ( Estado EstadoExtraido)
        {

     
            int peligroD = 0, cuentaD = 0;
            int peligroI = 0, cuentaI = 0;

            // VER SI HOMERO ESTA DE UN LADO
            if (!EstadoExtraido.CosasLadoIzq.Contains('H'))
            {
                // ver si el lado esta vacio
                foreach (char c in EstadoExtraido.CosasLadoIzq)
                    if (c == '0')
                        cuentaI += 1;
                if (cuentaI == EstadoExtraido.CosasLadoIzq.Length)
                    peligroI = 0;
                else
                {
                    // si homero no esta y no esta vacio, estan magui, el perro o el veneno
                    if (EstadoExtraido.CosasLadoIzq.Contains('M'))
                    {
                        foreach (char c in EstadoExtraido.CosasLadoIzq)
                            if (c == 'P' || c == 'V')
                                peligroI += 1;
                    }
                    else
                        peligroI = 0;

                        
                }
               

            }
            else
                peligroI = 0;

            // VER SI HOMERO ESTA DE UN LADO
            if (!EstadoExtraido.CosasLadoDer.Contains('H'))
            {
                // ver si el lado esta vacio
                foreach (char c in EstadoExtraido.CosasLadoDer)
                    if (c == '0')
                        cuentaD += 1;
                if (cuentaD == EstadoExtraido.CosasLadoDer.Length)
                    peligroD = 0;
                else
                {
                    // si homero no esta y no esta vacio, estan magui, el perro o el veneno
                    if (EstadoExtraido.CosasLadoDer.Contains('M'))
                    {
                        foreach (char c in EstadoExtraido.CosasLadoDer)
                            if (c == 'P' || c == 'V')
                                peligroD += 1;
                    }
                    else
                        peligroD = 0;

                }
            }
            else
                peligroD = 0;

            if (peligroD == 0 && peligroI == 0)
                return true;

            return false;
        }

    }
}
