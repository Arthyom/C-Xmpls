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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dibujarTrignaulos(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
        }

        // metodo para dibujar triangulos 
        public void dibujarTrignaulos(float xOr, float yOrg, float xEnd, float yEnd)
        {
            Graphics papel = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(Color.Blue);

            papel.DrawLine(lapiz, xOr, yOrg, xEnd, yEnd);
            papel.DrawLine(lapiz, xOr, yOrg, xEnd, yEnd-30);
            papel.DrawLine(lapiz, xEnd, yEnd-30, xEnd, yEnd);
        }
    }
}
