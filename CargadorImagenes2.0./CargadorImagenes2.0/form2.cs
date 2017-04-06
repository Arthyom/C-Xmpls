using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargadorImagenes2._0
{
    public partial class form2 : Form
    {
        public PictureAnalizer PAForm2;
        public Mascara MascaraGenerica1;
        public Mascara MascaraGenerica2;




        public form2()
        {
            InitializeComponent();
        }

        private void ImagenEntrada_Click(object sender, EventArgs e)
        {

        }

        private void form2_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.ImagenEntrada.Image = (Image) PictureAnalizer.Umbralizar(PictureAnalizer.ImagenEntrada, trackBar1.Value);
            this.label1.Text = trackBar1.Value.ToString();
        }

        // otsu automatico
        private void button1_Click(object sender, EventArgs e)
        {
            int [] h = PictureAnalizer.Histograma(PictureAnalizer.ImagenEntrada);
            double[] hn = PictureAnalizer.HistogramaNormal(PictureAnalizer.ImagenEntrada, h);
            int t = PictureAnalizer.Otsu(hn);

            MessageBox.Show("", t.ToString() );
            this.ImagenEntrada.Image = (Image)PictureAnalizer.Umbralizar(PictureAnalizer.ImagenEntrada, t );
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public int restarDelimitadores ( string delim, string [] cadena)
        {
            int num = 0;
            foreach ( string c in cadena )
            {
                if (c != delim)
                    num++;
            }
            return num;
        }

        public Mascara conseguirMascara ( TextBox TextoOrigen )
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

            this.MascaraGenerica1 = conseguirMascara( this.TextMascara);

            this.ImagenEntrada.Image = (Image) PictureAnalizer.SuavisarImagen(this.MascaraGenerica1);


           

            
         




        }

        public void ImprimirPredf ( double [,] predef, TextBox CajaObejetivo )
        {
            CajaObejetivo.Text = "";
            for ( int i = 0; i < Math.Sqrt( predef.Length ); i ++ )
            {
                for (int j = 0; j < Math.Sqrt( predef.Length); j++)
                {
                    CajaObejetivo.Text += predef[j, i].ToString();
                    if (j != Math.Sqrt(predef.Length ) - 1)
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


           this.ImagenEntrada.Image = (Image) PictureAnalizer.DetectarBordes(MascaraGenerica1, MascaraGenerica2, c);
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
    }
}
