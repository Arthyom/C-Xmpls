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


    public partial class Form1 : Form
    {
        public string rutaEntrada;
        public Bitmap imagenSalida;
        public Bitmap imagenEntrad;
        public Point  puntoInicio;
        public Point  puntoFinal;

        public Form1()
        {
            InitializeComponent();
        }

        // crear imagen negra y la regresa 
        public Bitmap CrearNegra(int w, int h)
        {
            Bitmap negra = new Bitmap(w, h);

            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    negra.SetPixel(j, i, Color.Black);

            return negra;
        }


        // cargar la imagen y convertirla en escala de grices 
        private void button1_Click(object sender, EventArgs e)
        {

            // buscar imagen y cargarla en picture box de entrada
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            this.rutaEntrada = op.FileName;
            this.pictureBox1.Image = Image.FromFile(rutaEntrada);
            this.imagenEntrad = (Bitmap)pictureBox1.Image;

            // crear una imagen para el picture box de salida
            this.imagenSalida = new Bitmap ( this.imagenEntrad.Width, this.imagenEntrad.Height);

            // mover los pixeles del pictures box de salida y volverlos escala de grices
            for ( int i = 0; i < this.imagenSalida.Height; i ++ )
            {
                for (int j = 0; j < this.imagenSalida.Width; j++)
                {
                    Color c = this.imagenEntrad.GetPixel(j, i);
                    int  g = (int) ((c.R * 0.30) + (c.G * 0.59) + (c.B * 0.11)); 

                    this.imagenSalida.SetPixel(j, i, Color.FromArgb(g,g,g)) ;
                }
            }
            
            // cargar la imagen en el picture box de salida
            this.pictureBox2.Image = this.imagenSalida;

        
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // mover el centro del circulo
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            // mover el centro del circulo cuando el centro se mueva
            if (e.Button == MouseButtons.Left)
            {

                // usar ec. canonica para identificar todos los puntos
                // (x-h)2 + (y-k)^2 = r2
                // si el punto i,j satisface la ecuacion para el centro h,k entonces i,j pertenece a la circunferencia
                double r = 150;
                int h = e.X, k = e.Y;
                int nivBrillo = 255;

                // crear un efecto lampara
                this.pictureBox2.Image = CrearNegra(this.imagenEntrad.Width, this.imagenEntrad.Height);
                Bitmap aux = (Bitmap)pictureBox2.Image;

                for (int i = 0; i < this.imagenSalida.Height; i++)
                {
                    for (int j = 0; j < this.imagenSalida.Width; j++, nivBrillo -= 1)
                    {
                        Color c = this.imagenSalida.GetPixel(j, i);

                        // verificar las condiciones de la ecuacion 
                        if (Math.Pow((j - h), 2) + Math.Pow((i - k), 2) <= Math.Pow(r, 2))
                        {
                            int g = (int)((c.R * 0.30) + (c.G * 0.59) + (c.B * 0.11));

                            if (255 <= (g + 255))
                                g = 255;
                            else
                            {
                                if ((g + nivBrillo) <= 0)
                                    g = 0;
                                else
                                    g += nivBrillo;
                            }


                            aux.SetPixel(j, i, Color.FromArgb(g,g,g));

                        }
                        else
                        {

                            aux.SetPixel(j, i, Color.Black);

                        }
                    }
                }

                this.pictureBox2.Image = aux;
                this.pictureBox2.Refresh();
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        // dibujar una circunferencia en el punto dado
        private void button2_Click(object sender, EventArgs e)
        {
            // usar ec. canonica para identificar todos los puntos
            // (x-h)2 + (y-k)^2 = r2
            // si el punto i,j satisface la ecuacion para el centro h,k entonces i,j pertenece a la circunferencia
            double r = 150;
            int h = 200, k = 200;
            int nivBrillo = 10;

            // crear un efecto lampara
            this.pictureBox2.Image = CrearNegra(this.imagenEntrad.Width, this.imagenEntrad.Height);
            Bitmap aux = (Bitmap)pictureBox2.Image;

            for (int i = 0; i < this.imagenSalida.Height; i++)
            {
                for (int j = 0; j < this.imagenSalida.Width; j++)
                {
                    Color c = this.imagenSalida.GetPixel(j, i);

                    // verificar las condiciones de la ecuacion 
                    if (Math.Pow((j - h), 2) + Math.Pow((i - k), 2) <= Math.Pow(r, 2))
                    {
                        int g = (int)((c.R * 0.30) + (c.G * 0.59) + (c.B * 0.11));

                        if (255 <= (g + 255))
                            g = 255;
                        else
                        {
                            if ((g + nivBrillo) <= 0)
                                g = 0;
                            else
                                g += nivBrillo;
                        }


                        aux.SetPixel(j, i, Color.FromArgb(g, g, g));

                    }
                    else
                    {

                        aux.SetPixel(j, i, Color.Black);

                    }
                }
            }

            this.pictureBox2.Image = aux;
            this.pictureBox2.Refresh();
        }
    }
}
