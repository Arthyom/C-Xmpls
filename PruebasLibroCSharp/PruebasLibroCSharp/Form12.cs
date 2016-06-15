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
    public partial class Form12 : Form
    {
        // propiedades de color
        public Color ColorFondo;
        public Color ColorTexto;
        

        public Form12()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog SelectorColor = new ColorDialog();
           DialogResult Resultado = SelectorColor.ShowDialog();

            if (Resultado == DialogResult.OK)
            {
                this.ColorFondo = SelectorColor.Color;
                foreach (Control c in this.Controls)
                {
                    c.ForeColor = this.ColorFondo;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // desplegar la caja de colores 
            ColorDialog SelectorColor = new ColorDialog();
            DialogResult Resultado = SelectorColor.ShowDialog();

            if (Resultado == DialogResult.OK)
            {
                this.ColorFondo = SelectorColor.Color;
                foreach (Control c in this.Controls)
                    c.BackColor = this.ColorFondo;
                this.BackColor = this.ColorFondo;
            }
        }
    }
}
