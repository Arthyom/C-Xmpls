using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaProfundidad
{
    class Estado
    {
        public char[] CosasLadoIzq;
        public char[] CosasLadoDer;
        public Estado[] EstadosHijos;
        public Estado EstadoPadre;
        public bool LadoIzq;
        public bool LadoDer;
        public bool EstadoVisitado;


        // constructor por defecto
        public Estado()
        {

             char[] CosasLadoIzq = { 'H', 'M', 'V', 'P' };
             char[] CosasLadoDer = { 'H', 'M', 'V', 'P' };

            this.EstadoVisitado = false;
            this.LadoDer = false;
            this.LadoIzq = false;
            this.EstadoPadre = null;
            this.EstadosHijos = null;
        }

        public void CambiarEstado ()
        {
           // cambiar el estado del estado que invoco al metodo
           if ( this.LadoDer)
            {
                this.LadoDer = false;
                this.LadoIzq = true;
            }
            else
            {
                this.LadoIzq = false;
                this.LadoDer = true;
            }
        }

        // construir un nuevo estado a partir de otro
        public static Estado CopiarEstado ( Estado EstadoPadre)
        {
            Estado EstadoCopia = new Estado();
            EstadoCopia.EstadoVisitado = EstadoPadre.EstadoVisitado;
            EstadoCopia.LadoDer = EstadoPadre.LadoDer;
            EstadoCopia.LadoIzq = EstadoPadre.LadoIzq;

            char[] arcDer = new char[4];
            char[] arcIzq = new char[4];

            for (int i = 0; i < EstadoPadre.CosasLadoDer.Length; i++)
                arcDer[i] = EstadoPadre.CosasLadoDer[i];

            for (int i = 0; i < EstadoPadre.CosasLadoDer.Length; i++)
                arcIzq[i] = EstadoPadre.CosasLadoIzq[i];

            EstadoCopia.CosasLadoDer = arcDer;
            EstadoCopia.CosasLadoIzq = arcIzq;

            return EstadoCopia;     
        }

        // construir un nuevo estado, moviendo a homero solo al lado indicado
        public static Estado CrearEstadoSimplo(char Homero, Estado EstadoPadre)
        {
            Estado NuevoEstado = Estado.CopiarEstado(EstadoPadre);

            // verificar de que lado esta el estado padre
            if ( EstadoPadre.LadoDer )
            {
                
                // mover a homero al lado izquiero
                NuevoEstado.CosasLadoIzq[0] = 'H';
                NuevoEstado.CosasLadoDer[0] = '0';
                NuevoEstado.CambiarEstado();
            }
            else
            {
                // mover a homero al lado derecho
                NuevoEstado.CosasLadoIzq[0] = '0';
                NuevoEstado.CosasLadoDer[0] = 'H';
                NuevoEstado.CambiarEstado();

            }
            return NuevoEstado;
        }

        // mover una pieza, la barca y a homero del lado adecuado
        public static Estado GenerarNuevoEstado(Estado EstadoPadre, char Homero, int ObjetoMover)
        {
            Estado EstadoCopia = Estado.CopiarEstado(EstadoPadre);

            // mover a homero junto con algun obejto y la barca al aldo contrario
            if (EstadoPadre.LadoDer)
            {
                // mover a homero
                EstadoCopia.CosasLadoDer[0] = '0';
                EstadoCopia.CosasLadoIzq[0] = 'H';

                // mover alguna de las cosas de lado derecho al izquierdo
                if(EstadoCopia.CosasLadoDer[ObjetoMover] != '0')
                {
                    EstadoCopia.CosasLadoIzq[ObjetoMover] = EstadoCopia.CosasLadoDer[ObjetoMover];
                    EstadoCopia.CosasLadoDer[ObjetoMover] = '0';
                }
                else
                    return null;
                

                // cambiar la bandera del estado
                EstadoCopia.CambiarEstado();
            }
            else
            {
                // mover a homero
                EstadoCopia.CosasLadoDer[0] = 'H';
                EstadoCopia.CosasLadoIzq[0] = '0';

                // mover alguna de las cosas de lado izquierdo al derecho
                // mover alguna de las cosas de lado derecho al izquierdo
                if (EstadoCopia.CosasLadoIzq[ObjetoMover] != '0')
                {
                    EstadoCopia.CosasLadoDer[ObjetoMover] = EstadoCopia.CosasLadoIzq[ObjetoMover];
                    EstadoCopia.CosasLadoIzq[ObjetoMover] = '0';
                }
                else
                    return null;


                // cambiar la bandera del estado
                EstadoCopia.CambiarEstado();

            }

            return EstadoCopia;
        }

        // conectar al estado padre con los estado hijos 
        public void ConectarEstados ( Estado [] EstadosHijos)
        {
            // conectar al padre con sus hijos 
            this.EstadosHijos = EstadosHijos;

            // conectar al cada uno de los hijos con su padre
            for (int i = 0; i < EstadosHijos.Length; i++)
                if(EstadosHijos[i] != null)
                    EstadosHijos[i].EstadoPadre = this;
                
        }

        public void VisitarNodo()
        {
            this.EstadoVisitado = true;
        }

    }
}
