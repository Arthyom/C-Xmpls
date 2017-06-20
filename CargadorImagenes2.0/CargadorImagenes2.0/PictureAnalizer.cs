using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace CargadorImagenes2._0
{
    public class PictureAnalizer
    {

        public static Bitmap ImagenSalida;
        public static Bitmap ImagenEntrada;
        public static Mascara AcumuladorGeneral;

        public static string RutaImagenEntrada;
        public static string RutaImagenSalida;

        public int[] HistogramaEntrada = new int[256];
        public double[] HistEntradaNorm = new double[256];

        public int [] HistogramaSalida = new int[256];
        public double[] HistSalidaNorm = new double[256];

        public static Dictionary<int, double>[] HNormSumasDifecs;

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


        public static Bitmap CambiarBrillo ( Bitmap ImagenSinBrillo, double brillo)
        {
            Bitmap n = PictureAnalizer.DibujarNegra(ImagenSinBrillo.Width, ImagenSinBrillo.Height);

            for ( int i = 0;  i< n.Height; i ++ )
            {
                for ( int j = 0; j < n.Width; j ++ )
                {
                    Color c = ImagenSinBrillo.GetPixel(j, i);
                    int ViejoC = PictureAnalizer.PixelColor2Gray(c);
                    int NuevoC = PictureAnalizer.NormalizarPixel( ViejoC + Convert.ToInt32(brillo) );
                    n.SetPixel(j, i, Color.FromArgb(NuevoC, NuevoC, NuevoC));
                }
            }

            return n;
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

        public static double [] HistogramaNormal (Bitmap ImagenColor )
        {
            int[] h = PictureAnalizer.Histograma(ImagenColor);
            double [] HistNorm = new double[256];
            for (int i = 0; i < 256; i++)
                HistNorm[i] = h[i]/((double)ImagenColor.Width * ImagenColor.Height);

            return HistNorm;
        }

        public static int [] HistogramaAcumulado ( Bitmap input )
        {
            int [] h = PictureAnalizer.Histograma(input);

            int[] Hacum = new int[256];

            for (int i = 1; i < 256; i++)
                Hacum[i] = Hacum[i - 1] + h[i];

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
            Bitmap ImagenDilatada = PictureAnalizer.DibujarNegra(ImagenNoDilatada.Width , ImagenNoDilatada.Height );
            List<Point> listaPuntos = PictureAnalizer.PuntosInteres(ImagenNoDilatada, ColorPixel );

            foreach (Point p in listaPuntos)
                PictureAnalizer.CopiarMascaraEn(p.X, p.Y, EEstructurante, ImagenDilatada);

            return ImagenDilatada;
        }

        public static Bitmap ErocionarImagen (Bitmap ImagenNoDilatada, Mascara EEstructurante, int ColorPixel)
        {
            Bitmap ImagenErocionada = PictureAnalizer.DibujarNegra(ImagenNoDilatada.Width , ImagenNoDilatada.Height );
            List<Point> listaPuntos = PictureAnalizer.PuntosInteres(ImagenNoDilatada, ColorPixel);

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

        public static Bitmap Cerradura ( Bitmap ImagenOriginal, Mascara MascaraEnviada, int colorPixel)
        {
           Bitmap im = PictureAnalizer.ErocionarImagen( PictureAnalizer.DilatarImagen( ImagenOriginal, MascaraEnviada, colorPixel), MascaraEnviada, 255);
            return im;
        }

        public static Bitmap Apertura(Bitmap ImagenOriginal, Mascara MascaraEnviada, int colorPixel)
        {
            Bitmap im = PictureAnalizer.DilatarImagen(PictureAnalizer.ErocionarImagen(ImagenOriginal, MascaraEnviada, colorPixel), MascaraEnviada, colorPixel);
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

        public static Bitmap SuavisarImagen ( Mascara mascaraEntrada, Bitmap Img_Entrada )
        {
            Bitmap mResultado =   PictureAnalizer.DibujarNegra(Img_Entrada.Width, Img_Entrada.Height);

            for ( int i = 0; i < mResultado.Height; i ++ )
                for ( int j = 0; j < mResultado.Width; j ++ )
                    PictureAnalizer.FiltrarEn(j, i, new Mascara( mascaraEntrada.MascaraNumerica, mascaraEntrada.Dims, mascaraEntrada.Centro), Img_Entrada, mResultado);

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


        public static Bitmap DetectarBordes(Mascara mascaraEntradaX, Mascara mascaraEntradaY, int tipo, Bitmap img)
        {
            Bitmap mResultadoX = PictureAnalizer.DibujarNegra(img.Width, img.Height);
            Bitmap mResultadoY = PictureAnalizer.DibujarNegra(img.Width, img.Height);

            Bitmap mResultadoGradZ = PictureAnalizer.DibujarNegra(img.Width, img.Height);

            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    int x = 0, y = 0, z = 0;

                    y = PictureAnalizer.ValorMascara(j, i, new Mascara(mascaraEntradaY.MascaraNumerica, mascaraEntradaY.Dims, mascaraEntradaY.Centro), img, mResultadoY);
                    mResultadoY.SetPixel(j, i, Color.FromArgb(y, y, y));

                    x = PictureAnalizer.ValorMascara(j, i, new Mascara(mascaraEntradaX.MascaraNumerica, mascaraEntradaX.Dims, mascaraEntradaX.Centro), img, mResultadoX);
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

        public static Bitmap MostrarAcms (  )
        {
            double porcentaje = 0;
            double u = (porcentaje/100)*MaximoMascaraMatriz(PictureAnalizer.AcumuladorGeneral);

            Bitmap m = PictureAnalizer.DibujarNegra(PictureAnalizer.AcumuladorGeneral.Dims.Width, PictureAnalizer.AcumuladorGeneral.Dims.Height);
            for (int i = 0; i < PictureAnalizer.AcumuladorGeneral.Dims.Height; i++)
            {
                for (int j = 0; j < PictureAnalizer.AcumuladorGeneral.Dims.Width; j++)
                {
                    int c =  (int)PictureAnalizer.AcumuladorGeneral.MascaraNumerica[j, i];
                    if (c >= u)
                    {
                        c = PictureAnalizer.NormalizarPixel(c);
                        m.SetPixel(j, i, Color.FromArgb(c, c, c));
                    }
                    else
                        m.SetPixel(j, i, Color.Black);
                }
            }
            return m;
        }

        public static Bitmap TransHough(Bitmap Ent_Img, Bitmap s, Mascara Min_x, Mascara Min_y,  int TetaDe, int TetaHasta, int numLineas )
        {
            // detectar bordes en la imagen 
           // Bitmap Hough_Im = DetectarBordes(Min_x, Min_y, 0);

            // umbraliza la imagen
           // Hough_Im = Umbralizar(Hough_Im, Otsu(HistogramaNormal(Hough_Im)));

            Bitmap Hough_Im = new Image<Gray, byte>(Ent_Img).Canny(100,50).ToBitmap();

            // crear el acumulador
            double pMaximo = Math.Sqrt(Math.Pow(Hough_Im.Width, 2) + Math.Pow(Hough_Im.Height, 2));
            double RangoPeee = Math.Round(Math.Sqrt( Math.Pow( Hough_Im.Width,2) + Math.Pow(Hough_Im.Height,2)) );
            double RangoTeta = Math.Abs(TetaDe) + TetaHasta;
            double conversor = Math.PI / 180;

            Mascara Acumulador = new Mascara( new Size ((int)RangoPeee, (int)RangoTeta) );


            // realizar transformacion lineal para cada pixel 
            for (int i = 0; i < Hough_Im.Height; i++)
            {
                for (int j = 0; j < Hough_Im.Width; j++)
                {
                    // iterar para todo el rango de angulos 
                    for (int iTeta = TetaDe; iTeta <RangoTeta; iTeta++)
                    {
                        if (PictureAnalizer.PixelColor2Gray(Hough_Im.GetPixel(j, i)) > 0)
                        {
                            int PeeI = (Convert.ToInt32(  Math.Round(j * Math.Cos(conversor * iTeta) + i * Math.Sin(conversor * iTeta))));
                            Acumulador.MascaraNumerica[ Math.Abs( PeeI), Math.Abs (iTeta)] += 1;
                        }
                    }
                }
            }

            PictureAnalizer.AcumuladorGeneral = CopiarMatriz( Acumulador) ;

            Bitmap v = new Bitmap(Hough_Im);

            for (int ss = 0; ss < numLineas; ss++)
            {
                Point Pmax = MatrizMaxPosicion(Acumulador);
                for ( int i = 0; i < Hough_Im.Height; i ++ )
                {
                    for ( int j = 0; j < Hough_Im.Width; j ++)
                    {
                        long ys = Convert.ToInt64( Math.Round(  (Pmax.X / Math.Sin(conversor * Pmax.Y) )  - ( ( (j * Math.Cos(conversor*Pmax.Y))/Math.Sin(conversor * Pmax.Y) ))));
                        if (ys == i)
                            v.SetPixel(j, i, Color.Red);
                    }
                }
            }




            return v;
        }



        static Point  MatrizMaxPosicion ( Mascara Ent_Mascara )
        {
            Point pmax = new Point();
            double[] arr = new double[ (int)Ent_Mascara.Dims.Width * Ent_Mascara.Dims.Height];

            int k = 0;
            for (int i = 0; i < Ent_Mascara.Dims.Height; i++)
            {
                for (int j = 0; j < Ent_Mascara.Dims.Width; j++)
                {
                   arr[k] = Ent_Mascara.MascaraNumerica[j,i];
                    k++;
                }
            }

            double max = arr.Max();

             for (int i = 0; i < Ent_Mascara.Dims.Height; i++)
            {
                for (int j = 0; j < Ent_Mascara.Dims.Width; j++)
                {
                    if (Ent_Mascara.MascaraNumerica[j,i] == max)
                    {
                        pmax.X = j;
                        pmax.Y = i;

                        Ent_Mascara.MascaraNumerica[j, i] = -10;
                    }
                }
            }

            return pmax;
        }


        static int MaximoMascaraMatriz ( Mascara Ent_Mascara )
        {
            double[] arr = new double[(int)Ent_Mascara.Dims.Width * Ent_Mascara.Dims.Height];

            int k = 0;
            for (int i = 0; i < Ent_Mascara.Dims.Height; i++)
            {
                for (int j = 0; j < Ent_Mascara.Dims.Width; j++)
                {
                    arr[k] = Ent_Mascara.MascaraNumerica[j, i];
                    k++;
                }
            }

            double max = arr.Max();
            return (int)max;

        }

        public static Mascara CopiarMatriz ( Mascara Origen )
        {
            Mascara mn = new Mascara(Origen.MascaraNumerica, Origen.Dims, Origen.Centro);
            return mn;
        }

        public static Dictionary<int,double> [] HistogramasSumaDiferencia ( Bitmap Img_Ent )
        {
            // crear un hash 
            Dictionary<int, double>[] Dics = new Dictionary<int, double>[2];

            Dictionary<int, int> HSuma = new Dictionary<int, int>();
            Dictionary<int, double> HSumaNorm = new Dictionary<int, double>();

            Dictionary<int, int> HResta = new Dictionary<int, int>();
            Dictionary<int, double> HRestaNorm = new Dictionary<int, double>();

            //
            for (int i = 0; i < 256 * 2; i++)
            {
                HSuma.Add(i, 0);
                HSumaNorm.Add(i, 0);

                if (i <= 255)
                {
                    HResta.Add(i, 0);
                    HRestaNorm.Add(i, 0);
                }
                else
                {
                    HResta.Add(255-i, 0);
                    HRestaNorm.Add(255-i, 0);
                }
            }


            // iterar para cada pixel en la imagen 
            for ( int i = 0; i < Img_Ent.Height; i ++ )
            {
                for ( int j = 0;  j < Img_Ent.Width; j ++ )
                {
                    // conseguir el pixel i,j
                    int Pi = PictureAnalizer.PixelColor2Gray( Img_Ent.GetPixel(j, i) );

                    // verificar si se puede acceder al los pixeles horizontales
                    if (i + 0 < Img_Ent.Height && j + 1 < Img_Ent.Width)
                    {
                        int Sx1 = PictureAnalizer.PixelColor2Gray(Img_Ent.GetPixel(j + 1, i));
                        int SxS = Pi + Sx1;
                        int SxR = Pi - Sx1;
                        HSuma[SxS]++;
                        HResta[SxR]++;
                    }
                    if (i + 0 < Img_Ent.Height && j + 2 < Img_Ent.Width)
                    {
                        int Sx1 = PictureAnalizer.PixelColor2Gray(Img_Ent.GetPixel(j + 2, i));
                        int SxS = Pi + Sx1;
                        int SxR = Pi - Sx1;
                        HSuma[SxS]++;
                        HResta[SxR]++;
                    }

                    // verificar si se puede acceder al los pixeles diagonales
                    if (i + 1 < Img_Ent.Height && j + 1 < Img_Ent.Width)
                    {
                        int Sx1 = PictureAnalizer.PixelColor2Gray(Img_Ent.GetPixel(j + 1, i + 1));
                        int SxS = Pi + Sx1;
                        int SxR = Pi - Sx1;
                        HSuma[SxS]++;
                        HResta[SxR]++;
                    }
                    if (i + 2 < Img_Ent.Height && j + 2 < Img_Ent.Width)
                    {
                        int Sx1 = PictureAnalizer.PixelColor2Gray(Img_Ent.GetPixel(j + 2, i + 2));
                        int SxS = Pi + Sx1;
                        int SxR = Pi - Sx1;
                        HSuma[SxS]++;
                        HResta[SxR]++;
                    }

                    // verificar si se puede acceder al los pixeles verticales
                    if (i + 1 < Img_Ent.Height && j + 0 < Img_Ent.Width)
                    {
                        int Sx1 = PictureAnalizer.PixelColor2Gray(Img_Ent.GetPixel(j, i + 1));
                        int SxS = Pi + Sx1;
                        int SxR = Pi - Sx1;
                        HSuma[SxS]++;
                        HResta[SxR]++;
                    }
                    if (i + 2 < Img_Ent.Height && j < Img_Ent.Width)
                    {
                        int Sx1 = PictureAnalizer.PixelColor2Gray(Img_Ent.GetPixel(j, i + 2));
                        int SxS = Pi + Sx1;
                        int SxR = Pi - Sx1;
                        HSuma[SxS]++;
                        HResta[SxR]++;
                    }
                }
            }

            // normalizar el histograma 
            int totalSuma = 0, totalResta = 0;
            for (int i = 0; i < 256 * 2; i++)
            {
                totalSuma += HSuma[i];

                if ( i <= 255 )
                    totalResta += HResta[i];
                else
                    totalResta += HResta[255-i];
            }

            for (int i = 0; i < 256 * 2; i++)
            {
                HSumaNorm[i] = (double)HSuma[i] / totalSuma;
                if( i <= 255 )
                    HRestaNorm[255-i] = (double)HResta[255-i] / totalResta;
            }

            Dics[0] = HSumaNorm; Dics[1] = HRestaNorm;
            return Dics;
        }

   
        public static double [] CaracteristicasTextura (Dictionary<int, double> Hs, Dictionary<int, double> Hr)
        {
            double[] Carac = new double[6];

            double media = 0,
                   varin = 0,
                   homgn = 0,
                   energ = 0,
                   entrp = 0,
                   contr = 0;

            double e1 = 0, e2 = 0;

            // calcular media 
            double su = 0.0;
  

            // iterar para los 2 arreglos 
            for ( int i = 0; i < 256*2; i ++ )
            {
                // calcular la media 
                media += i * Hs[i];
                

                // calcular la varianza 
                if (i <= 255 )
                    varin += Math.Pow(( (i - 2 * (media/2))), 2) * Hs[i] + Math.Pow(i, 2) * Hr[i];
                else
                    varin += Math.Pow(( (i - 2 * (media/2))), 2) * Hs[i] + Math.Pow(255-i, 2) * Hr[255-i];
                


                // calcular la homogeneidad
                if ( i <= 255 )
                    homgn += 1 /( (double)( Math.Pow( i,2) + 1) ) * Hr[i];
                else
                    homgn += 1 /( (double)( Math.Pow(255-i,2) + 1) )* Hr[255-i];

                // calcular energia
                if( i < 255 )
                    energ += Math.Pow(Hs[i], 2) * Math.Pow(Hr[i], 2); 
                else
                    energ += Math.Pow(Hs[i]+1, 2) * Math.Pow(Hr[256-i], 2);

                // calcular contraste 
                if (i < 255)
                    contr += Math.Pow(i, 2) * Hr[i];
                else
                    contr += Math.Pow(256-i, 2) * Hr[256-i];

                //calcular entropia 
                if ( i < 255 )
                    if (i != 0)
                        entrp += Hs[i] * Math.Log10( Math.Abs(Hr[i])+1 ) - Hr[i] * Math.Log10(Hs[i]+1);
                else
                    if ( i != 0 )
                    entrp += Hs[i] * Math.Log10( Math.Abs( Hr[256-i] )+1 ) - Hr[256-i] * Math.Log10(Hs[i]+1);

            }
          

            // media, varianza, homogen, energia, entropia, contraste
            Carac[0] =  media * (double)1/2; Carac[1] = varin * (double)1/2; Carac[2] = homgn; Carac[3] = energ; Carac[4] = entrp; Carac[5]= contr;

            return Carac;
        }

        public static double [] CalcularCaracteristicasTextura ( Bitmap Im_ent)
        {
            Dictionary<int, double>[] hsr = PictureAnalizer.HistogramasSumaDiferencia(Im_ent);

            double[] op = PictureAnalizer.CaracteristicasTextura(hsr[0], hsr[1]);

            return op;
        }

        // se supone una mascara de tipod cuadrada
        public static Bitmap CortarMascaraSobreImagen ( Mascara Masc_Ent, Bitmap Img_Ent, Point Pnt_Orgn)
        {
            // crear una subimagen del tamaño de la mascara, dimenciones cuadradas
            Bitmap sbImg = PictureAnalizer.DibujarNegra(Masc_Ent.Dims.Height, Masc_Ent.Dims.Height);

            // recorrer la matriz 
            int Pinicio =( (Masc_Ent.Dims.Height - 1) / 2) - (Masc_Ent.Dims.Height - 1) + Pnt_Orgn.X;
            int Pfinal = ( Masc_Ent.Dims.Height );

            int k = 0;
            while ( Pinicio <= 0 )
            {
                Pinicio = ((Masc_Ent.Dims.Height - 1) / 2) - (Masc_Ent.Dims.Height - 1) + Pnt_Orgn.X + k;
                k++;
            }

            Mascara m = new Mascara(new Size(3, 3));

            for ( int i = Pinicio, s = 0; i < Pfinal; i ++,s ++  )
            {
                for ( int j = Pinicio, z = 0; j < Pfinal; j ++, z ++ )
                {
                   // verificar que los indices no superen los limites de la imagen
                   if ( Pnt_Orgn.X + j < Img_Ent.Width && Pnt_Orgn.Y + i < Img_Ent.Height && Pnt_Orgn.X + j > 0 && Pnt_Orgn.Y + i > 0)
                    {
                        int PxiOrigen = PictureAnalizer.PixelColor2Gray(Img_Ent.GetPixel(Pnt_Orgn.X+j, Pnt_Orgn.Y+ i));
                        sbImg.SetPixel(z, s, Color.FromArgb(PxiOrigen, PxiOrigen, PxiOrigen));
                        m.MascaraNumerica[j, i]=1;
                    }
                }
            }

            return sbImg;
        }

        public static double MaximoHasha ( Dictionary<int,double> Hsh_ent )
        {
          double  MaximoHasha = 0;
            foreach (KeyValuePair<int, double> S in Hsh_ent)
                if (S.Value > MaximoHasha)
                    MaximoHasha = S.Value;
            return MaximoHasha;
        }

        public static Bitmap []  ImagenDeTextura ( Bitmap Im_Ent, Dictionary<int,double>[] hrs )
        {
            // conseguir los maximos de las sumas y diferencias
            double MaxSuma = PictureAnalizer.MaximoHasha(hrs[0]);
            double MaxResta = PictureAnalizer.MaximoHasha(hrs[1]);
            double MaxGenrl = 0;
            if (MaxSuma > MaxResta)
                MaxGenrl = MaxSuma;
            else
                MaxGenrl = MaxResta;

            // crear vector de imagenes de textura 
            Bitmap[] VectImgTxt = new Bitmap[6];

            // inicar las imagenes 
            for (int i = 0; i < 6; i++)
                VectImgTxt[i] = PictureAnalizer.DibujarNegra(Im_Ent.Width, Im_Ent.Height);

            // crear una mascara para representar la subventana
            Mascara Mx = new Mascara(new Size(3, 3));

            // recorrer la imagen
            for ( int i = 0; i < Im_Ent.Height; i ++)
            {
                for ( int j = 0; j < Im_Ent.Width; j ++ )
                {
                    // conseguir pixel
                    int Pi = PictureAnalizer.PixelColor2Gray(Im_Ent.GetPixel(j, i));


                    // cortar contenido de la imagen origina con la mascara
                    Bitmap subImg = PictureAnalizer.CortarMascaraSobreImagen(Mx, Im_Ent, new Point(j, i));

                    // calcular las caracteristicas de textura de la subimagen
                    double[] op = PictureAnalizer.CalcularCaracteristicasTextura(Im_Ent);

                    // asignar operaciones a la imagen
                    for (int k = 0; k < 6; k++)
                    {
                        int trnas = (int)Math.Round((op[i] * 255) / MaxGenrl);
                        VectImgTxt[i].SetPixel(j, i, Color.FromArgb(trnas, trnas, trnas));
                    }
                }
            }
            return VectImgTxt;
        }

        
        // subdividir la imagen 
        public static Bitmap [,] DividirImagen ( Bitmap Img_ImgOriginal, int divNum)
        {
            // generar una matriz para guardar cada casilla
            Bitmap[,] MatrizImg = new Bitmap[divNum, divNum];

            // dividir las dimenciones de la imagen
            int h, w;
            h = (int) Math.Round( (double)Img_ImgOriginal.Height / divNum ,0);
            w = (int) Math.Round( (double)Img_ImgOriginal.Width / divNum , 0);


            
            for (int i = 0; i < divNum ; i++)
            {
                for (int j = 0; j < divNum ; j++)
                {
                    MatrizImg[j, i] = new Bitmap(w, h);

                    for ( int y = i * h , s = 0;   y < (h-1) * (i+1);   y++, s ++ )
                    {
                        for ( int x = j * w, n = 0;   x < (w-1) * (j+1);   x++, n++ )
                        {
                            int c = PictureAnalizer.PixelColor2Gray(Img_ImgOriginal.GetPixel(x,y));
                            MatrizImg[j, i].SetPixel(n, s, Color.FromArgb(c,c,c));
                            
                        }
                    }
                }
            }

            return MatrizImg;
        }

        public static Bitmap ResaltarLineas ( Bitmap Img_Entrada )
        {
            Bitmap imgLines = PictureAnalizer.DibujarNegra(  Img_Entrada.Width, Img_Entrada.Height);
            
            for ( int i = 0; i < Img_Entrada.Height; i ++ )
            {
                for ( int j = 0;  j < Img_Entrada.Width; j ++ )
                {
                    bool x = false, y = false;
                    int c = PictureAnalizer.PixelColor2Gray(Img_Entrada.GetPixel(j, i));

                    if ( c > 0 )
                    {
                        int cYan, cYPs, cXan, cXPs;
                        if ( i - 1 > 0 && i + 1 < Img_Entrada.Height )
                        {
                            cYan = PictureAnalizer.PixelColor2Gray(Img_Entrada.GetPixel(j, i-1));
                            cYPs = PictureAnalizer.PixelColor2Gray(Img_Entrada.GetPixel(j, i+1));
                            if ( cYan > 0 && cYPs >0 )
                                y = true;
                            
                        }

                        if (j - 1 > 0 && j + 1 < Img_Entrada.Width)
                        {
                            cXan = PictureAnalizer.PixelColor2Gray(Img_Entrada.GetPixel(j - 1, i));
                            cXPs = PictureAnalizer.PixelColor2Gray(Img_Entrada.GetPixel(j + 1, i));
                            if ( cXan > 0 && cXPs > 0)
                                x = true;
                        }

                        if ( x &&  y )
                            imgLines.SetPixel(j, i, Color.White);


                    }

                }
            }

            return imgLines;


        }

        public static Bitmap MoverInvertido ( Bitmap imgEntrada, int ColorOrigen)
        {
            Bitmap imgExt = new Bitmap(imgEntrada.Width, imgEntrada.Height);

            for ( int i = 0; i < imgEntrada.Height; i ++)
            {
                for (int j = 0; j < imgEntrada.Width;  j++)
                {
                    int c = PictureAnalizer.PixelColor2Gray(ImagenEntrada.GetPixel(j, i));
                    if (c == ColorOrigen)
                        imgExt.SetPixel(j, i, Color.FromArgb(c, c, c));
                   

                }
            }
            return imgExt;
        }

        public static Bitmap MoverPuntos(Bitmap Img_Entrada, Bitmap imgCompare)
        {
            Bitmap imgLines = PictureAnalizer.DibujarNegra(Img_Entrada.Width, Img_Entrada.Height);

            for (int i = 0; i < Img_Entrada.Height; i++)
            {
                for (int j = 0; j < Img_Entrada.Width; j++)
                {
                    bool x = false, y = false;
                    int c = PictureAnalizer.PixelColor2Gray(Img_Entrada.GetPixel(j, i));

                    imgLines.SetPixel(j, i, Color.FromArgb(c, c, c));

                    if (c > 0)
                    {
                        int cYan, cYPs, cXan, cXPs;
                        if (i - 1 > 0 && i + 1 < Img_Entrada.Height)
                        {
                            cYan = PictureAnalizer.PixelColor2Gray(imgCompare.GetPixel(j, i - 1));
                            cYPs = PictureAnalizer.PixelColor2Gray(imgCompare.GetPixel(j, i + 1));
                            if (cYan > 0 || cYPs > 0)
                            {
                                imgLines.SetPixel(j, i - 1, Color.FromArgb(c, c, c));
                                imgLines.SetPixel(j, i + 1, Color.FromArgb(c, c, c));
                            }

                        }

                        if (j - 1 > 0 || j + 1 < Img_Entrada.Width)
                        {
                            cXan = PictureAnalizer.PixelColor2Gray(imgCompare.GetPixel(j - 1, i));
                            cXPs = PictureAnalizer.PixelColor2Gray(imgCompare.GetPixel(j + 1, i));
                            if (cXan > 0 ||  cXPs > 0)
                            {
                                imgLines.SetPixel(j - 1, i, Color.FromArgb(c, c, c));
                                imgLines.SetPixel(j + 1, i, Color.FromArgb(c, c, c));
                            }
                        }




                    }

                }
            }

            return imgLines;
        }
    }
}
