using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cargadorImagenes
{
    public partial class Form2 : Form
    {
        Bitmap ImagenContraste;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // mostrar la grafica del histograma
            this.chart1.ChartAreas.Add("Area1");
        }

        public double desvEst(int[] vectOc, Bitmap imEt)
        {
            double m = 0.0;

            double p = promedio(vectOc, imEt);
            foreach (double k in vectOc)
                m += Math.Pow((k - p), 2);
            m /= vectOc.Length - 1;

            return m;
        }

        public double promedio(int[] vectOc, Bitmap imEt)
        {
            double m = 0.0;
            foreach (double k in vectOc)
                m += k;

            m /= (imEt.Width*imEt.Height);
            return m;
        }

        // crear la grafica del histograma 
        public void GraficarHisto(Bitmap ImagenEntrada, int [] vectHist, int b)
        {

            int offY = 5;
            int offX = 10;

            // crear imagen gde grafica de las mismas dimenciones que la imagen de entrada
           // this.ImagenContraste = new Bitmap(ImagenEntrada.Width + offX, ImagenEntrada.Height + 2* offY);

            int Ax = (this.ImagenContraste.Width / 255);
            double max = (vectHist.Max()/( (double)(ImagenEntrada.Height * ImagenEntrada.Width) ));

            if ( max  < 0.09 ) 
            {
                 // iterar para cada valor en el vector 
                for (int i = 0; i < vectHist.Length; i++)
                {

                    double fx = ImagenEntrada.Height /(double) vectHist.Max();
                    double h = vectHist[i] * fx;

                    // recorrer de abajo hacia arriba 
                    for (int y = 0 ; y < h ; y++)
                    {
                        // recorrer en x 
                        int transY = (int)(this.ImagenContraste.Height - h);
                        for (int x = ((i) * Ax); x < ((i + 1) * Ax); x++)
                            this.ImagenContraste.SetPixel(x + offX, (int)(y + transY), Color.Green);
                    }
                }
            }
            else
            {
                 // iterar para cada valor en el vector 
                for (int i = 0; i < vectHist.Length; i++)
                {   
                    double fx = (vectHist[i]/ (double)(ImagenEntrada.Height * ImagenEntrada.Width)) ;
                    double h = this.ImagenContraste.Height * fx;

                    // recorrer de abajo hacia arriba 
                    for (int y = 0 ; y < h ; y++)
                    {
                        // recorrer en x 
                        int transY = (int)(this.ImagenContraste.Height - h);
                        for (int x = ((i) * Ax); x < ((i + 1) * Ax); x++)
                            this.ImagenContraste.SetPixel(x + offX, (int)(y + transY), Color.Green);
                    }
                }
            }
            pictureBox1.Refresh();
            this.ImagenContraste.Save(@"C:\Users\Public\Pictures\Sample Pictures\Prueva2\histo" + b.ToString() + ".jpeg");     
        }

        // crear la grafica del histograma 
        public void GraficarHistoAcum(Bitmap ImagenEntrada, int[] vectHist, int b)
        {

            int offY = 5;
            int offX = 10;
            // crear imagen gde grafica de las mismas dimenciones que la imagen de entrada
            this.ImagenContraste = new Bitmap(ImagenEntrada.Width + offX, ImagenEntrada.Height + 2 * offY);

            int Ax = (this.ImagenContraste.Width / 255);
            double max = (vectHist.Max() / ((double)(ImagenEntrada.Height * ImagenEntrada.Width)));

            if (max < 0.09)
            {
                // iterar para cada valor en el vector 
                for (int i = 0; i < vectHist.Length; i++)
                {

                    double fx = ImagenEntrada.Height / (double)vectHist.Max();
                    double h = vectHist[i] * fx;

                    // recorrer de abajo hacia arriba 
                    for (int y = 0; y < h; y++)
                    {
                        // recorrer en x 
                        int transY = (int)(this.ImagenContraste.Height - h);
                        for (int x = ((i) * Ax); x < ((i + 1) * Ax); x++)
                            this.ImagenContraste.SetPixel(x + offX, (int)(y + transY), Color.Red);
                    }
                }
            }
            else
            {
                // iterar para cada valor en el vector 
                for (int i = 0; i < vectHist.Length; i++)
                {
                    double fx = (vectHist[i] / (double)(ImagenEntrada.Height * ImagenEntrada.Width));
                    double h = this.ImagenContraste.Height * fx;

                    // recorrer de abajo hacia arriba 
                    for (int y = 0; y < h; y++)
                    {
                        // recorrer en x 
                        int transY = (int)(this.ImagenContraste.Height - h);
                        for (int x = ((i) * Ax); x < ((i + 1) * Ax); x++)
                            this.ImagenContraste.SetPixel(x + offX, (int)(y + transY), Color.Red);
                    }
                }
            }


            pictureBox1.Image = this.ImagenContraste;
            pictureBox2.Refresh();
            this.ImagenContraste.Save(@"C:\Users\Public\Pictures\Sample Pictures\Prueva2\histo" + b.ToString() + ".jpeg");

        }

        public void InsertarImagen(Bitmap ImagenEntrada)
        {
            this.pictureBox2.Image = ImagenEntrada;
        }

        // crear un metodo para visualizar un histograma 
        public int[] Histograma(Bitmap ImagenEntrada)
        {

            int [] h  = new int [256];
                for (int i = 0; i < ImagenEntrada.Height; i++)
                {
                    for (int j = 0; j < ImagenEntrada.Width; j++)
                    {
                        Color c = ImagenEntrada.GetPixel(j, i);
                        int s = (int)((c.R * 0.30) + (c.G * 0.59) + (c.B * 0.11));
                        h[s] += 1;
                    }
                }
                return h;
        }

        public int[] HistoAcum(Bitmap ImagenEntrada, int [] h)
        {

            int[] hC = new int[256];
            for (int i = 1; i < hC.Length; i++)
                hC[i] = h[i]+ hC[i - 1];
            return hC;
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void GuardarImagen(string rutaGuardado, int b)
        {
            
        }
    }
}
