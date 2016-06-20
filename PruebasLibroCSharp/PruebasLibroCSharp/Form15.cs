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
            Rectangle dib2 = new Rectangle(50, 34, 140, 240);
            Rectangle dib3 = new Rectangle(0, 0, 150, 240);
            Rectangle dib4 = new Rectangle(90, 30, 100,110);
            SolidBrush brocha = new SolidBrush(Color.Blue);
            Pen lapiz = new Pen(Color.Black);
            Image mi = Image.FromFile(@"C:\Users\frodo\Pictures\p.jpg");
            Bitmap mapabit = new Bitmap(mi);
            LinearGradientBrush linard = new LinearGradientBrush(dib2, Color.Red, Color.Black, (float)50.23, true);

            // dibujar objetos 
            objetoGrafico.DrawRectangle(lapiz, dib2);
            objetoGrafico.FillRectangle(brocha, dib2);

            TextureBrush txt = new TextureBrush(mapabit);

            // dibujar rectangulos con textura
            objetoGrafico.FillRectangle(linard, dib3);
            objetoGrafico.DrawRectangle( new Pen(Color.Green,3), dib3);
            objetoGrafico.FillRectangle( new SolidBrush( Color.Aqua), dib3);

            // dibujar pastel
            objetoGrafico.DrawPie(lapiz, dib4, 23, 100);
            objetoGrafico.FillPie(txt, dib4, 50, 120);
           
        



        }
    }
}
