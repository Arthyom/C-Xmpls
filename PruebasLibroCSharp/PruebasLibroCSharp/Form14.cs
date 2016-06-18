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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }

        // sobreescribir el metodo onpaint
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // conseguir familias
            Font arial = new Font("Arial", 12);
            FontFamily familia = arial.FontFamily;

            // crear una brocha 
            SolidBrush brocha = new SolidBrush(Color.Red);
            Pen lapiz = new Pen(Color.Blue);

            // dibujar metricas de la fuente actual
            Graphics objetoGrafico = e.Graphics;
            objetoGrafico.DrawString("Esta es una cadena de entrada" + familia.GetCellAscent(FontStyle.Regular), arial, brocha, 10, 23);

            // dibujo de lineas y rectangulos
            objetoGrafico.DrawRectangle(lapiz, 10, 10, 200, 200);
            objetoGrafico.FillRectangle(brocha, 10, 10, 200, 200);

            // dibujo de lineas 
            objetoGrafico.DrawLine(lapiz, 10, 23, 90, 100);
            objetoGrafico.DrawLine(new Pen(Color.Aqua), 10, 23, 90, 100);

            // dibujo de elipses 
            objetoGrafico.FillEllipse(brocha, 10, 20, 34, 50);
            objetoGrafico.DrawEllipse( new Pen(Color.Beige,10), 20, 10, 100, 200);

            // crear un rectangulo
            Rectangle rc = new Rectangle(210, 32, 123, 300);

            // dibjar arcos 
            objetoGrafico.DrawArc(lapiz, rc, 12, 90);
            objetoGrafico.DrawArc(lapiz, rc, 10, 190);

            // llenar rectangulo
            objetoGrafico.FillPie(brocha, rc, 10, 203);
            objetoGrafico.FillPie( new SolidBrush(Color.Black), rc, 110, 283);



        }
    }
}
