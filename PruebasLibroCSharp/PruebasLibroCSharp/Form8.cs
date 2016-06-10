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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        private Button CrearLabel( int numero)
        {
            Button ln = new Button();
            ln.Size = new Size(100, 100);
            ln.Location = new Point(200, 100);
            ln.Text = numero.ToString();

            return ln;
        }

        // crear una cantidad n de tabs 
        private void Form8_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                TabPage png = new TabPage("Pagina"  + (i+3).ToString())  ;
                png.Controls.Add(this.CrearLabel(i+3));
                tabControl1.Controls.Add(png);
            }
                 
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(tabControl1.SelectedIndex.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // repasar todos los coontroles mediante programacion 

            /// crear el formulario 
            Form10 fn = new Form10();

            fn.Show();
            
                   
            



        }
    }
}
