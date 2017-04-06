using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargadorImagenes2._0
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// propiedades publicas de la clase form1
        /// </summary>


        public PictureAnalizer Analizador = new PictureAnalizer();
        public string RutaGuardado;
        public Mascara MascaraActual;

        public Bitmap CargarImagen ( string RutaImagen )
        {
            if (RutaImagen != null)
            {
                Bitmap ImagenCargada = new Bitmap(RutaImagen);
                return ImagenCargada;
            }
            else
                MessageBox.Show("olism");

           return null;
        }

        public Bitmap TransfGrayScl( Bitmap ImagenOriginal )
        {
            Bitmap ImagenTransForm = new Bitmap(ImagenOriginal.Width, ImagenOriginal.Height);
            for ( int i = 0; i < ImagenOriginal.Height; i ++ )
            {
                for ( int j = 0; j < ImagenOriginal.Width; j ++ )
                {
                    Color c = ImagenOriginal.GetPixel(j, i);
                }
            }
            return ImagenTransForm;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void ImagenEntrada_Click(object sender, EventArgs e)
        {

        }

        private void ToolButCargar_Click(object sender, EventArgs e)
        {
            // cargar una imagen
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
            f.OpenFile();
            string rutaImagenEntrada = f.FileName;

            // fijar imagen de entrada y de salida(en escala de grices)
            Analizador.SetImagenEntrada( PictureAnalizer.ImagenColor2Gray(  (Bitmap)(Image.FromFile(rutaImagenEntrada)) ) );
            

            // fijar imaenes en la gui
            ImagenEntrada.Image = PictureAnalizer.ImagenEntrada;
            

            



        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void otsuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analizador.SetImagenSalida((Bitmap)ImagenEntrada.Image);
            // crear un histograma
            int[] h = PictureAnalizer.Histograma(PictureAnalizer.ImagenEntrada);
            double[] hn = PictureAnalizer.HistogramaNormal(PictureAnalizer.ImagenEntrada, h);

            // realizar una umbralizacion 
            int t = PictureAnalizer.Otsu(hn);
            this.ImagenSalida.Image = PictureAnalizer.Umbralizar(PictureAnalizer.ImagenEntrada, t );
            MessageBox.Show( "Umbral Optimo " + t.ToString(), "Umbral optimo" );
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.label1.Text = " Umbral = " + trackBar1.Value.ToString();
            this.ImagenSalida.Image = PictureAnalizer.Umbralizar(PictureAnalizer.ImagenEntrada, trackBar1.Value);
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            if (manualToolStripMenuItem.Checked)
            {
                for (int i = 0; i < 50; i++)
                {
                    this.Width++;
                    this.Refresh();
                }
                manualToolStripMenuItem.Checked = false;
            }
            else
            {
                for (int i = 0; i < 50; i++)
                {
                    this.Width--;
                    this.Refresh();
                }
                manualToolStripMenuItem.Checked = true;
            }*/
            
        }

        // probar todas las imagenes de una carpeta 
        private void desdeCarpetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog c = new FolderBrowserDialog();
            c.ShowDialog();

            string rutaCarpetaTest = c.SelectedPath;

            // buscar todos lo archivos de imagen en el directorio 
            DirectoryInfo dirs = new DirectoryInfo(rutaCarpetaTest);

            // recorrer cada archivo en el directorio 
            int b = 0;
            foreach( var im in dirs.GetFiles("*.jpg", SearchOption.AllDirectories))
            {
                Bitmap imEnt = new Bitmap(im.FullName);

                Analizador.SetImagenEntrada( imEnt );
                Analizador.SetImagenSalida(PictureAnalizer.ImagenColor2Gray(imEnt));

                ImagenEntrada.Image = PictureAnalizer.ImagenEntrada;
                ImagenSalida.Image = PictureAnalizer.ImagenEntrada;
                ImagenEntrada.Refresh();
                ImagenSalida.Refresh();
                System.Threading.Thread.Sleep(100);

                // crear un histograma
                int[] h = PictureAnalizer.Histograma(PictureAnalizer.ImagenEntrada);
                double[] hn = PictureAnalizer.HistogramaNormal(PictureAnalizer.ImagenEntrada, h);

                // realizar una umbralizacion 
                int t = PictureAnalizer.Otsu(hn);
                this.ImagenSalida.Image = PictureAnalizer.Umbralizar(PictureAnalizer.ImagenEntrada, t);
                imEnt = (Bitmap) this.ImagenSalida.Image;
                //PictureAnalizer.GuardarImagenSalida((Bitmap) PictureAnalizer.ImagenEntrada, this.RutaGuardado + "\\OtsuEntrada" + b.ToString()  + im.Name );

                PictureAnalizer.GuardarImagenSalida( (Bitmap) this.ImagenSalida.Image, this.RutaGuardado + "\\OtsuSalida" + b.ToString() + im.Name );
                PictureAnalizer.GuardarImagenSalida( PictureAnalizer.DilatarImagen(imEnt, this.MascaraActual,255) , this.RutaGuardado + "\\SalidaDilatada" + b.ToString() + im.Name);
                PictureAnalizer.GuardarImagenSalida( PictureAnalizer.ErocionarImagen(imEnt, this.MascaraActual, 255), this.RutaGuardado + "\\SalidaErocionada" + b.ToString() + im.Name);
                PictureAnalizer.GuardarImagenSalida( PictureAnalizer.Cerradura(imEnt, this.MascaraActual), this.RutaGuardado + "\\SalidaCerradura" + b.ToString() + im.Name);
                PictureAnalizer.GuardarImagenSalida( PictureAnalizer.Apertura(imEnt, this.MascaraActual), this.RutaGuardado + "\\SalidaApertura" + b.ToString() + im.Name);
                PictureAnalizer.GuardarImagenSalida( PictureAnalizer.ExtBorde(imEnt, this.MascaraActual), this.RutaGuardado + "\\SalidaBorde" + b.ToString() + im.Name);

                b++;
                ImagenSalida.Refresh();
                
                System.Threading.Thread.Sleep(100);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

        private void destinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog c = new FolderBrowserDialog();
            c.ShowDialog();
            this.RutaGuardado = c.SelectedPath;
        }

        private void dilatacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ImagenSalida.Image = PictureAnalizer.DilatarImagen( (Bitmap)ImagenSalida.Image, this.MascaraActual, 255);
        }

        private void cuadradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.ImagenSalida.Image =  PictureAnalizer.DibujarCuadradoEn(200,200, 100, 100,  new Point(10,10) ,Color.Red);
        }

        private void erocionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ImagenSalida.Image = PictureAnalizer.ErocionarImagen((Bitmap)ImagenSalida.Image, this.MascaraActual, 255);
        }

        private void cerraduraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ImagenSalida.Image = PictureAnalizer.Cerradura( (Bitmap)ImagenSalida.Image, this.MascaraActual ) ;
        }

        private void aperturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ImagenSalida.Image = PictureAnalizer.Apertura( (Bitmap)ImagenSalida.Image, this.MascaraActual);
        }

        private void dilatacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bordeToolStripMenuItem_Click(object sender, EventArgs e)
        {


            this.ImagenSalida.Image = PictureAnalizer.ExtBorde((Bitmap)ImagenSalida.Image, this.MascaraActual);



        }

        // agregar una imagen en escala de gris o en color, fijar la imagen de entrada
        private void button1_Click(object sender, EventArgs e)
        {
            this.ImagenEntrada.Image = PictureAnalizer.BuscarImagen();
            this.ImagenSalida.Image = PictureAnalizer.ImagenSalida;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form2 Resultado = new form2();
            Resultado.Show();
            PictureAnalizer.ImagenEntrada = PictureAnalizer.ImagenSalida;
        }


    }
}
