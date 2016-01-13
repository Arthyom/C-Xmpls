using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xmpl1C
{
    public partial class Form4 : Form
    {

        private Graphics papel;
        public Form4()
        {
            InitializeComponent();
            // elementos disponibles en el formulario 
             papel = pictureBox1.CreateGraphics();
            

            // asignar las propiedades de las barras 
            trackBar1.Minimum = 0;
            trackBar1.Maximum = pictureBox1.Height;
            label1.Text = Convert.ToString(trackBar1.Value);

            trackBar2.Minimum = 0;
            trackBar2.Maximum = pictureBox1.Width;
            label2.Text = Convert.ToString(trackBar2.Value);

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Brush broca = new SolidBrush(Color.Red);
            label1.Text = Convert.ToString(trackBar1.Value );
            papel.Clear(Color.White);
            papel.FillEllipse(broca, 0, 0, trackBar1.Value, trackBar2.Value);
            


        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Brush broca = new SolidBrush(Color.Red);
            label1.Text = Convert.ToString(trackBar1.Value);
            papel.Clear(Color.White);
            papel.FillEllipse(broca, 0, 0, trackBar1.Value, trackBar2.Value);
        }
    }
}
