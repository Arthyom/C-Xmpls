using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GatoRatonInterface
{
    public partial class Form1 : Form
    {
        Color or;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PanelTablero.BackColor = Color.Red;
            DesplegarTablero();
        }

     
        /// Desplegar el tablero con las etiquetas correctas respondiendo a los eventos de raton
        void DesplegarTablero()
        {

            int DespX = 0, DespY = 0;
            int cont = 0;

            for ( int i = 0; i < 8; i ++)
            {
                for ( int j = 0; j < 8; j ++)
                {
                    // crear prototipo para etiqueta 
                    cont++;
                    Label NuevaEtiqueta = new Label();
                    NuevaEtiqueta.Name = "Et" + i.ToString() + j.ToString();

                    if ( i % 2 == 0)
                    {
                        if (cont % 2 == 0)
                            NuevaEtiqueta.BackColor = Color.White;
                        else
                            NuevaEtiqueta.BackColor = Color.Black;
                    }
                    else
                          if (cont % 2 == 0)
                        NuevaEtiqueta.BackColor = Color.Black;
                    else
                        NuevaEtiqueta.BackColor = Color.White;


                    NuevaEtiqueta.Location = new Point(0 + DespX, 0 + DespY);
                    NuevaEtiqueta.Size = new Size( 50,50);
                    NuevaEtiqueta.Font = new Font("arial", 25, FontStyle.Bold);
                    NuevaEtiqueta.ForeColor = Color.Red;
                  //  NuevaEtiqueta.Text = i.ToString() + j.ToString();
                    NuevaEtiqueta.MouseEnter += MouseEnter_EntrarRaton;
                    NuevaEtiqueta.MouseLeave += MouseLeft_SalirRaton;
                    NuevaEtiqueta.MouseClick += MouseClick_Click;

                    DespX += 50;


                   PanelTablero.Width =+ DespX;
                    PanelTablero.Controls.Add(NuevaEtiqueta);

                }

                DespY += 50;
                DespX = 0;
            }
            PanelTablero.Height = DespY;

        }

        void CargarEstadoFinal (string RutaFinal)
        {
            // cargar el archivo de texto del tablero
            StreamReader Lector = new StreamReader(RutaFinal);

            foreach( Label Etiqueta in PanelTablero.Controls)
            {
                if(Lector.Read().ToString() == "R")
                {

                    Etiqueta.Text = Lector.Read().ToString();
                    Etiqueta.ForeColor = Color.Green;
                }
            }

            Lector.Close();
        }

        /// metodos para cambiar el color 
        void MouseEnter_EntrarRaton(object sender, EventArgs e)
        {
           
            Label Obejto = (Label)sender;
            this.or = Obejto.BackColor;

            if (Obejto.Name.StartsWith("Et") == true)
            {
                Obejto.BackColor = Color.Blue;
            }
                
        }

        /// metodos para cambiar el color 
        void MouseLeft_SalirRaton(object sender, EventArgs e)
        {
            Label Obejto = (Label)sender;

            if (Obejto.Name.StartsWith("Et"))
            {
                Obejto.BackColor = this.or;
            }
        }

        // click
        void MouseClick_Click ( object sender, MouseEventArgs e)
        {
            Label Obejto = (Label)sender;

            if (Obejto.Name.StartsWith("Et"))
            {
                Obejto.Text = "R";
 

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter Escritor = new StreamWriter(@"C:\Users\frodo\Desktop\ArchivoEntrada.txt");
            

            foreach( Label et in PanelTablero.Controls)
            {
                if (et.Text == "R")
                {
                    Escritor.Write("R");
                }
                else
                    Escritor.Write("O");

               
            }
            Escritor.Close();

            // ejecutar el programa de c++
            string RutaExe = @"C:\Users\frodo\Documents\Proyectos\C#\GatoRatonInterface\8reinas\build-8reinas-Desktop_Qt_5_3_MinGW_32bit-Debug\debug\8reinas.exe";
            System.Diagnostics.Process.Start(RutaExe);

            // cargar el archivo solucionado
            CargarEstadoFinal(@"C:\Users\frodo\Desktop\TableroFinal.txt");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 
        }
    }
}
