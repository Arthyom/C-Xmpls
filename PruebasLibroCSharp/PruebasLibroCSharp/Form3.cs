using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebasLibroCSharp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // iniciar los controles 
            this.numericUpDown1.Increment = 1;
            this.numericUpDown2.Increment = 1;
           // this.pictureBox1.BackColor = Color.White;

            Graphics p = pictureBox1.CreateGraphics();
            Pen l = new Pen(Color.Aquamarine);

            p.DrawLine(l, 34, 34, 100, 345);
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // generar una cantidad n de lineas desde Nminimo hasta Nmaximo

            Random GenAlt = new Random();
            int delta = Convert.ToInt16(this.numericUpDown1.Text) - Convert.ToInt16(this.numericUpDown2.Text);

            for (int i = 0; i < delta; i++)
            {
              
                // crear una nueva linea
                Graphics Papel = this.pictureBox1.CreateGraphics();
                Pen Lapiz = new Pen(Color.Red);
                Point p1 = new Point(GenAlt.Next(this.pictureBox1.Width), GenAlt.Next(this.pictureBox1.Width));
                Point p2 = new Point(GenAlt.Next(this.pictureBox1.Width), GenAlt.Next(this.pictureBox1.Width));

                Papel.DrawLine(Lapiz, p2, p1);

            }

            


        }
    }
}
