using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargadorImagenes2._0
{
    public class PictureAnalizer
    {

        public static Bitmap ImagenSalida;
        public static Bitmap ImagenEntrada;

        public static string RutaImagenEntrada;
        public static string RutaImagenSalida;

        public int[] HistogramaEntrada = new int[256];
        public double[] HistEntradaNorm = new double[256];

        public int [] HistogramaSalida = new int[256];
        public double[] HistSalidaNorm = new double[256];

        public Mascara MascaraActual; 



        public PictureAnalizer()
        {

        }

        public PictureAnalizer(Bitmap ImagenColor, Bitmap ImagenGray)
        {
            PictureAnalizer.ImagenEntrada = ImagenColor;
            PictureAnalizer.ImagenSalida  = ImagenGray;
        }



        public static Bitmap ImagenColor2Gray ( Bitmap ImagenColor )
        {
            Bitmap ImagenGray= new Bitmap(ImagenColor.Width, ImagenColor.Height);

            for ( int i = 0; i < ImagenColor.Height; i ++ )
            {
                for ( int j = 0; j < ImagenColor.Width; j ++ )
                {
                    int c = PictureAnalizer.PixelColor2Gray(ImagenColor.GetPixel(j, i));
                    ImagenGray.SetPixel(j, i, Color.FromArgb(c, c, c));
                }
            }
            return ImagenGray;
        }

        public static int PixelColor2Gray(Color c)
        {
            int cs = (int)((c.R * 0.30) + (c.G * 0.59) + (c.B * 0.11));
            return cs;
        }

        public static int [] Histograma ( Bitmap ImagenEntradaGray )
        {
            int[] hist = new int[256];

            for ( int i = 0; i < ImagenEntradaGray.Height; i ++ )
            {
                for ( int j = 0; j < ImagenEntradaGray.Width; j ++ )
                {
                    int color = PictureAnalizer.PixelColor2Gray(ImagenEntradaGray.GetPixel(j, i));
                    hist[color] += 1;
                }
            }

            return hist;
        }

        public static double [] HistogramaNormal (Bitmap ImagenColor, int [] hist )
        {
            double [] HistNorm = new double[256];
            for (int i = 0; i < 256; i++)
                HistNorm[i] = hist[i]/((double)ImagenColor.Width * ImagenColor.Height);

            return HistNorm;
        }

        public static int [] HistogramaAcumulado ( int [] hist )
        {
            int[] Hacum = new int[256];

            for (int i = 1; i < 256; i++)
                Hacum[i] = Hacum[i - 1] + hist[i];

            return Hacum;
        }

        public static int Otsu ( double [] HistoNormal )
        {
            int mejorK = 0;
            double bestK = 0;

            for ( int k = 0; k < 256; k ++)
            {
                double km = 0, w0 = 0, w1 = 0, m0 = 0, m1 = 0;

                // calcular w's 
                for (int i = 1; i < k + 1; i++)
                    w0 += HistoNormal[i];

                for (int i = k+1; i < HistoNormal.Length - 1; i++)
                    w1 += HistoNormal[i];

                // calcular m's 
                for (int i = 1; i < k + 1; i++)
                    m0 += i * HistoNormal[i]/w0;

                for (int i = k + 1; i < HistoNormal.Length - 1; i++)
                    m1 += i * HistoNormal[i]/w1;


                km = w0 * w1 * (Math.Pow(m1 - m0, 2));

                if ( km > bestK )
                {
                    bestK = km;
                    mejorK = k;
                }
            }

            return mejorK;
        }

        public static Bitmap Umbralizar ( Bitmap ImagenEntradaNonUmbral, int umbral )
        {
            Bitmap ImagenUmbralizada = new Bitmap(ImagenEntradaNonUmbral.Width, ImagenEntradaNonUmbral.Height);

            int t = umbral;

            for ( int i = 0; i < ImagenUmbralizada.Height; i++ )
            {
                for ( int j = 0; j < ImagenUmbralizada.Width; j ++ )
                {
                    int c = PixelColor2Gray(ImagenEntradaNonUmbral.GetPixel(j, i));

                    if (c > t)
                        ImagenUmbralizada.SetPixel(j, i, Color.White);
                    else
                        ImagenUmbralizada.SetPixel(j, i, Color.Black);
                }
            }

            return ImagenUmbralizada;
        }

        public static List<Point> PuntosInteres ( Bitmap ImagenEntrada, int c )
        {
            List<Point> lisp = new List<Point>();
            for (int i = 0; i < ImagenEntrada.Height; i++)
            {
                for (int j = 0; j < ImagenEntrada.Width; j++)
                {
                    int C = PictureAnalizer.PixelColor2Gray( ImagenEntrada.GetPixel(j, i) );
                    if (c == C)
                    {
                        Point p = new Point(j, i);
                        lisp.Add(p);
                    }
                }
            }
            return lisp;
        }

        public static Bitmap DilatarImagen    ( Bitmap ImagenNoDilatada, Mascara EEstructurante, int ColorPixel )
        {
            Bitmap ImagenDilatada = PictureAnalizer.DibujarNegra(ImagenNoDilatada.Width + EEstructurante.Dims.Height, ImagenNoDilatada.Height + EEstructurante.Dims.Width);
            List<Point> listaPuntos = PictureAnalizer.PuntosInteres(ImagenNoDilatada, 255 );

            foreach (Point p in listaPuntos)
                PictureAnalizer.CopiarMascaraEn(p.X, p.Y, EEstructurante, ImagenDilatada);

            return ImagenDilatada;
        }

        public static Bitmap ErocionarImagen (Bitmap ImagenNoDilatada, Mascara EEstructurante, int ColorPixel)
        {
            Bitmap ImagenErocionada = PictureAnalizer.DibujarNegra(ImagenNoDilatada.Width + EEstructurante.Dims.Height, ImagenNoDilatada.Height + EEstructurante.Dims.Width);
            List<Point> listaPuntos = PictureAnalizer.PuntosInteres(ImagenNoDilatada, 255);

            foreach (Point p in listaPuntos)
                PictureAnalizer.CortarMascarEn(p.X, p.Y, EEstructurante, ImagenErocionada, ImagenNoDilatada);

            return ImagenErocionada;
        }

        public static Bitmap Resta(Bitmap ImagenA, Bitmap ImagenB)
        {
            Bitmap c = PictureAnalizer.DibujarNegra(ImagenA.Width, ImagenA.Height);

            for (int i = 0; i < ImagenB.Height; i++)
            {
                for (int j = 0; j < ImagenB.Width; j++)
                {
                    Color n = ImagenA.GetPixel(j,i);
                    Color m = ImagenB.GetPixel(j,i);

                    if ( m != n )
                    {
                         c.SetPixel(j, i, n);
                    }
                }
            }
            return c;
        }


        public void SetImagenEntrada ( Bitmap ImagenEntrada )
        {
            PictureAnalizer.ImagenEntrada = ImagenEntrada;
        }

        public void SetImagenSalida ( Bitmap ImagenSalida )
        {
            PictureAnalizer.ImagenSalida = ImagenSalida;
        }

        public static void GuardarImagenSalida ( Bitmap im, string rutaGuardado )
        {
            im.Save(rutaGuardado);
        }

        public static void CopiarMascaraEn ( int posX, int posY, Mascara Eestruct , Bitmap ImagenDilatada )
        {

            for ( int iMzk = 0, iImg = posY-((Eestruct.Dims.Height-1)/2); iMzk < Eestruct.Dims.Height; iMzk++, iImg++  )
            {
                for (int jMzk = 0, jImg = posX - ((Eestruct.Dims.Width - 1) / 2); jMzk < Eestruct.Dims.Width; jMzk++, jImg++)
                {      
                    if (iImg < ImagenDilatada.Height && jImg < ImagenDilatada.Width)
                        ImagenDilatada.SetPixel( Math.Abs( jImg), Math.Abs( iImg), Color.White);
                }

            }
        }

        public static void CortarMascarEn(int posX, int posY, Mascara Eestruct, Bitmap ImagenDilatada, Bitmap ImagenOriginal)
        {
            int dim = 0;
            for (int iMzk = 0, iImg = posY - ((Eestruct.Dims.Height - 1) / 2); iMzk < Eestruct.Dims.Height; iMzk++, iImg++)
            {
                for (int jMzk = 0, jImg = posX - ((Eestruct.Dims.Width - 1) / 2); jMzk < Eestruct.Dims.Width; jMzk++, jImg++)
                {
                    if ( iImg < ImagenOriginal.Height && jImg < ImagenOriginal.Width )
                    {
                        int c = PixelColor2Gray(ImagenOriginal.GetPixel(Math.Abs(jImg), Math.Abs(iImg)));

                        if (c == 255)
                            dim++;
                    }
                }
            }
            if ( dim == (Eestruct.Dims.Width * Eestruct.Dims.Width)) 
                ImagenDilatada.SetPixel(posX, posY, Color.White);
        }

        public static void FiltrarEn(int posX, int posY, Mascara MascaraFiltro, Bitmap ImageSinFiltro, Bitmap ImagenFiltrada)
        {
            double[] prom = new double[MascaraFiltro.Dims.Width * MascaraFiltro.Dims.Height];

            int k = 0;
            double p = 0;
            for (int iMzk = 0, iImg = posY - ((MascaraFiltro.Dims.Height - 1) / 2); iMzk < MascaraFiltro.Dims.Height; iMzk++, iImg++)
            {
                for (int jMzk = 0, jImg = posX - ((MascaraFiltro.Dims.Width - 1) / 2); jMzk < MascaraFiltro.Dims.Width; jMzk++, jImg++)
                {
                    if ( (iImg < ImageSinFiltro.Height && jImg < ImageSinFiltro.Width)  && (iImg >= 0 && jImg >= 0 ) )
                    {
                        int c =  PictureAnalizer.PixelColor2Gray(ImageSinFiltro.GetPixel(jImg, iImg));
                        double cm = MascaraFiltro.MascaraNumerica[jMzk, iMzk];
                        MascaraFiltro.MascaraNumerica[jMzk, iMzk] = c * cm;
                        prom[k] = MascaraFiltro.MascaraNumerica[jMzk, iMzk];
                        p += prom[k];
                    }
                }
            }

            int t = (int)p / prom.Length;
            if (t < 0)
                t = Math.Abs(t);
            else
                if (t > 255)
                t = 255;

            ImagenFiltrada.SetPixel(posX, posY, Color.FromArgb( t,t,t));
        }

        public static void DetectarBordeEn(int posX, int posY, Mascara MascaraFiltro, Bitmap ImageSinFiltro, Bitmap ImagenFiltrada)
        {
            double[] prom = new double[MascaraFiltro.Dims.Width * MascaraFiltro.Dims.Height];

            int k = 0;
            double p = 0;
            for (int iMzk = 0, iImg = posY - ((MascaraFiltro.Dims.Height - 1) / 2); iMzk < MascaraFiltro.Dims.Height; iMzk++, iImg++)
            {
                for (int jMzk = 0, jImg = posX - ((MascaraFiltro.Dims.Width - 1) / 2); jMzk < MascaraFiltro.Dims.Width; jMzk++, jImg++)
                {
                    if ((iImg < ImageSinFiltro.Height && jImg < ImageSinFiltro.Width) && (iImg >= 0 && jImg >= 0))
                    {
                        int c = PictureAnalizer.PixelColor2Gray(ImageSinFiltro.GetPixel(jImg, iImg));
                        double cm = MascaraFiltro.MascaraNumerica[jMzk, iMzk];
                        MascaraFiltro.MascaraNumerica[jMzk, iMzk] = c * cm;
                        prom[k] = MascaraFiltro.MascaraNumerica[jMzk, iMzk];
                        p += prom[k];
                        
                    }
                }
            }

            int t = (int)p;

            if (t > 255)
                t = 225;
            else
                if (t < 0)
                t = 0;
             
            ImagenFiltrada.SetPixel(posX, posY, Color.FromArgb(t, t, t));
        }

        public static int ValorMascara(int posX, int posY, Mascara MascaraFiltro, Bitmap ImageSinFiltro, Bitmap ImagenFiltrada)
        {
            double[] prom = new double[MascaraFiltro.Dims.Width * MascaraFiltro.Dims.Height];

            int k = 0;
            double p = 0;
            for (int iMzk = 0, iImg = posY - ((MascaraFiltro.Dims.Height - 1) / 2); iMzk < MascaraFiltro.Dims.Height; iMzk++, iImg++)
            {
                for (int jMzk = 0, jImg = posX - ((MascaraFiltro.Dims.Width - 1) / 2); jMzk < MascaraFiltro.Dims.Width; jMzk++, jImg++)
                {
                    if ((iImg < ImageSinFiltro.Height && jImg < ImageSinFiltro.Width) && (iImg >= 0 && jImg >= 0))
                    {
                        int c = PictureAnalizer.PixelColor2Gray(ImageSinFiltro.GetPixel(jImg, iImg));
                        double cm = MascaraFiltro.MascaraNumerica[jMzk, iMzk];
                        MascaraFiltro.MascaraNumerica[jMzk, iMzk] = c * cm;
                        prom[k] = MascaraFiltro.MascaraNumerica[jMzk, iMzk];
                        p += prom[k];

                    }
                }
            }

            int t = (int)p;

            if (t > 255)
                t = 225;
            else
                if (t < 0)
                t = 0;

            return t;
        }

        public static Bitmap DibujarNegra (int dimX, int dimY )
        {
            Bitmap img = new Bitmap(dimX, dimY);

            for (int i = 0; i < img.Height; i++)
                for (int j = 0; j < img.Width; j++)
                    img.SetPixel(j, i, Color.Black);

            return img;
        }

        public static Bitmap DibujarCuadradoEn (int DimX, int DimY, int dimX, int dimY, Point inicio, Color c )
        {
            Bitmap img = PictureAnalizer.DibujarNegra(DimX, DimY);
            for ( int i = inicio.Y; i < dimY; i ++ )
                for (int j = inicio.X; j < dimX ; j++)
                    if (i < img.Height && j < img.Width)
                        img.SetPixel(j, i, c);

            return img;
        }

        public static Bitmap Cerradura ( Bitmap ImagenOriginal, Mascara MascaraEnviada)
        {
           Bitmap im = PictureAnalizer.ErocionarImagen( PictureAnalizer.DilatarImagen( ImagenOriginal, MascaraEnviada, 255), MascaraEnviada, 255);
            return im;
        }

        public static Bitmap Apertura(Bitmap ImagenOriginal, Mascara MascaraEnviada)
        {
            Bitmap im = PictureAnalizer.DilatarImagen(PictureAnalizer.ErocionarImagen(ImagenOriginal, MascaraEnviada, 255), MascaraEnviada, 255);
            return im;
        }

        public static Bitmap ExtBorde(Bitmap ImagenOriginal, Mascara MascaraEnviada)
        {
            Bitmap n = PictureAnalizer.DilatarImagen(ImagenOriginal, MascaraEnviada, 255);
            return  PictureAnalizer.Resta( n, ImagenOriginal);
        }

        public static Bitmap BuscarImagen ( )
        {
            // conseguir las rutas 
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
            string r = f.FileName;

            if (r != null)
            {
                PictureAnalizer.RutaImagenEntrada = r;
                PictureAnalizer.ImagenEntrada = new Bitmap(r);
                PictureAnalizer.ImagenSalida = PictureAnalizer.ImagenColor2Gray(PictureAnalizer.ImagenEntrada);
                return PictureAnalizer.ImagenEntrada;
            }
            else
                return new Bitmap(0, 0);
        }

        public static Bitmap SuavisarImagen ( Mascara mascaraEntrada )
        {
            Bitmap mResultado =   PictureAnalizer.DibujarNegra ( PictureAnalizer.ImagenEntrada.Width, PictureAnalizer.ImagenSalida.Height);

            for ( int i = 0; i < mResultado.Height; i ++ )
                for ( int j = 0; j < mResultado.Width; j ++ )
                    PictureAnalizer.FiltrarEn(j, i, new Mascara( mascaraEntrada.MascaraNumerica, mascaraEntrada.Dims, mascaraEntrada.Centro) , PictureAnalizer.ImagenEntrada, mResultado);

            return mResultado;
        }

        public static int NormalizarPixel ( int P )
        {
            if (P > 255)
                P = 255;
            else
                if (P < 0)
                P = 0;
            return P;
        }


        public static Bitmap DetectarBordes(Mascara mascaraEntradaX, Mascara mascaraEntradaY, int tipo)
        {
            Bitmap mResultadoX = PictureAnalizer.DibujarNegra(PictureAnalizer.ImagenEntrada.Width, PictureAnalizer.ImagenSalida.Height);
            Bitmap mResultadoY = PictureAnalizer.DibujarNegra(PictureAnalizer.ImagenEntrada.Width, PictureAnalizer.ImagenSalida.Height);

            Bitmap mResultadoGradZ = PictureAnalizer.DibujarNegra(PictureAnalizer.ImagenEntrada.Width, PictureAnalizer.ImagenSalida.Height);

            for (int i = 0; i < PictureAnalizer.ImagenSalida.Height; i++)
            {
                for (int j = 0; j < PictureAnalizer.ImagenSalida.Width; j++)
                {
                    int x = 0, y = 0, z = 0;

                    y = PictureAnalizer.ValorMascara(j, i, new Mascara(mascaraEntradaY.MascaraNumerica, mascaraEntradaY.Dims, mascaraEntradaY.Centro), PictureAnalizer.ImagenEntrada, mResultadoY);
                    mResultadoY.SetPixel(j, i, Color.FromArgb(y, y, y));

                    x = PictureAnalizer.ValorMascara(j, i, new Mascara(mascaraEntradaX.MascaraNumerica, mascaraEntradaX.Dims, mascaraEntradaX.Centro), PictureAnalizer.ImagenEntrada, mResultadoX);
                    mResultadoX.SetPixel(j, i, Color.FromArgb(x, x, x));

                    z = PictureAnalizer.NormalizarPixel(Math.Abs(x) + Math.Abs(y));
                    mResultadoGradZ.SetPixel( j, i, Color.FromArgb(z,z,z) );
                }
            }

            switch ( tipo )
            {
                case -1: return mResultadoY;
                case  1: return mResultadoX;
                case  0: return mResultadoGradZ;
            }

            return mResultadoGradZ;
        }

    }
}
