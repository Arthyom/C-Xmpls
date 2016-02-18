using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8ReinasCsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // ir al siguiente formulario 
            Form2 f2 = new Form2();
            f2.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //int dims;
            this.button1.Text = "Generar";
            this.textBox1.Text = "FilasXColumnas";
            this.textBox1.ForeColor = Color.Gray;

            this.label1.Text = "Dimenciones del tablero";
            this.label1.ForeColor = Color.Red;
  
        }

        
    }
}
