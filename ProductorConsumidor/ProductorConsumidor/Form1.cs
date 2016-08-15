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

namespace ProductorConsumidor
{
    public partial class Form1 : Form
    {
        public int numeoProductos;

        public Form1()
        {
            InitializeComponent();
        }
        
        public void consumir ()
        {
           

            Monitor.Enter(this);
            numeoProductos = Convert.ToInt16(this.label4.Text);

                // consumir si hay productos en la cesta
                while ( numeoProductos > 0)
                {
              
                    
                    label2.BackColor = Color.Blue;
                    label2.Refresh();

                    Thread.Sleep(500);

                     numeoProductos--;
                    label4.Text = numeoProductos.ToString();
                    label4.Refresh();

                    Thread.Sleep(500);
                    label2.BackColor = Color.Yellow;

            }

            // sino poner a dormir al consumidor y despertar al productor 
                    this.label2.BackColor = Color.Green;
                    label2.Refresh();
                    Thread.Sleep(500);

                   
                    Monitor.Pulse(this);
                    Monitor.Exit(this);
                 
            
            

                    
                
            
        }

        public void producir()
        {
            Monitor.Enter(this);
            numeoProductos = Convert.ToInt16(this.label4.Text);

            // producir si no se ha llenado la cesta
            while ( numeoProductos < Convert.ToInt16(textBox1.Text) )
            {
                
                label1.BackColor = Color.Blue;
                label1.Refresh();
                Thread.Sleep(500);

                numeoProductos++;
                label4.Text = numeoProductos.ToString();
                label4.Refresh();

                label1.BackColor = Color.Blue;
                label1.Refresh();

                Thread.Sleep(500);
                label1.BackColor = Color.Yellow;

            }

            // si esta llena la cesta poner a dormir al productor y despertar al consumidor

                this.label1.BackColor = Color.Green;
                label1.Refresh();
                Thread.Sleep(500);

           
            Monitor.Pulse(this);
            Monitor.Exit(this);
                

            
        }

     

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.BackColor = pictureBox1.BackColor;
            label2.BackColor = pictureBox2.BackColor;

            groupBox1.BackColor = Color.Brown;
            groupBox1.Text = " ";

            label3.Text = "Maxiomo";
            label2.Text = "Cnsmdr";
            label1.Text = "Prdctr";
            label4.Text = " ";

            button1.Text = "init";

            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = textBox1.Text;
            int numeroProductos = Convert.ToInt16(label4.Text);
            label4.Refresh();
           

            if (numeroProductos >= 0)
            {

                // crear hilos para el productor y el consumidor 
                Thread HiloCons = new Thread(new ThreadStart(consumir));
                Thread HiloProd = new Thread(new ThreadStart(producir));

                

                HiloCons.Name = "Consumidor";
                HiloProd.Name = "Productor";

                // poner a correr a los hilos


                HiloCons.Start();
                HiloProd.Start();

                while (true)
                {
                    this.consumir();
                    this.producir();
                }

                


               
            }
            else
            {
                MessageBox.Show("No hay Productos en la cesta, quiere Despertar al Productor???", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                
            }
            

        }
    }

}