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
			int dims = Convert.ToInt16 (this.textBox1.Text);
			int hubicador = 1;
			int tam = 80;

			// crear matriz para representar al tablero
			Label[,] tablero = new Label[dims,dims];
			for (int i = 0; i < dims; i++) {
				for (int j = 0; j < dims; j++) {
					tablero [i,j] = new Label ();

					// indicar el valor de las etiquetas y posicionarlas 
					tablero [i, j].Name = "nombre" + hubicador.ToString ();
					tablero [i,j].Size = new System.Drawing.Size (tam, tam);
					tablero [i,j].Location = new System.Drawing.Point (j * tam, tam * i);
					tablero [i,j].Text	= hubicador.ToString () + " -> " + "( " + j.ToString () + " , " + i.ToString () + " )";  
					tablero [i, j].ForeColor = Color.White;

					// ajustar formulario 

					this.groupBox1.Height = 2 * tam * dims; 
					this.groupBox1.Width =  2 * tam *  dims;

					this.Height = this.groupBox1.Height;
					this.Width = this.groupBox1.Width;

					// indicar el color de cada etiqueta
					if (i % 2 == 0) {
						if (j % 2 == 0)
							tablero [i,j].BackColor = Color.Red;
						else
							tablero [i,j].BackColor = Color.Black;
					} else {
						if (j % 2 != 0)
							tablero [i,j].BackColor = Color.Red;
						else
							tablero [i,j].BackColor = Color.Black;
						
					}
					hubicador++;

					// agregar la etiqueta
					this.groupBox1.Controls.Add (tablero [i,j]);

					//setReinaXY (0, 0, tablero);

				}
			}
			setReinaPs (Convert.ToInt16 (textBox2.Text)-1, tablero);
			RmvReinaPos (Convert.ToInt16 (textBox2.Text) - 1, tablero);


		}
			
        

		private void setReinaPs	( int hubicador, Label [,] tablero ){
			// recorrer el tablero buscando el hubicador solicitado
			/* puede mejorar cuando se consiga el tratamiento de cadenas */
			int contHubicador = 0;
			for ( int i = 0 ; i < Math.Sqrt(tablero.Length)  ; i++ ){
				for ( int j = 0 ; j < Math.Sqrt(tablero.Length) ; j ++ ){
					if ( hubicador   == contHubicador  ){
						tablero [i, j].BackColor = Color.Blue;
						tablero [i, j].Text	= "R";
						return;
					}
					contHubicador++;
				}
			}
		}

		private void setReinaXY ( int x, int y, Label [,] tablero ){
			// hubicar una reina por su poscision X,Y 
			if ( x  < Math.Sqrt(tablero.Length) - 1 && x  < Math.Sqrt(tablero.Length) - 1 ){
				tablero [y, x].BackColor = Color.Blue;
				tablero[y,x].Text = "R";
			}
		}

		private void RmvReinaXy ( int j, int i, Label [,] tablero ){
			// quitar la reina y volver al color anterior	
			if ( i  < Math.Sqrt(tablero.Length) - 1 &&  j  < Math.Sqrt(tablero.Length) - 1 ){
				// decir que color debe llevar la posicion
				if (i % 2 == 0) {
					if (j % 2 == 0)
						tablero [i,j].BackColor = Color.Red;
					else
						tablero [i,j].BackColor = Color.Black;
				} else {
					if (j % 2 != 0)
						tablero [i,j].BackColor = Color.Red;
					else
						tablero [i,j].BackColor = Color.Black;

				}
			}
			
		}

		private void RmvReinaPos ( int hubicador, Label [,] tablero ){
			// recorrer el tablero en busca del hubicador indicado
			int contHubicador = 0;
			for ( int i = 0 ; i < Math.Sqrt(tablero.Length)  ; i++ ){
				for ( int j = 0 ; j < Math.Sqrt(tablero.Length) ; j ++ ){
					if ( hubicador   == contHubicador  ){
						tablero [i,j].Text	= (1+hubicador).ToString () + " -> " + "( " + j.ToString () + " , " + i.ToString () + " )";
						// indicar el color de cada etiqueta

						if (i % 2 == 0) {
							if (j % 2 == 0)
								tablero [i,j].BackColor = Color.Red;
							else
								tablero [i,j].BackColor = Color.Black;
						} else {
							if (j % 2 != 0)
								tablero [i,j].BackColor = Color.Red;
							else
								tablero [i,j].BackColor = Color.Black;

						}
						return;
					}
					contHubicador++;
				}
			}

		}
    }

        
}
