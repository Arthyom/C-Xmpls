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
    public partial class Form11 : Form
    {
        // defnir colores de prueba 
        public Color ColorFrente;
        public Color ColorTrasero;
        public Color ColorFondo = Color.White;

        // redefinir el metodo de dibujo
        protected override void OnPaint(PaintEventArgs e)
        {

            // conseguir el objeto grafico
            Graphics grafico = e.Graphics;

            // crear lapiz para esquinas
            Pen lapiz = new Pen(Color.Black);

            // crear brocha para el fondo
            SolidBrush brocha = new SolidBrush(this.ColorFondo);

            // crear cadena de dibujo para el rectangulo de fondo
            grafico.FillRectangle(brocha, 10, 10, 200, 200);



            base.OnPaint(e);
        }


        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ColorFondo = Color.FromName(this.textBox1.Text);
            Invalidate();
        }
    }
}
