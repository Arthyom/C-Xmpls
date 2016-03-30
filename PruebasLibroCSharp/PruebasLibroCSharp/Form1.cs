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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void MostrarMensaje()
        {
            MessageBox.Show("Este es el mensaje que se ha mostrado");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha precionado el boton1");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // generar un nuevo botton 
            Button btn1 = new Button();
            btn1.Location = new System.Drawing.Point(0,0);
            btn1.Size = new System.Drawing.Size(50,30);
            btn1.Name = "Boton1";
            btn1.Text = "Boton1";

            this.Controls.Add(btn1);

            // crear un delegado para el control
            btn1.Click += new System.EventHandler(this.Btn1_click);

            // crear caja de texto para entrada de raiz
            TextBox txt1 = new TextBox();
            txt1.Location = new System.Drawing.Point(0, 30);
            txt1.Size = new System.Drawing.Size(30, 10);
            txt1.Name = "caja1";

            this.Controls.Add(txt1);

            this.label1.Text = "Este es texo de prueba";
            this.checkBox1.Text = "Cabiar fuente";
            this.checkBox2.Text = "Cambiar otras cosas";


        }

        // intentar crear un manejador de eventos para el boton creado en tiempo de ejecucion
        private void Btn1_click ( object sender, EventArgs e)
        {
            MessageBox.Show("se preciono en el boton dinamico");

            int numeroRaiz = 0;
            // realizar operaciones para la caja de texto
            foreach(Control c in this.Controls)
            {
                try
                {
                    if (c is TextBox && c.Name == "caja1")
                    {
                        numeroRaiz = Convert.ToInt32(c.Text);
                        if (numeroRaiz < 0)
                            throw new Exception("No hay raices negativas!!!");
                        break;
                    }
                }
                catch (Exception el)
                {
                    MessageBox.Show(el.Message);
                    return;
                }

                    
            }

            MessageBox.Show("el numero en la razi es " + numeroRaiz.ToString());


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // cambiar la fuente de la etiqueta
            this.label1.Font = new Font(this.button1.Font.Name, 12);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // cambiar el tamaño y otras cuestiones
            this.label1.Font = new Font(checkBox1.Font.Name, 23, checkBox1.Font.Style ^ FontStyle.Italic);
        }
    }
}
