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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        // escribir y checar las cajas de texto
        private void checar_click()
        {
            MenuStripFuenteFAct.Text = this.textBox1.Font.FontFamily.ToString();
            MenuStripEditarSActl.Text = textBox1.Size.ToString();

        }

        // cargar el formulario 
        private void Form4_Load(object sender, EventArgs e)
        {
            // cambiar las propiedades de las etiquetas

            this.lblMens.Font = new Font(this.lblMens.Font.FontFamily, this.lblMens.Font.Size, FontStyle.Bold);
            this.lblMens.TextAlign = ContentAlignment.MiddleCenter;
            lblMens.Text = "Se ha precionado la tecla ";

            lblTecla.Text = " ";
            this.lblTecla.BackColor = Color.Red;
            this.lblTecla.Font = new Font(this.lblTecla.Font.FontFamily, 15, FontStyle.Bold);
            this.lblTecla.TextAlign = ContentAlignment.MiddleCenter;

            monthCalendar1.FirstDayOfWeek = Day.Thursday;

            DateTime FechaMinia = new DateTime(2015, 1, 1);
            DateTime FechaMaxima = new DateTime(2020, 2, 1);


            DateTime[] ArregloFechas = new DateTime[4];
            for (int i = 0, j = 1; i < 2; i++, j += 2)
                ArregloFechas[i] = new DateTime(2015, 4, j);


            monthCalendar1.MonthlyBoldedDates = ArregloFechas;
            monthCalendar1.MaxDate = FechaMaxima;
            monthCalendar1.MinDate = FechaMinia;



        }

        // manejador para evento de toque de tecla
        private void tecleo_KeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            MessageBox.Show("precionando tecla");
            lblTecla.Text = e.KeyValue.ToString();
        }

        // mover el puntero del raton 
        private void CambiarColor_MouseMove(object sender, MouseEventArgs e)
        {
            // cambiar el color para todas las otras etiquetas 
            foreach (Control c in this.Controls)
            {
                if (c == sender)
                {
                    c.ForeColor = Color.Red;
                }
                else
                    c.ForeColor = Color.Blue;
            }
        }

        private void lblTecla_MouseMove(object sender, MouseEventArgs e)
        {
            this.CambiarColor_MouseMove(sender, e);
        }

        private void negritaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size, FontStyle.Bold);
            checar_click();
        }

        private void italicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size, FontStyle.Italic);
            checar_click();
        }

        private void subrayadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size, FontStyle.Underline);
            checar_click();
        }

        private void rojoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Red;
        }

        private void verdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Green;
        }

        private void blancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.White;
        }

        // mostrar la fecha seleccionada
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
           
            // definir fechas que se pueden seleccionar
            monthCalendar1.MaxSelectionCount = 10;
            //monthCalendar1.MaxDate = 

      



        }

        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
