using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace probandoTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // demostrar como un ciclo for itera de manera super rapida

          
            timer1.Enabled = true;
            for ( int i = 0; i < 1000; i ++)
            {
                this.label1.Text = i.ToString();
                Thread.Sleep(100);
                label1.Refresh();
               


            }

            // ahora hay que relentisar la ejecucion del ciclo for

            
        }
    }
}
