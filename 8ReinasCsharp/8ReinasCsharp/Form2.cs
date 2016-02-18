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
			
        private void button1_Click(object sender, EventArgs e)
		{
			int psGX = groupBox1.Location.X;
			int psGY = groupBox1.Location.Y;
			int dims = Convert.ToInt16 (this.textBox1.Text);
			int hubicador = 0;
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
    
        private int  BscrReina    ( Label [,] tablero)
        {
            int lstReina = 0;
            for ( int i = 0; i < Math.Sqrt(tablero.Length); i++)
            {
                for( int j = 0; j < Math.Sqrt(tablero.Length); j++)
                {
                    if (tablero[i, j].BackColor.Equals(Color.Blue))
                        lstReina++;

                }
            }
            return lstReina;
        }
	

		private void SetXYHrzntAtk ( Label [,] tablero, int x, int y){
			// atacer en X y Y para la casilla actual
			if( (x >= 0 && y >= 0) && ( x < Math.Sqrt(tablero.Length)) && (y < Math.Sqrt(tablero.Length)) ){
				for ( int j = 0 ; j < Math.Sqrt(tablero.Length); j++ ){
					// resaltar linea horizaontal
					tablero [y, j].BackColor = Color.Gray;
				}
			}
		}

		private void SetXYVrtklAtk ( Label [,] tablero, int x, int y){
			// atacer en X y Y para la casilla actual
			if( (x >= 0 && y >= 0) && ( x < Math.Sqrt(tablero.Length)) && (y < Math.Sqrt(tablero.Length)) ){
				for ( int i = 0 ;i < Math.Sqrt(tablero.Length); i++ ){
					// resaltar linea horizaontal
					tablero [i, x].BackColor = Color.Gray;
				}
			}
		}

		private void SetXYSupLnAtk (Label [,] tablero, int x, int y){
			// atacar la diagonal izquierda
			if( (x >= 0 && y >= 0) && ( x < Math.Sqrt(tablero.Length)) && (y < Math.Sqrt(tablero.Length)) ){
				while( x> 0 && y>0 ){
					x--; y--;
					
				}
				for ( int ySup = y, xSup = x ; ySup < Math.Sqrt(tablero.Length) && xSup < Math.Sqrt(tablero.Length) ; ySup++, xSup++ ){
						tablero [ySup, xSup].BackColor = Color.Gray;

				}
			}
		}

		private void SetXYInfLnAtk (Label [,] tablero, int x, int y){
			// atacar la diagonal izquierda
			if( (x >= 0 && y >= 0) && ( x < Math.Sqrt(tablero.Length)) && (y < Math.Sqrt(tablero.Length)) ){
				while( y< Math.Sqrt(tablero.Length)-1 && x>0 ){
					x--; y++;

				}
				for ( int ySup = y, xSup = x ; (ySup >= 0) && (xSup < Math.Sqrt(tablero.Length) ) ; ySup--, xSup++ ){
					//MessageBox.Show ("entrando" + ySup.ToString () + xSup.ToString ());
					tablero [ySup, xSup].BackColor = Color.Gray;

				}
			}
		}



        private void RmvXYHrznAtk (Label [,] tablero, int x, int y)
        {
            // atacer en X y Y para la casilla actual
            if ((x >= 0 && y >= 0) && (x < Math.Sqrt(tablero.Length)) && (y < Math.Sqrt(tablero.Length)))
            {
                for (int j = 0; j < Math.Sqrt(tablero.Length); j++)
                {
                    // resaltar linea horizaontal
                    RePintar(tablero, j, y);
                }
            }
        }

        private void RmvXYVrtclAtk(Label[,] tablero, int x, int y)
        {
            // atacer en X y Y para la casilla actual
            if ((x >= 0 && y >=0) && (x < Math.Sqrt(tablero.Length)) && (y < Math.Sqrt(tablero.Length)))
            {
                for (int j = 0; j < Math.Sqrt(tablero.Length); j++)
                {
                    // resaltar linea horizaontal
                    RePintar(tablero, x, j);
                }
            }
        }

        private void RmvXYSupLnAtk(Label[,] tablero, int x, int y)
        {
            if ((x >= 0 && y >= 0) && (x < Math.Sqrt(tablero.Length)) && (y < Math.Sqrt(tablero.Length)))
            {
                while (x > 0 && y > 0)
                {
                    x--; y--;

                }
                for (int ySup = y, xSup = x; ySup < Math.Sqrt(tablero.Length) && xSup < Math.Sqrt(tablero.Length); ySup++, xSup++)
                {
                    RePintar(tablero, xSup, ySup);

                }
            }
        }

        private void RmvXYInfLnAtk(Label[,] tablero, int x, int y)
        {
            // atacar la diagonal izquierda
            if ((x >= 0 && y >= 0) && (x < Math.Sqrt(tablero.Length)) && (y < Math.Sqrt(tablero.Length)))
            {
                while (y < Math.Sqrt(tablero.Length) - 1 && x > 0)
                {
                    x--; y++;

                }
                for (int ySup = y, xSup = x; (ySup >= 0) && (xSup < Math.Sqrt(tablero.Length)); ySup--, xSup++)
                {
                    //MessageBox.Show("entrando" + ySup.ToString() + xSup.ToString());
                    RePintar(tablero, xSup, ySup);

                }
            }
        }



        private void Atacar ( Label [,] tablero, int casillaActual ){
			// atacar en las 8 direcciones que puede atacar una reina
			int i = 0, j = 0 , hubicador = 0;
			for( i = 0 ; i < Math.Sqrt(tablero.Length) ; i ++ ){
				for ( j = 0 ; j < Math.Sqrt(tablero.Length) ; j++ ){
					if (hubicador == casillaActual){

						SetXYHrzntAtk(tablero,j,i);
						SetXYVrtklAtk(tablero,j,i);
						SetXYSupLnAtk(tablero, j, i);
						SetXYInfLnAtk(tablero, j, i);

						setReinaXY (j, i, tablero);
						
						return;
					}
					hubicador++;
				}
			}
		}

        private void button2_Click(object sender, EventArgs e)
        {
            // ocupar la posicion indicada
            int dims = Convert.ToInt16(this.textBox1.Text);
            int hubicador = 0;

            Label[,] tablero = new Label[dims, dims];


            for( int i = 0; i < dims; i++)
            {
                for( int j = 0; j < dims; j++)
                {
                    tablero[i, j] = (Label) groupBox1.Controls["nombre" + hubicador.ToString()];
                    hubicador++;

                }
            }

            Atacar(tablero, Convert.ToInt16(textBox2.Text));
        }

        public Label [,] getTablero()
        {
            int dims = Convert.ToInt16(this.textBox1.Text);
            int hubicador = 0;

            Label[,] tablero = new Label[dims, dims];


            for (int i = 0; i < dims; i++)
            {
                for (int j = 0; j < dims; j++)
                {
                    tablero[i, j] = (Label)groupBox1.Controls["nombre" + hubicador.ToString()];
                    hubicador++;

                }
            }
            return tablero;
        }

        public void RePintar ( Label [,] tablero, int x, int y)
        {
            if (y % 2 == 0)
            {
                if (x % 2 == 0)
                    tablero[y, x].BackColor = Color.Red;
                else
                    tablero[y, x].BackColor = Color.Black;
            }
            else {
                if (x % 2 != 0)
                    tablero[y, x].BackColor = Color.Red;
                else
                    tablero[y, x].BackColor = Color.Black;

            }
        }

        public void RmvAtak(Label[,] tablero, int casillaActual)
        {
            // quitar los ataques y volver a pintar cada casilla
            int i = 0, j = 0, hubicador = 0;
            for (i = 0; i < Math.Sqrt(tablero.Length); i++)
            {
                for (j = 0; j < Math.Sqrt(tablero.Length); j++)
                {
                    if (hubicador == casillaActual)
                    {

                        RmvXYHrznAtk(tablero, j, i);
                        RmvXYVrtclAtk(tablero, j, i);
                        RmvXYSupLnAtk(tablero, j, i);
                        RmvXYInfLnAtk(tablero, j, i);
                        tablero[i, j].Text = hubicador.ToString() + "->" + "( " + i.ToString() + "," + i.ToString() + " )"; 

                        return;
                    }
                    hubicador++;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Label[,] tablero = getTablero();
            RmvAtak(tablero, Convert.ToInt16(this.textBox4.Text));

        }


        private int jugar(Label[,] tablero)
        {
            // comenzar a jugar con el tabler indicado
            int  casillaPrueba = 0 ;

            // recorrer el tablero buscando donde posicionar una reina
            for (int i = 0; i < Math.Sqrt(tablero.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(tablero.Length); j++)
                {
                    if ( tablero[i, j].BackColor.Equals(Color.Black) || tablero[i, j].BackColor.Equals(Color.Red))
                    {
                        // posicionar reina y atacar, regresar 1, para indica que se ha podido posicionar una reina
                        Atacar(tablero, casillaPrueba);
                        return 1;
                    }
                    casillaPrueba++;
                
                }
            }
            return 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // comenzar a jugar 
            Label[,] tablero = getTablero();
            int reinas = jugar(tablero); ;
            

            while( reinas < 5 &&  reinas >= 0)
            {
                
                if (reinas != -1)
                    reinas += jugar(tablero);
            

            }
        }
    }

        
}
