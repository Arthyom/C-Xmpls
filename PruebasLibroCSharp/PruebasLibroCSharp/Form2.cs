using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PruebasLibroCSharp
{
    public partial class Form2 : Form
    {
        private int num = 0 ;
        public Form2()
        {
            InitializeComponent();
        }

        private void But1_Click ( object sender, EventArgs e)
        {
          
            string ruta = @"C:\Users\frodo\Pictures\Robts\r(" + this.num.ToString() + ").jpg";
            // conseguir las imagenes
            try
            {
               
                this.pictureBox1.Image = Image.FromFile(ruta);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ruta);
               
            }
            finally
            {
                this.num += 1;
            }

            
     
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // crear un nuevo boton 
            Button b1 = new Button();
            b1.Name = "B1";
            b1.Size = new System.Drawing.Size(200, 300);
            b1.Size = new System.Drawing.Size(300, 100);
            b1.Text = " Siguiente Imagen";

            b1.Click += new System.EventHandler(But1_Click);

            this.Controls.Add(b1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // nostrar el texto del boton precionado 
            foreach (Control C in this.Controls)
                if (C is RadioButton)
                {
                    if (C == chk1)
                        MessageBox.Show("contol 1");
                    else
                       if (C == chk2)
                        MessageBox.Show("Control 2");
                    else
                       if (C == chk3)
                        MessageBox.Show("control 3");
                    else
                       if (C == chk4)
                        MessageBox.Show("Control 4");
                    else
                       if (C == chk5)
                        MessageBox.Show("Control 5");
                    else
                       if (C == chk6)
                        MessageBox.Show("Control 6");
                    else
                       if (C == chk7)
                        MessageBox.Show("Control 7");
                    else
                       if (C == chk8)
                        MessageBox.Show("Control 8");
                    else
                       if (C == chk9)
                        MessageBox.Show("Control 9");
                }
                  
            
        }
    }
}
