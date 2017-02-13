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
        public Point puntoInicio = new Point();
        public Point puntoFinal;

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
            this.imagenSalida = new Bitmap(this.imagenEntrad.Width, this.imagenEntrad.Height);

            // mover los pixeles del pictures box de salida y volverlos escala de grices
            for (int i = 0; i < this.imagenSalida.Height; i++)
            {
                for (int j = 0; j < this.imagenSalida.Width; j++)
                {
                    Color c = this.imagenEntrad.GetPixel(j, i);
                    int g = (int)((c.R * 0.30) + (c.G * 0.59) + (c.B * 0.11));

                    this.imagenSalida.SetPixel(j, i, Color.FromArgb(g, g, g));
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
            if (e.Button == MouseButtons.Left)
            {
                // usar ec. canonica para identificar todos los puntos
                // (x-h)2 + (y-k)^2 = r2
                // si el punto i,j satisface la ecuacion para el centro h,k entonces i,j pertenece a la circunferencia
                double r = rad.Value * 30;
                int h = e.X, k = e.Y;
                this.puntoInicio.X = e.X; this.puntoInicio.Y = e.Y;
                double nivBrillo = 120;

                // crear un efecto lampara
                this.pictureBox2.Image = CrearNegra(this.imagenEntrad.Width, this.imagenEntrad.Height);
                Bitmap aux = (Bitmap)pictureBox2.Image;

                 // iterar desde el centro - radio hasta radio
            for (int i = k - (int)r ; i < r +k; i++)
            {
                for (int j = h - (int)r; j < r + h; j++)
                {
                    // verificar si i,j son positivas 
                    if ((0 < i) && (0 < j))
                    {
                        Color c = this.imagenSalida.GetPixel(j, i);

                        //verificar las condiciones de la ecuacion 
                        if ( Math.Pow((j - h), 2) + Math.Pow((i - k), 2) <= Math.Pow(r, 2))
                        {
                            int Ay = i - k;
                            int Ax = j - h;

                            int Ab = (int)nivBrillo - (bri.Value* Ay);

                            int g = (int)((c.R * 0.30) + (c.G * 0.59) + (c.B * 0.11));

                            if (255 <= (g + Ab))
                                g = 255;
                            else
                            {
                                if ((g + Ab) <= 0)
                                    g = 0;
                                else
                                    g += Ab;
                            }
                            aux.SetPixel(j, i, Color.FromArgb(g, g, g));
                        }
                        else
                        {

                            aux.SetPixel(j, i, Color.Black);

                        }
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
            double r = rad.Value * 30;
            int h = this.puntoInicio.X, k = this.puntoInicio.Y;
            double nivBrillo = trackBar1.Value;

            // crear un efecto lampara
            this.pictureBox2.Image = CrearNegra(this.imagenEntrad.Width, this.imagenEntrad.Height);
            Bitmap aux = (Bitmap)pictureBox2.Image;

            // iterar desde el centro - radio hasta radio
            for (int i = k - (int)r ; i < r +k; i++)
            {
                for (int j = h - (int)r ; j < r +h ; j++)
                {
                    // verificar si i,j son positivas 
                    if ((0 < i) && (0 < j))
                    {
                        Color c = this.imagenSalida.GetPixel(j, i);

                        //verificar las condiciones de la ecuacion 
                        if ( Math.Pow((j - h), 2) + Math.Pow((i - k), 2) <= Math.Pow(r, 2))
                        {
                            int Ay = i - k;
                            int Ax = j - h;

                            int Ab = (int)nivBrillo - (4 * Ay);

                            int g = (int)((c.R * 0.30) + (c.G * 0.59) + (c.B * 0.11));

                            if (255 <= (g + Ab))
                                g = 255;
                            else
                            {
                                if ((g + Ab) <= 0)
                                    g = 0;
                                else
                                    g += Ab;
                            }
                            aux.SetPixel(j, i, Color.FromArgb(g, g, g));
                        }
                        else
                        {

                            aux.SetPixel(j, i, Color.Black);

                        }
                    }
                }
            }

            this.pictureBox2.Image = aux;
            this.pictureBox2.Refresh();
        }

        private void rad_Scroll(object sender, EventArgs e)
        {
             // usar ec. canonica para identificar todos los puntos
                // (x-h)2 + (y-k)^2 = r2
                // si el punto i,j satisface la ecuacion para el centro h,k entonces i,j pertenece a la circunferencia
                double r = rad.Value * 30;
                int h = this.puntoInicio.X, k = this.puntoInicio.Y;
                double nivBrillo = trackBar1.Value;

                // crear un efecto lampara
                this.pictureBox2.Image = CrearNegra(this.imagenEntrad.Width, this.imagenEntrad.Height);
                Bitmap aux = (Bitmap)pictureBox2.Image;

            // iterar desde el centro - radio hasta radio
            for (int i = k - (int)r ; i < r +k; i++)
            {
                for (int j = h - (int)r; j < r + h; j++)
                {
                    // verificar si i,j son positivas 
                    if ((0 < i) && (0 < j))
                    {
                        Color c = this.imagenSalida.GetPixel(j, i);

                        //verificar las condiciones de la ecuacion 
                        if ( Math.Pow((j - h), 2) + Math.Pow((i - k), 2) <= Math.Pow(r, 2))
                        {
                            int Ay = i - k;
                            int Ax = j - h;

                            int Ab = (int)nivBrillo - (bri.Value* Ay);

                            int g = (int)((c.R * 0.30) + (c.G * 0.59) + (c.B * 0.11));

                            if (255 <= (g + Ab))
                                g = 255;
                            else
                            {
                                if ((g + Ab) <= 0)
                                    g = 0;
                                else
                                    g += Ab;
                            }
                            aux.SetPixel(j, i, Color.FromArgb(g, g, g));
                        }
                        else
                        {

                            aux.SetPixel(j, i, Color.Black);

                        }
                    }
                }
            }


                this.pictureBox2.Image = aux;
                this.pictureBox2.Refresh(); 
        }

        private void bri_Scroll(object sender, EventArgs e)
        {
            // usar ec. canonica para identificar todos los puntos
            // (x-h)2 + (y-k)^2 = r2
            // si el punto i,j satisface la ecuacion para el centro h,k entonces i,j pertenece a la circunferencia
            double r = rad.Value * 30;
            int h = this.puntoInicio.X, k = this.puntoInicio.Y;
            double nivBrillo = trackBar1.Value;

            // crear un efecto lampara
            this.pictureBox2.Image = CrearNegra(this.imagenEntrad.Width, this.imagenEntrad.Height);
            Bitmap aux = (Bitmap)pictureBox2.Image;

            // iterar desde el centro - radio hasta radio
            for (int i = k - (int)r; i < r + k; i++)
            {
                for (int j = h - (int)r; j < r + h; j++)
                {
                    // verificar si i,j son positivas 
                    if ((0 < i) && (0 < j))
                    {
                        Color c = this.imagenSalida.GetPixel(j, i);

                        //verificar las condiciones de la ecuacion 
                        if (Math.Pow((j - h), 2) + Math.Pow((i - k), 2) <= Math.Pow(r, 2))
                        {
                            int Ay = i - k;
                            int Ax = j - h;

                            int Ab = (int)nivBrillo - (bri.Value * Ay);

                            int g = (int)((c.R * 0.30) + (c.G * 0.59) + (c.B * 0.11));

                            if (255 <= (g + Ab))
                                g = 255;
                            else
                            {
                                if ((g + Ab) <= 0)
                                    g = 0;
                                else
                                    g += Ab;
                            }
                            aux.SetPixel(j, i, Color.FromArgb(g, g, g));
                        }
                        else
                        {

                            aux.SetPixel(j, i, Color.Black);

                        }
                    }
                }
            }


            this.pictureBox2.Image = aux;
            this.pictureBox2.Refresh(); 
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // usar ec. canonica para identificar todos los puntos
            // (x-h)2 + (y-k)^2 = r2
            // si el punto i,j satisface la ecuacion para el centro h,k entonces i,j pertenece a la circunferencia
            double r = rad.Value * 30;
            int h = this.puntoInicio.X, k = this.puntoInicio.Y;
            double nivBrillo = trackBar1.Value;

            // crear un efecto lampara
            this.pictureBox2.Image = CrearNegra(this.imagenEntrad.Width, this.imagenEntrad.Height);
            Bitmap aux = (Bitmap)pictureBox2.Image;

            // iterar desde el centro - radio hasta radio
            for (int i = k - (int)r; i < r + k; i++)
            {
                for (int j = h - (int)r; j < r + h; j++)
                {
                    // verificar si i,j son positivas 
                    if ((0 < i) && (0 < j))
                    {
                        Color c = this.imagenSalida.GetPixel(j, i);

                        //verificar las condiciones de la ecuacion 
                        if (Math.Pow((j - h), 2) + Math.Pow((i - k), 2) <= Math.Pow(r, 2))
                        {
                            int Ay = i - k;
                            int Ax = j - h;

                            int Ab = (int)nivBrillo - (bri.Value * Ay);

                            int g = (int)((c.R * 0.30) + (c.G * 0.59) + (c.B * 0.11));

                            if (255 <= (g + Ab))
                                g = 255;
                            else
                            {
                                if ((g + Ab) <= 0)
                                    g = 0;
                                else
                                    g += Ab;
                            }
                            aux.SetPixel(j, i, Color.FromArgb(g, g, g));
                        }
                        else
                        {

                            aux.SetPixel(j, i, Color.Black);

                        }
                    }
                }
            }


            this.pictureBox2.Image = aux;
            this.pictureBox2.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // crear una nueva instancia del form 2 
            Form2 f2 = new Form2();

            // llamar al metodo histograma y pasarle la imagen cargada 
            int [] h = f2.Histograma(imagenSalida);
            Label l = new Label();

            l.Size = new Size(f2.Width, 100);
            l.Location = new Point(10, 10);

            foreach (int val in h)
                l.Text += " " + Convert.ToInt32(val) +", ";

            // graficar el histograma 
            f2.GraficarHisto(imagenSalida, h);





            f2.Controls.Add(l);
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.imagenSalida = CrearNegra(512, 512);
            this.imagenSalida.Save(@"C:\Users\Public\Pictures\Sample Pictures\negra.jpeg");
            this.pictureBox2.Image = this.imagenSalida;
        }
    }
}
