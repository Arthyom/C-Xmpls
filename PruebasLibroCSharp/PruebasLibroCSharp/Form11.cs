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
            SolidBrush brocha = new SolidBrush(Color.White);

            // crear cadena de dibujo para el rectangulo de fondo
            grafico.FillRectangle(brocha, 10, 10, 200, 200);




            // crear una brocha para los colores traseros
            SolidBrush bt = new SolidBrush(this.ColorTrasero);

            // crear rectangulos trasero
            grafico.FillRectangle(bt, 50, 50, 100, 100);



            // crear brochas para el rectangulo primario
            SolidBrush bf = new SolidBrush(this.ColorFrente);

            // crear el rectangulo frontal
            grafico.FillRectangle(bf, 60, 60, 150, 150);




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
            // cambiar el color del rectangulo trasero 
            this.ColorTrasero = Color.FromName(textBox1.Text);
            Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ColorFrente = Color.FromArgb(Convert.ToInt16(textBox2.Text), Convert.ToInt16(textBox3.Text), Convert.ToInt16(textBox4.Text), Convert.ToInt16(textBox5.Text)) ;
            Invalidate();
        }
    }
}
