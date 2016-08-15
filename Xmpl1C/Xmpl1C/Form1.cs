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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /// cambiar el valor de las etiquetas a 'si'
            this.label1.Text = "si";
            this.label2.Text = "si";
            this.label3.Text = "si ";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /// borrar el contenido de cada etiqueta 
            this.label1.Text = "";
            this.label2.Text = "";
            this.label3.Text = " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /// regresar las etiquetas a su estado inicial
            this.label1.Text = "A";
            this.label2.Text = "B";
            this.label3.Text = "c ";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            /// mostrar las etiquetas si el boton dice mostrar 


            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = false;
        }


        private void button4_MouseHover(object sender, EventArgs e)
        {
            /// desplegar un mensaje cuando el raton pase por encima del boton
            MessageBox.Show(this.textBox1.Text);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
