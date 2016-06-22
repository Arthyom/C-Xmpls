using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PruebasLibroCSharp
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // conseguir lapiz y brocha
            Pen lapiz = new Pen(Color.Black);
            SolidBrush brocha = new SolidBrush(Color.Red);

            // crear una estrella, figura compleja apartir de rutas 

            // crear una ruta grafica
            GraphicsPath Estrella = new GraphicsPath();

            // arreglo de coordenadas 
            int[] PuntosX = { 55, 67, 109, 73, 83, 55, 27, 37, 1, 43 };
            int[] PuntosY = { 0, 36, 36, 54, 96, 72, 96, 54, 36, 36 };

            // agregar puntos a la esstrella, crear lineas, 
            for (int i = 0; i <= 8; i+=2)
                Estrella.AddLine(PuntosX[i], PuntosY[i], PuntosX[i + 1], PuntosY[i + 1]);

            // cerrar el camino de puntos
            Estrella.CloseFigure();

            // conseguir el objeto grafico
            Graphics obj = e.Graphics;

            // mover el origen a 1150
            obj.TranslateTransform(150, 150);
            lapiz.Color = Color.Red;
            lapiz.Width = 10;
            obj.DrawLine(lapiz,0, 0, 1, 1);

            Random r = new Random();
            lapiz.Color = Color.Red;
            lapiz.Width = 3;

            // dibujar 20 estretllas 
            for( int i = 0; i < 1; i ++)
            {
                obj.RotateTransform(0);
                brocha.Color = Color.FromArgb( Convert.ToByte(r.Next(255)), Convert.ToByte(r.Next(255)), Convert.ToByte(r.Next(255)), Convert.ToByte(r.Next(255)));
                obj.FillPath(brocha, Estrella);

                if (i == 0)
                    obj.DrawPath(lapiz, Estrella);

            }
        }

        // conseguir coordenadas del clik
        private void Form16_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Coordernada X: " + e.X + " Coordeada Y: " + e.Y);

        }
    }
}
