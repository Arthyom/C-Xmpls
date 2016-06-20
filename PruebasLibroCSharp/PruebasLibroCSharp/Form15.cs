using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebasLibroCSharp
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {


            

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // metodos graficos complejos 
            Graphics objetoGrafico = e.Graphics;

            // elementos generales usados en el programa
            Rectangle dib2 = new Rectangle(12, 34, 100, 140);
            SolidBrush brocha = new SolidBrush(Color.Red);
            Pen lapiz = new Pen(Color.Black);
            Bitmap mapabit = new Bitmap(10, 10);
            LinearGradientBrush linard = new LinearGradientBrush(dib2, Color.Red, Color.Black, (float)34.23, false);

            // dibujar objetos 
            objetoGrafico.DrawRectangle(lapiz, dib2);
            objetoGrafico.FillRectangle(brocha, dib2);


       



        }
    }
}
