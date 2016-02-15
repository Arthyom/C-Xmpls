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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // iniciar el formulario
            this.button1.Text   = "Iniciar";
            this.textBox1.Text  = "Numero de Casilla";

            this.textBox1.Text = "Casilla inicio";

            
            
            // mostrar la primera reina en pantalla 
             

        }

      

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void setReina   (int Casilla, int dims)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int psGX = groupBox1.Location.X;
            int psGY = groupBox1.Location.Y;
            int dims = Convert.ToInt16( this.textBox1.Text );
            int cuenta = 0;
            int linea = 0;
            // crear un vector de objetos
            Label[] Vect = new Label[dims];
            for (int i = 0; i < dims; i++)
            {
                for (int j = 0; j < dims; j++)
                {
                    Vect[j] = new Label();
                   

                    // hubicar cada objeto en pantalla 
                    Vect[j].Name = "nombre" + cuenta.ToString();
                    Vect[j].Location = new System.Drawing.Point(j * 60, (psGY * 30) * i);
                    Vect[j].Size = new System.Drawing.Size(60, 60);
                    Vect[j].Text = cuenta.ToString();
                    Vect[j].ForeColor = Color.White;

                    // definir el color de cada casilla

                    if ( linea % 2 == 0)
                    {
                        if (j % 2 == 0)
                            Vect[j].BackColor = Color.Black;
                        else
                            Vect[j].BackColor = Color.Red;
                    }
                    else
                    {
                        if (j % 2 == 0)
                            Vect[j].BackColor = Color.Red;
                        else
                            Vect[j].BackColor = Color.Black;
                    }
                    
             
                  
          
                    


                    // agregar al formulario
                    groupBox1.Controls.Add(Vect[j]);
                    cuenta++;

                }
                linea++;
            }

            // hubicar reina en la posicion indicada
            PutSetReina( Convert.ToInt16(this.textBox2.Text) );


       
        }

        private void    PutSetReina ( int casillaInicial )
        {
            String cadNombre = "nombre" + casillaInicial.ToString();
            foreach ( Control ob in this.groupBox1.Controls)
            {
                if (ob.Name == cadNombre)
                {
                    ob.Text = "R";
                    ob.BackColor = Color.DarkBlue;

                }
            }
        }

        private void RmvSetReina(int casillaActual, int dims)
        {
            int cuenta = 0;
            int esp = 0;
            String cadNombreAnterior = "nombre" + (casillaActual - 1).ToString();
            String cadNombreActual = "nombre" + casillaActual.ToString();

            Color clrAnt = Color.White;





            // buscar el color anterior a la casilla actual
            foreach (Control objAnt in this.groupBox1.Controls)
            {
                if (objAnt.Name == cadNombreAnterior)
                    clrAnt = objAnt.BackColor;
            }


            foreach (Control objAct in this.groupBox1.Controls)
            {
                if(esp == dims )
                    esp = 0;


                if ((objAct.Name == cadNombreActual) && (esp > 0))
                {
                    // asignar color dependiendo del color anterior
                    if (clrAnt.Equals(Color.Red))
                        objAct.BackColor = Color.Black;
                    else
                        objAct.BackColor = Color.Red;

                    objAct.Text = cuenta.ToString();
               
                }
                else 
                    if ( (objAct.Name == cadNombreActual) && (esp == 0) )
                        objAct.BackColor = Color.Yellow;

                




                esp++;
                cuenta++;
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            // remover una marca 
            RmvSetReina( Convert.ToInt16(this.textBox3.Text),Convert.ToInt16(this.textBox1.Text) );
        }
    }

        
}
