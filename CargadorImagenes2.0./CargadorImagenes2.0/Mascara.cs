using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargadorImagenes2._0
{
    public class Mascara
    {
        public double[,] MascaraNumerica;
        public Size Dims;
        public Point Centro;

        public static double[,] PRDF_Msk_Enfkr = { {0,-1, 0}, { -1, 5 , -1 }, { 0, -1, 0 } } ;
        public static double[,] PRDF_Msk_Dsfkr = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

        public static double[,] PRDF_Msk_Rbrds = { { 0, 0, 0 }, { -1, 1, 0 }, { 0, 0, 0 } };
        public static double[,] PRDF_Msk_DBrds = { { 0, -1, 0 }, { -1, 4, -1 }, { 0, -1, 0 } };

        public static double[,] PRDF_Msk_Rpgdo = { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };
        public static double[,] PRDF_Msk_ABrds = { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
        public static double[,] PRDF_Msk_DaBds = { { -1, -1, -1 }, { -1, 17, -1 }, { -1, -1, -1 } };
        public static double[,] PRDF_Msk_Rliev = { { -2, 0, 0 }, { 0, 1, 0 }, { 0, 0, 2 } };

        public static double[,] PRDF_Opdr_SblX = { { -1, 0, 1 }, { -2, 0, 2}, { -1, 0, 1} };
        public static double[,] PRDF_Opdr_SblY = { { -1, -2, -1 }, { 0, 0, 0 }, { 1,2, 1 } };

        public static double[,] PRDF_Opdr_RbrX = { { -1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
        public static double[,] PRDF_Opdr_RbrY = { { 0, 0,  0}, { 0, 1, -1 }, { 0, 0, 0 } };

        public static double[,] PRDF_Opdr_PrwX = { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
        public static double[,] PRDF_Opdr_PrwY = { { 1, 1, 1 }, { 0, 0, 0 }, { -1, -1, -1} };

        public static double[,] PRDF_Opdr_LPcX = { { 0, 0, 0 }, { 1, -2, 1 }, { 0, 0, 0 } };
        public static double[,] PRDF_Opdr_LpcY = { { 0, 1, 0 }, { 0, -2, 0 }, { 0, 1, 0 } };

        public static double[,] PRDF_Opdr_FrcX = { { 1, 0, -1 }, { Math.Sqrt(2), 0, -Math.Sqrt(2) }, { 1, 0, -1 } };
        public static double[,] PRDF_Opdr_FrcY = { { -1, -Math.Sqrt(2), -1 }, { 0, 0, 0 }, { 1, Math.Sqrt(2), 1 } };


        public Mascara () { }

        public Mascara ( double [,] ValoresEntrada ,  Size DimsEntrada, Point CentroEntrada )
        {
            MascaraNumerica = new double[DimsEntrada.Width, DimsEntrada.Height];

            this.Dims = DimsEntrada;
            this.Centro = CentroEntrada;


            /// copiar valores a la matriz interna 
            for (int i = 0; i < DimsEntrada.Height; i++)
                for (int j = 0; j < DimsEntrada.Width; j++)
                    this.MascaraNumerica[j, i] = ValoresEntrada[j, i];
        }

     
    }
}
