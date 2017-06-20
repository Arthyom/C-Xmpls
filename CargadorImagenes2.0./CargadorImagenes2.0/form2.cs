using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using AForge.Neuro;
using AForge.Math;
using AForge.Neuro.Learning;

using Emgu.CV.Util;
using Emgu.CV.Structure;
using System.IO;
using System.Collections;


namespace CargadorImagenes2._0
{
    public partial class form2 : Form
    {
        public PictureAnalizer PAForm2;
        public Mascara MascaraGenerica1;
        public Mascara MascaraGenerica2;
        public bool Fcam;
        Capture cam;
        public System.Drawing.Bitmap ImgOriginal; 
        public string rutaEjemplos = @"C:\Users\frodo\Desktop\ejemplos\";




        public form2()
        {
            InitializeComponent();
        }

        private void ImagenEntrada_Click(object sender, EventArgs e)
        {

        }

        private void form2_Load(object sender, EventArgs e)
        {
            
            ImagenEntrada.Image = PictureAnalizer.ImagenSalida;
            this.ImgOriginal =(Bitmap) ImagenEntrada.Image;
            
            this.ChrtHistoSimple.ChartAreas.Add("Area1");
            this.ChrtAcum.ChartAreas.Add("Area1");

            // this.cam = new Emgu.CV.Capture();
            // Application.Idle += new EventHandler(Grabar);


        }

        void Grabar ( Object sender , EventArgs e)
        {
            this.ImagenEntrada.Image = PictureAnalizer.Umbralizar(cam.QueryFrame().Bitmap,120);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.ImagenEntrada.Image = (Image)PictureAnalizer.Umbralizar(PictureAnalizer.ImagenEntrada, trackBar1.Value);
            this.label1.Text = trackBar1.Value.ToString();
        }

        // otsu automatico
        private void button1_Click(object sender, EventArgs e)
        {
            int[] h = PictureAnalizer.Histograma((Bitmap)ImagenEntrada.Image);
            double[] hn = PictureAnalizer.HistogramaNormal((Bitmap)ImagenEntrada.Image);
            int t = PictureAnalizer.Otsu(hn);

            MessageBox.Show("", t.ToString());
            ImagenEntrada.Image = PictureAnalizer.Umbralizar((Bitmap)ImagenEntrada.Image, t);
           
          
        }

        // erocionar imagen
        private void button2_Click(object sender, EventArgs e)
        {
            Mascara m = conseguirMascara(Txt_Otros);
            int color = (int)Selector_Brillo.Value;
            PictureAnalizer.ImagenEntrada = PictureAnalizer.ErocionarImagen(PictureAnalizer.ImagenEntrada, m, color);
            ImagenEntrada.Image = PictureAnalizer.ImagenEntrada;
        }

        public int restarDelimitadores(string delim, string[] cadena)
        {
            int num = 0;
            foreach (string c in cadena)
            {
                if (c != delim)
                    num++;
            }
            return num;
        }

        public Mascara conseguirMascara(TextBox TextoOrigen)
        {
            string[] f = TextoOrigen.Text.Split('\r', '\n');
            string[] c = f[0].Replace('\r', '#').Split(' ');

            int filas = TextoOrigen.Text.Split('\n').Length;
            int clmns = this.restarDelimitadores("#", c);

            string[] n = new string[filas * clmns];
            double[,] val = new double[filas, clmns];

            int i = 0;
            foreach (string s in f)
            {
                if (s != "")
                {
                    string[] k = s.Split(' ');

                    for (int j = 0; j < k.Length; j++)
                    {
                        n[i] = k[j];
                        i++;
                    }
                }
            }

            int o = 0;
            for (int z = 0; z < filas; z++)
            {
                for (int j = 0; j < clmns; j++)
                {
                    val[j, z] = Convert.ToDouble(n[o]);
                    o++;
                }
            }


            Mascara m = new Mascara(val, new Size(filas, clmns), new Point(1, 1));


            return m;
        }

        // objetner los caracteres de la mascara de entrada y contarlos
        private void CalcularMascara_Click(object sender, EventArgs e)
        {

            this.MascaraGenerica1 = conseguirMascara(this.TextMascara);

            PictureAnalizer.ImagenEntrada = PictureAnalizer.SuavisarImagen(this.MascaraGenerica1,(Bitmap)ImagenEntrada.Image);

            ImagenEntrada.Image = PictureAnalizer.ImagenEntrada;


        }

        public void ImprimirPredf(double[,] predef, TextBox CajaObejetivo)
        {
            CajaObejetivo.Text = "";
            for (int i = 0; i < Math.Sqrt(predef.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(predef.Length); j++)
                {
                    CajaObejetivo.Text += predef[j, i].ToString();
                    if (j != Math.Sqrt(predef.Length) - 1)
                        CajaObejetivo.Text += " ";


                }
                if (i != Math.Sqrt(predef.Length) - 1)
                    CajaObejetivo.Text += @"
";
            }
        }

        private void EnfocarOpt_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Msk_Enfkr, this.TextMascara);

        }

        private void DesEnfOpt_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Msk_Dsfkr, this.TextMascara);
        }

        private void RepuOpt_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Msk_Rpgdo, this.TextMascara);
        }

        private void RealzarBordeOpt_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Msk_Rbrds, this.TextMascara);
        }

        private void DetectarBordeOpt_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Msk_DBrds, this.TextMascara);
        }

        private void AfiladoBords_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Msk_ABrds, this.TextMascara);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Relieve_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Msk_Rliev, this.TextMascara);
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_RbrX, this.MascaraTextX);
        }

        private void DetectarBorde_Click(object sender, EventArgs e)
        {
            this.MascaraGenerica1 = conseguirMascara(MascaraTextX);
            this.MascaraGenerica2 = conseguirMascara(MascataTxtY);

            int c = 0;

            if (ImagenEnXOpt.Checked)
                c = 1;
            else
                if (ImagenEnY.Checked)
                c = -1;
            else
                if (ImagenEnZOpt.Checked)
                c = 0;


            this.ImagenEntrada.Image = (Image)PictureAnalizer.DetectarBordes(MascaraGenerica1, MascaraGenerica2, c, (Bitmap) ImagenEntrada.Image);
        }

        private void MascataTxtY_TextChanged(object sender, EventArgs e)
        {

        }

        private void RobertsYOpt_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_RbrY, this.MascataTxtY);
        }

        private void SobelXOpt_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_SblX, this.MascaraTextX);
        }

        private void SolbelYOpt_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_SblY, this.MascataTxtY);
        }

        private void PrewittXOpt_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_PrwX, this.MascaraTextX);
        }

        private void PrewittYOpt_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_PrwY, this.MascataTxtY);
        }

        private void LaPlaceYOpy_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_LpcY, this.MascataTxtY);
        }

        private void LaPlaceXOpt_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_LPcX, this.MascaraTextX);
        }

        private void FriChenXOpt_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_FrcX, this.MascaraTextX);
        }

        private void FriChenYOpt_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_FrcY, this.MascataTxtY);
        }

        private void completoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.completoToolStripMenuItem.Checked = true;
            this.imagenToolStripMenuItem.Checked = false;

            for (int i = 0; i < this.tabControl1.Width + 5; i += 6)
            {
                if (this.tabControl1.Width + this.ImagenEntrada.Width <= this.Width)
                    return;

                this.Width += i;
                this.Refresh();
            }

        }

        private void imagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.completoToolStripMenuItem.Checked = false;
            this.imagenToolStripMenuItem.Checked = true;

            for (int i = 0; i < this.tabControl1.Width + 5; i += 6)
            {
                if (this.Width - i <= this.ImagenEntrada.Width)
                    return;
                this.Width -= i;
                this.Refresh();
            }
        }

        private void form2_KeyUp(object sender, KeyEventArgs e)
        {

            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.S))
            {
                this.completoToolStripMenuItem.Checked = false;
                this.imagenToolStripMenuItem.Checked = true;

                for (int i = 0; i < this.tabControl1.Width + 5; i += 6)
                {
                    if (this.Width - i <= this.ImagenEntrada.Width)
                        return;
                    this.Width -= i;
                    this.Refresh();
                }

            } else
            {

                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.X))
                {
                    this.completoToolStripMenuItem.Checked = true;
                    this.imagenToolStripMenuItem.Checked = false;

                    for (int i = 0; i < this.tabControl1.Width + 5; i += 6)
                    {
                        if (this.tabControl1.Width + this.ImagenEntrada.Width <= this.Width)
                            return;

                        this.Width += i;
                        this.Refresh();
                    }
                }
            }
        }

        private List<Point> ExtraerPuntos(TextBox Origen)
        {
            string[] cm;
            string[] puntos = Origen.Text.Split(' ');
            List<string[]> ListaCoordenadas = new List<string[]>();
            List<Point> ListaVals = new List<Point>();

            foreach (string c in puntos)
            {
                cm = c.Split(',');
                ListaVals.Add(new Point(Convert.ToInt32(cm[0]), Convert.ToInt32(cm[0])));
            }

            return ListaVals;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExtraerPuntos(TxtPuntosPoligono);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label5.Text = "";
            ImagenEntrada.Image =  PictureAnalizer.CambiarBrillo(PictureAnalizer.ImagenEntrada, trackBar2.Value);
            label5.Text = trackBar2.Value.ToString();
        }
    
        // ajustar el brillo
        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        public void GraficarVector ( int [] vectVals , Chart graficaObjetivo)
        {
            // crear una nueva serie 
            string Serie = "Serie1";
            graficaObjetivo.Series.Add(Serie);

            graficaObjetivo.Series[Serie].ChartType = SeriesChartType.Column;
            graficaObjetivo.Series[Serie].Color = Color.Green;
            

            for (int i = 0; i < 256; i++)
                graficaObjetivo.Series[Serie].Points.AddXY(i, vectVals[i]);
        }

        public void GraficarVector(double [] vectVals, Chart graficaObjetivo)
        {
            // crear una nueva serie 
            string Serie = "Serie1";
            graficaObjetivo.Series.Add(Serie);

            graficaObjetivo.Series[Serie].ChartType = SeriesChartType.Column;
            graficaObjetivo.Series[Serie].Color = Color.Green;


            for (int i = 0; i < 256; i++)
                graficaObjetivo.Series[Serie].Points.AddXY(i, vectVals[i]);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            int[] h = PictureAnalizer.Histograma(PictureAnalizer.ImagenEntrada);
            GraficarVector( PictureAnalizer.HistogramaNormal(PictureAnalizer.ImagenEntrada), this.ChrtHistoSimple);
        }

        private void button11_Click(object sender, EventArgs e)
        {
           
            GraficarVector( PictureAnalizer.HistogramaAcumulado(PictureAnalizer.ImagenEntrada), this.ChrtAcum ) ;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Mascara Mx = conseguirMascara(hTxtX);
            Mascara MY = conseguirMascara(hTxtY);

            Bitmap s = PictureAnalizer.DibujarNegra(PictureAnalizer.ImagenEntrada.Width, PictureAnalizer.ImagenEntrada.Height);
          //  ImagenEntrada.Image = (Image)PictureAnalizer.TransHough(PictureAnalizer.ImagenEntrada,s,Mx,MY,(int)tetade.Value, (int) tetaHasta.Value);
          //  this.Pb_Sinus.Image = (Image)PictureAnalizer.MostrarAcms();
        }

        private void opt_RbrtsX_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_RbrX, hTxtX);
        }

        private void opt_RbrtsY_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_RbrY, hTxtY);
        }

        private void opt_SblX_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_SblX, hTxtX);
        }

        private void opt_Sbl_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_SblY, hTxtY);
        }

        private void opt_PwtX_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_PrwX, hTxtX);
        }

        private void opt_PwtY_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_PrwY, hTxtY);
        }

        private void opt_LplcX_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_LPcX, hTxtX);
        }

        private void opt_LplcY_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_LpcY, hTxtY);
        }

        private void Opt_FchnX_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_FrcX, hTxtX);
        }

        private void opt_FrchnY_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Opdr_FrcY, hTxtY);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            if ( s.ShowDialog() == DialogResult.OK )
            {
                Pb_Sinus.Image.Save(s.FileName);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Mascara Mx = conseguirMascara(hTxtX);
            Mascara MY = conseguirMascara(hTxtY);

            Bitmap s = PictureAnalizer.DibujarNegra(PictureAnalizer.ImagenEntrada.Width, PictureAnalizer.ImagenEntrada.Height);
            ImagenEntrada.Image = (Image)PictureAnalizer.TransHough(PictureAnalizer.ImagenEntrada, s, Mx, MY, (int)tetade.Value, (int)tetaHasta.Value, trackBar3.Value);
            this.Pb_Sinus.Image = (Image)PictureAnalizer.MostrarAcms();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            nlines.Text = " Numero de lineas " + trackBar3.Value.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Pb_Sinus.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            Pb_Sinus.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Pb_Sinus.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Image<Gray, byte> s = new Image<Gray, byte>(PictureAnalizer.ImagenEntrada);
            s = s.Canny(100, 50);
          //  s = s.HoughLinesBinary(1, Math.PI / 180, 100, 10, 10);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Dictionary<int, double>[] Hsr = PictureAnalizer.HistogramasSumaDiferencia(PictureAnalizer.ImagenEntrada);
            // media, varianza, homogen, energia, entropia, contraste
            double[] Carc = PictureAnalizer.CaracteristicasTextura(Hsr[0], Hsr[1]);

            lbl_Textr.Text = "";

            lbl_Textr.Text = " Media: " + Math.Round( Carc[0] ) + "\n" + " Varianza: " + Math.Round(Carc[1]) + "\n" + " Homogeneidad: " + Math.Round(Carc[2]) + "\n"
                + " Energia: " + Math.Round(Carc[3]) + "\n" + " Entropia: " + Math.Round(Carc[4]) + "\n" + " Contraste: " + Math.Round(Carc[5]) + "\n";

            PictureAnalizer.HNormSumasDifecs = Hsr;

            int c = 0 ;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Dictionary<int, double>[] Hsr = PictureAnalizer.HistogramasSumaDiferencia(PictureAnalizer.ImagenEntrada);

            PictureAnalizer.HNormSumasDifecs = Hsr;

            Bitmap[] img_Text = PictureAnalizer.ImagenDeTextura(PictureAnalizer.ImagenEntrada, PictureAnalizer.HNormSumasDifecs);

            pc_S1.Image = img_Text[0];
            pc_s2.Image = img_Text[1];
            pc_s3.Image = img_Text[2];
            pc_s4.Image = img_Text[3];
            pc_s5.Image = img_Text[4];
            pc_s6.Image = img_Text[5];

        }

        // dilatar imagen
        private void button3_Click(object sender, EventArgs e)
        {
            int color = (int)Selector_Brillo.Value;

            PictureAnalizer.ImagenEntrada = PictureAnalizer.DilatarImagen( PictureAnalizer.ImagenEntrada, this.conseguirMascara(Txt_Otros), color);
            ImagenEntrada.Image = PictureAnalizer.ImagenEntrada;
        }

        // T inferior
        private void radioButton10_CheckedChanged_1(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Estr_Tinf, Txt_Otros);
        }

        // centro
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Estr_Dizq, Txt_Otros);
        }

        // opt cruz
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Estr_Cruz, Txt_Otros);
        }

        // diagonal izquierda
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Estr_Dizq, Txt_Otros);
        }

        // derecho
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Estr_Dder, Txt_Otros);
        }

        // t superior
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Estr_Tsup, Txt_Otros);
        }

        // t derecha
        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Estr_TDer, Txt_Otros);
        }

        // t izquierda
        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Estr_TIzq, Txt_Otros);
        }

        // apertura
        private void button5_Click(object sender, EventArgs e)
        {
            int color = (int)Selector_Brillo.Value;
            PictureAnalizer.ImagenEntrada = PictureAnalizer.Apertura(PictureAnalizer.ImagenEntrada, conseguirMascara(Txt_Otros),color);
            ImagenEntrada.Image = PictureAnalizer.ImagenEntrada;
        }

        // cerradura de una imagen
        private void button6_Click(object sender, EventArgs e)
        {
            int color = (int)Selector_Brillo.Value;
            PictureAnalizer.ImagenEntrada = PictureAnalizer.Cerradura(PictureAnalizer.ImagenEntrada, conseguirMascara(Txt_Otros),color);
            ImagenEntrada.Image = PictureAnalizer.ImagenEntrada;
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            ImprimirPredf(Mascara.PRDF_Estr_Bcdd, Txt_Otros);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void imagenActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.ShowDialog();
            ImagenEntrada.Image.Save(sv.FileName);
            
            
        }

        private void combinarQrsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // poner los pixeles de la imagen obtenida en rojo
            for( int i = 0; i < PictureAnalizer.ImagenEntrada.Height; i ++ )
            {
                for (int j = 0; j < PictureAnalizer.ImagenEntrada.Width; j++)
                {
                    int c = PictureAnalizer.PixelColor2Gray(PictureAnalizer.ImagenEntrada.GetPixel(j, i));
                    if ( c == 0)
                        ImgOriginal.SetPixel(j, i, Color.Red);
                }
            }

            ImagenEntrada.Image = ImgOriginal;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // crear una imagen para contener las esquinas
            Image<Gray, float> ImgFuentes = new Image<Gray, float>(PictureAnalizer.ImagenEntrada);
            Image<Gray, float> ImgEsquinas = new Image<Gray, float>(PictureAnalizer.ImagenEntrada);

            CvInvoke.CornerHarris(ImgFuentes, ImgEsquinas, 3, 3, 0.01);

            PictureAnalizer.ImagenEntrada = ImgEsquinas.ToBitmap();
            ImagenEntrada.Image = PictureAnalizer.ImagenEntrada;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            Bitmap Hough_Im = new Image<Gray, byte>(PictureAnalizer.ImagenEntrada).Canny(100, 50).ToBitmap();
            ImagenEntrada.Image = Hough_Im;
        }

        private void button22_Click(object sender, EventArgs e)
        {
           
        }
        // jsm22
        private void button23_Click(object sender, EventArgs e)
        {
            Mascara m = new Mascara(Mascara.PRDF_Estr_Bcdd, new Size(3, 3), new Point(1, 1));
            ImagenEntrada.Image = PictureAnalizer.ExtBorde( (Bitmap)ImagenEntrada.Image, m);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            /**** 1 - humbralizar ******/
            Bitmap img_Exm_Ent = (Bitmap)ImagenEntrada.Image;
            Bitmap Org = (Bitmap)ImagenEntrada.Image;

            // conseguir histogramas para umbralizar
            int [] h = PictureAnalizer.Histograma(img_Exm_Ent);
            double[] hn = PictureAnalizer.HistogramaNormal(img_Exm_Ent);
            int umbral = PictureAnalizer.Otsu(hn);

            Bitmap img_Exm = PictureAnalizer.Umbralizar(img_Exm_Ent, umbral);
            PictureAnalizer.ImagenEntrada = img_Exm;
            ImagenEntrada.Image = img_Exm;
            ImagenEntrada.Image.Save("ImgHumbralizada.jpeg");
            ImagenEntrada.Refresh();


            /**** 2 - erocionar la imagen ******/
            Mascara ee = new Mascara(Mascara.PRDF_Estr_Bcdd, new Size(3, 3), new Point(1, 1));
            Bitmap cv = PictureAnalizer.ErocionarImagen(img_Exm, ee, 255);
            img_Exm = PictureAnalizer.ErocionarImagen(img_Exm, ee, 255);
            

            Bitmap cn = img_Exm;
            PictureAnalizer.ImagenEntrada = img_Exm;
            ImagenEntrada.Image = img_Exm;
            ImagenEntrada.Image.Save("ImgErocionada.jpeg");
            ImagenEntrada.Refresh();


                Mascara es = new Mascara(Mascara.PRDF_Estr_Cruz, new Size(3, 3), new Point(1, 1));
                img_Exm = PictureAnalizer.DilatarImagen(img_Exm, es,255);
                PictureAnalizer.ImagenEntrada = img_Exm;
                ImagenEntrada.Image = img_Exm;
            ImagenEntrada.Image.Save("ImgDilatada.jpeg");
            ImagenEntrada.Refresh();

            Bitmap sa = PictureAnalizer.DibujarNegra(cn.Width, cn.Height);

            for (int i = 0; i < cn.Height; i++)
            {
                for (int j = 0; j < cn.Width; j++)
                {
                    int cOr = PictureAnalizer.PixelColor2Gray(img_Exm.GetPixel(j, i));

                    if (cOr == 255)
                    {
                        int cON = PictureAnalizer.PixelColor2Gray(cv.GetPixel(j, i));
                        sa.SetPixel(j, i, Color.FromArgb(cON, cON, cON));
                    }



                }
            }

            ImagenEntrada.Image = sa;
            Bitmap sae = PictureAnalizer.DibujarNegra(cn.Width, cn.Height);

            for (int i = 0; i < cn.Height; i++)
            {
                for (int j = 0; j < cn.Width; j++)
                {
                    int cOr = PictureAnalizer.PixelColor2Gray(sa.GetPixel(j, i));

                    if (cOr > 0)
                    {
                        int cON = PictureAnalizer.PixelColor2Gray(Org.GetPixel(j, i));
                        sae.SetPixel(j, i, Color.FromArgb(cON, cON, cON));
                    }



                }
            }

            ImagenEntrada.Image = sae;
            ImagenEntrada.Image.Save("ImgCombinada.jpeg");
            ImagenEntrada.Refresh();



        }

        private void button25_Click(object sender, EventArgs e)
        {
            ImagenEntrada.Image = PictureAnalizer.MoverInvertido( (Bitmap)ImagenEntrada.Image, 0);
        }

        public ActivationNetwork  CrearRNA ( double[][] ListEnt, double [][] LisSalidas )
        {
            
     
            // crear la red neuronal
            
            ActivationNetwork RNA = new ActivationNetwork( new SigmoidFunction(2) ,6,6,6,4);
            

            // generar el aprendizaje 
            BackPropagationLearning Maestr = new BackPropagationLearning(RNA);
            
            Maestr.LearningRate = 0.004;



            // entrenar para cada pieza en la lista 
            
                bool detenerse = false;
                int i = 0;
            double error2 = 0;


                while (!detenerse)
                {
                    
                   double error = Maestr.RunEpoch(ListEnt, LisSalidas);
                    
                    Console.WriteLine("      " + error + "   " + i + "    " + Maestr.LearningRate);
                    if (error < 430)
                        detenerse = true;

                /*
            if ( Math.Abs( error - error2 ) > 1)
                Maestr.LearningRate += -0.0001;
            else
                if (Math.Abs(error - error2) < 1 && Math.Abs(error - error2) > 0)
                Maestr.LearningRate += -0.00001;
            else
                if (Math.Abs(error - error2) == 0)
                Maestr.LearningRate += 0.001;
                */

                error2 = error;

                i++;
                }
             
            
            

         
        

            return RNA;
        }

        private void button26_Click(object sender, EventArgs e)
        {

            string[] nombres = { "Vacio", "Torres", "Caballos", "Alfiles", "Reinas", "Reyes", "Peones" };

            //ActivationNetwork rna = EntrenarRNA();

            // rna.Save("save1.rna");
            // para cada imagen en la direccion de entrenamiento
            DirectoryInfo sc = new DirectoryInfo(rutaEjemplos);
            FileInfo[] s = sc.GetFiles();
            Bitmap[,] Matzs = null;
            double[][] Carz = new double[8 * 8][];
            double[] Obj = {
                1,2,3,4,5,3,2,1,
                6,6,6,6,6,6,6,6,
                0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,
                6,6,6,6,6,6,6,6,
                1,2,3,4,5,3,2,1,
            };

            for (int k = 0; k < 64; k++)
                Carz[k] = new double[6];

            int b = 0;
            foreach (FileInfo imgEjemp in s)
            {
                ImagenEntrada.Image = PictureAnalizer.ImagenColor2Gray((Bitmap)Image.FromFile(imgEjemp.FullName));
                PictureAnalizer.ImagenEntrada = (Bitmap)ImagenEntrada.Image;

                Mascara mX = new Mascara(Mascara.PRDF_Opdr_LPcX, new Size(3, 3), new Point(1, 1));
                Mascara mY = new Mascara(Mascara.PRDF_Opdr_LpcY, new Size(3, 3), new Point(1, 1));

                ImagenEntrada.Image = PictureAnalizer.DetectarBordes(mX, mY, 0, (Bitmap)ImagenEntrada.Image);
                ImagenEntrada.Image.Save(@"C:\Users\frodo\Desktop\ejemplos - copia\"+"imgBorde"+b.ToString() +".jpeg");
                b++;


                Matzs = PictureAnalizer.DividirImagen((Bitmap)ImagenEntrada.Image, 8);
                ImagenEntrada.Refresh();
                System.Threading.Thread.Sleep(1000);


                int n = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Bitmap im = Matzs[j, i];
                        ImagenEntrada.Image = im;
                        int p = (int)Obj[n];
                        string dir = "Piesas/" + nombres[p] + "/";
                        DirectoryInfo dest = new DirectoryInfo(dir);
                        FileInfo[] infDir = dest.GetFiles();
                        switch (p)
                        {
                            case 0: im.Save(dir + nombres[p] + infDir.Length + ".jpeg"); break;
                            case 1: im.Save(dir + nombres[p] + infDir.Length + ".jpeg"); break;
                            case 2: im.Save(dir + nombres[p] + infDir.Length + ".jpeg"); break;

                            case 3: im.Save(dir + nombres[p] + infDir.Length + ".jpeg"); break;
                            case 4: im.Save(dir + nombres[p] + infDir.Length + ".jpeg"); break;
                            case 5: im.Save(dir + nombres[p] + infDir.Length + ".jpeg"); break;
                            case 6: im.Save(dir + nombres[p] + infDir.Length + ".jpeg"); break;
                        }

                        Carz[n] = PictureAnalizer.CalcularCaracteristicasTextura(im);


                        for (int v = 0; v < Carz[n].Length; v++)
                            Console.WriteLine(Carz[n][v]);





                            ImagenEntrada.Refresh();
                        System.Threading.Thread.Sleep(100);
                        n++;
                    }
                }

            }

            

            

          

            List<Bitmap[]> ListaEntradas = new List<Bitmap[]>();
            List<double[][]> ListaCarz = new List<double[][]>();
            double carTota = 0;
            for (int k = 0; k < 7; k++)
            {
                ListaEntradas.Add(new Bitmap[1]);
                ListaCarz.Add(new double[6][]);
            }


            string[] rutasInternas = Directory.GetDirectories("Piesas/");
            for (int i = 0; i < rutasInternas.Length; i++)
            {
                string ruta = rutasInternas[i];
                string[] rutaSgmnt = ruta.Split('/');
                int indx = Array.IndexOf(nombres.ToArray(), rutaSgmnt[1]);
                DirectoryInfo infDir = new DirectoryInfo(ruta);
                FileInfo[] infFile = infDir.GetFiles("*.jpeg", SearchOption.AllDirectories);
                Bitmap[] imgArr = new Bitmap[infFile.Length];
                double[][] carArr = new double[infFile.Length][];
                carTota += infFile.Length;

                for (int j = 0; j < imgArr.Length; j++)
                {
                    imgArr[j] = (Bitmap)Image.FromFile(infFile[j].FullName);
                    carArr[j] = PictureAnalizer.CalcularCaracteristicasTextura(imgArr[j]);

                }

                ListaEntradas[indx] = imgArr;
                ListaCarz[indx] = carArr;
            }

            double[][] lSalidas = new double[(int)carTota][];

            // { "Vacio", "Torres", "Caballos","Alfiles", "Reinas", "Reyes", "Peones" };


            int c = 2;

            double[][] MatEntr = new double[(int)carTota][];
            int t = 0;
            int pi = 0;
            foreach (double[][] Mat in ListaCarz)
            {
                foreach (double[] vector in Mat)
                {
                    MatEntr[t] = vector;

                    switch (pi)
                    {
                        case 0: lSalidas[t] = new double[] { 0, 0, 0, 0 }; break;
                        case 1: lSalidas[t] = new double[] { 0, 0, 0, 1 }; break;
                        case 2: lSalidas[t] = new double[] { 0, 0, 1, 0 }; break;
                        case 3: lSalidas[t] = new double[] { 0, 0, 1, 1 }; break;
                        case 4: lSalidas[t] = new double[] { 0, 1, 0, 0 }; break;
                        case 5: lSalidas[t] = new double[] { 0, 1, 0, 1 }; break;
                        case 6: lSalidas[t] = new double[] { 0, 1, 1, 0 }; break;

                    }

                    t++;
                }
                pi++;

            }

            ActivationNetwork rna = null;
            if (!Directory.Exists("rnsa.rna"))
            {
                rna = CrearRNA(MatEntr, lSalidas);
                rna.Save("rnsa.rna");
            }
            else
                rna = (ActivationNetwork)Network.Load("rnsa.rna");

            Bitmap [] ns =  ListaEntradas[0];
            foreach( Bitmap x in ns )
            {
                double [] text = rna.Compute( PictureAnalizer.CalcularCaracteristicasTextura(x) );



                int l = 0;
                for (int f = 0; f < text.Length; f++)
                {


                    if (text[f] == 1)
                        l += (int)Math.Pow(2, f);

                }
                Console.Write(l + " ");
            }

                    
           

            // generar arbol
            nodo r = new nodo(8, "s");

            arbol a1 = new arbol();
            r.tablero = a1.TabEjemplo;
            a1.raiz = r;

            arbol a2 = new arbol();
            r.tablero = a2.TabEjemplo;
            a2.raiz = r;
            imprimirTablero(r);

            nodo n1 = a1.generarMovimientos(a1.raiz, arbol.ColorBlanco);
            imprimirTablero(n1);


            for (int i = 0; i < 10; i++)
            {
                n1 = a1.generarMovimientos(n1, arbol.ColorBlanco);
                imprimirTablero(n1);

                nodo n2 = a2.generarMovimientos(n1, arbol.ColorNegroo);
                imprimirTablero(n2);

                n1 = n2;
            }

        }

        private void imprimirTablero ( nodo nodoEntrada )
        {

            double dy = Math.Round( (double)chesagrp.Height / 10);
            double dx = Math.Round( (double)chesagrp.Width / 10);

            chesagrp.Controls.Clear();
            chesagrp.Refresh();

            for ( int i = 0; i < 8; i ++ )
            {
                for ( int j = 0; j < 8; j ++ )
                {
                    Label l = new Label();
                    l.Size = new Size((int)dx, (int)dy);
                    l.Location = new Point((int)((j + 1) * dx), (int)((i + 1) * dy));
                    if ( nodoEntrada.tablero[j,i] != arbol.CasillaVacia )
                    l.Text = nodoEntrada.tablero[j, i].ToString();
                    l.ForeColor = Color.White;
                    if (i % 2 == 0 )
                        if (j % 2 == 0)
                            l.BackColor = Color.Black;
                        else
                            l.BackColor = Color.Red;

                    else
                        if (j % 2 != 0)
                            l.BackColor = Color.Black;
                        else
                            l.BackColor = Color.Red;

                    chesagrp.Controls.Add(l);
                    l.Refresh();
                }
            }
            System.Threading.Thread.Sleep(600);
           
        }
    }
}
