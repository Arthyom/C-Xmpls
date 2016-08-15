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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            Invalidate();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics ObejtoGrafico = e.Graphics;

            // conseguir brochar y lapices
            Brush Brocha = new SolidBrush(Color.Red);
            Brush BrochaTexto = new SolidBrush(Color.Black);

            String Texto = @"Conectando Con ADO .NET
            
                            La conexion puede realizarse mediante ADO o sin el:
                                en la primera se establece una conexion directa con el origen de datos permitiendo una conexion persistente 
                                en la segunda la conexion se estable solamente cuando es necesario para el programa en cualquier otro instante la conexion se mantiene cerrada 
                           
                            se utilizaran  medios graficos.

                           
                            ";

            // dibujar un rectangulo 
            Rectangle RectanguloFondo = new Rectangle(10, 20, 100, 100);
            ObejtoGrafico.FillRectangle(Brocha, RectanguloFondo);

           

            // agregar texto
            ObejtoGrafico.DrawString( Texto ,new Font("Arial",12), BrochaTexto, 20,20 );



        }
    }
}
