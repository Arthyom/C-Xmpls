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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // dibujando rectnagulos 
            Graphics papel = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(Color.Black);

            papel.DrawRectangle(lapiz, 0, 0, 100, 40);

            // dibujar lines 
            papel.DrawLine(lapiz, 20,10, 100,200);

            // dibujar ovalos 
            papel.DrawEllipse(lapiz, 100, 100, 100, 300);


            /// dibujando formas rellenas 
            /// se debe usar una brocha no un lapiz

            Brush brocha = new SolidBrush(Color.Red);

            papel.FillRectangle(brocha, 30, 70, 60, 90);
            papel.FillEllipse(brocha, 80, 30, 20, 50);

            // introducir una imagen puede ser, jpge, gif, bmp etc.
            Bitmap imagenCargada = new Bitmap(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg");
            papel.DrawImage(imagenCargada, 50, 50, 200, 200);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // dibujar un circulo perfecto
            Graphics papelDibujo = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(Color.Purple);
            Brush brocha = new SolidBrush(Color.Red);
            Bitmap imagen = new Bitmap(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg");


            papelDibujo.FillEllipse(brocha, 0, 0, 100, 100);
            papelDibujo.DrawImage(imagen,80,80,300,300);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // dibujar triangulo rectangulo
            Graphics papel = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(Color.Red);

            // dibujar triangulo
            papel.DrawLine(lapiz, 20, 50, 80, 50);
            papel.DrawLine(lapiz, 20, 50, 20, 10);
            papel.DrawLine(lapiz, 20, 10, 80, 50);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // mostrar un blanco
            Graphics papel = pictureBox1.CreateGraphics();
            Brush brocha = new SolidBrush(Color.Yellow);

            float xOrigen =30, yOrigen = 30;
      
            // iterar para mostrar la diana 
            for (int i = 0, delta = 100; i < 5; i++ , delta += 50)
            {
                switch (delta)
                {
                    case 300 :
                        Brush b1 = new SolidBrush(Color.White);
                        papel.FillEllipse(b1, xOrigen, yOrigen, xOrigen + delta, yOrigen + delta);
                    break;

                    case 200:
                          Brush b2 = new SolidBrush(Color.Red);
                        papel.FillEllipse(b2, xOrigen, yOrigen, xOrigen + delta, yOrigen + delta);
                    break;

                    case 100:
                          Brush b3 = new SolidBrush(Color.Blue);
                        papel.FillEllipse(b3, xOrigen, yOrigen, xOrigen + delta, yOrigen + delta);
                    break;

                }
                
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // desplegar la imagen en un rectangulo 
            Bitmap imagen = new Bitmap(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg");
        
            Graphics papel = pictureBox1.CreateGraphics();
            Brush brocha = new SolidBrush(Color.Yellow);

            papel.FillRectangle(brocha, 0, 0, imagen.Width + 100 , imagen.Height + 100);
            papel.DrawImage(imagen, 20, 20, imagen.Width, imagen.Height);
        }

    }
}
