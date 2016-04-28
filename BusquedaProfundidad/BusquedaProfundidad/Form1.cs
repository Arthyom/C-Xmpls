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

namespace BusquedaProfundidad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.GTree.BackColor = Color.White;
            
            
            this.button2.Text = "BORRAR";
            this.button2.BackColor = Color.Red;

            this.button1.Text = "BUSCAR";
            
        }

        private TreeNode PonerNodo( TreeNode NodoActual, Estado EstadoActual ) {
            if (EstadoActual.LadoDer)
            {
                TreeNode t = new TreeNode( new string(EstadoActual.CosasLadoDer));
                t.BackColor = Color.Red;
                NodoActual.Nodes.Add(t);
                return t;
            }
            else
            {
                TreeNode t = new TreeNode(new string(EstadoActual.CosasLadoIzq));
                t.BackColor = Color.Blue;
                NodoActual.Nodes.Add(t);
                return t;
            }
        }

        private TreeNode SetRaiz ( Estado EstadoActual)
        {
            if (EstadoActual.LadoDer)
            {
                TreeNode t = new TreeNode(new string(EstadoActual.CosasLadoDer));
                t.BackColor = Color.Red;
                return t;
            }
            else
            {
                TreeNode t = new TreeNode(new string(EstadoActual.CosasLadoIzq));
                t.BackColor = Color.Blue;
                return t;
            }
        }

        private Estado EstadoInicial()
        {
            string CadenaEntrada = this.textBox1.Text;
            char[] vacio = { '0', '0', '0', '0' };

            Estado EstadoNuevo = new Estado();
            EstadoNuevo.LadoDer = this.radDerIn.Checked;
            EstadoNuevo.LadoIzq = this.radIzqIn.Checked;


            // el lado derecho esta checado
            if (this.radDerIn.Checked)
            {
                EstadoNuevo.CosasLadoDer = CadenaEntrada.ToCharArray();
                EstadoNuevo.CosasLadoIzq = vacio;

             

              
            }
            else
            {
                EstadoNuevo.CosasLadoDer = vacio;
                EstadoNuevo.CosasLadoIzq = CadenaEntrada.ToCharArray();

            }

            return EstadoNuevo;
        }

        private Estado EstadoFinal()
        {
            string CadenaEntrada = this.textBox2.Text;
            char[] vacio = { '0', '0', '0', '0' };

            Estado EstadoNuevo = new Estado();
            EstadoNuevo.LadoDer = this.radDerFin.Checked;
            EstadoNuevo.LadoIzq = this.radIzqFin.Checked;

            // el lado derecho esta checado
            if (this.radDerFin.Checked)
            {
                EstadoNuevo.CosasLadoDer = CadenaEntrada.ToCharArray(); ;
                EstadoNuevo.CosasLadoIzq = vacio;
            }
            else
            {
                EstadoNuevo.CosasLadoDer = vacio;
                EstadoNuevo.CosasLadoIzq = CadenaEntrada.ToCharArray();
            }

            return EstadoNuevo;
        }

        private void GetPapi (Estado EstadoHijo)
        {
            if ( EstadoHijo != null)
            {           
                this.ImprimirEstado(EstadoHijo);
                this.GetPapi(EstadoHijo.EstadoPadre);
            }
                    
        }

        private void GrafObliga(Estado ArbolRaiz,int x, int y)
        {
            /** imprimir el nodo qe ha sido visitado **/
            Label l = new Label();
            l.Location = new System.Drawing.Point(x, y);
            l.Size = new System.Drawing.Size(70, 30);
            l.AutoSize = true;
            l.Font = new Font(textBox1.Font.Name, 10, FontStyle.Bold);
            l.ForeColor = Color.White;


            if (ArbolRaiz.LadoDer)
            {
                l.BackColor = Color.Red;
                l.Text = " lado Der -> " + new string(ArbolRaiz.CosasLadoDer) + " lado Izq-> " + new string(ArbolRaiz.CosasLadoIzq);

            }

            else
            {
                l.BackColor = Color.Blue;
                l.Text = " Lado Izq -> " + new string(ArbolRaiz.CosasLadoIzq) + " Lado Der -> " + new string(ArbolRaiz.CosasLadoDer);
            }


            GTree.Controls.Add(l);
        }

        private void ImprimirEstado( Estado EstadoHijo)
        {
            string salida;
            if (EstadoHijo != null)
            {
                if (EstadoHijo.LadoDer)
                {
                    salida = new string(EstadoHijo.CosasLadoDer);
                    MessageBox.Show(" Estado ->>" + salida + " " + " lado D ", "lISTA DE SOLUCION");
                }
                else
                {
                    salida = new string(EstadoHijo.CosasLadoIzq);
                    MessageBox.Show(" Estado ->>" + salida + " " + " lado I ", "lISTA DE SOLUCION");
                }
            }
        }

        private void GraficarEstado ( Estado ArbolRaiz, int x, int y )
        {
            // imprimir arbol nodo a nodo
            if (ArbolRaiz.EstadosHijos != null)
            {

                /** imprimir el nodo qe ha sido visitado **/
                Label l = new Label();
            l.Location = new System.Drawing.Point(x, y);
            l.Size = new System.Drawing.Size(70, 30);
                l.AutoSize = true;
                l.Font = new Font(textBox1.Font.Name, 10, FontStyle.Bold);
                l.ForeColor = Color.White;


            if (ArbolRaiz.LadoDer)
            {
                l.BackColor = Color.Red;
                l.Text = " lado Der -> " + new string(ArbolRaiz.CosasLadoDer) +" lado Izq-> " + new string (ArbolRaiz.CosasLadoIzq);

            }

            else
            {
                l.BackColor = Color.Blue;
                l.Text = " Lado Izq -> " + new string(ArbolRaiz.CosasLadoIzq) + " Lado Der -> " + new string (ArbolRaiz.CosasLadoDer);
            }
              

            GTree.Controls.Add(l);
           
                foreach (Estado E in ArbolRaiz.EstadosHijos)
                {
                    x += 30;
                    y += 10;
                    if (E != null)
                    GraficarEstado(E, x, y);
                }
            }
        }

        // inicari la busqueda
        private void button1_Click(object sender, EventArgs e)
        {
            Estado EstadoInicial = this.EstadoInicial();
            Estado EstadoFinal = this.EstadoFinal();

            

            // crear Arbol de busqueda
            Arbol ArbolBusqueda = new Arbol();
            ArbolBusqueda.InsertarRaiz(EstadoInicial);
            ArbolBusqueda.Dims += 1;

          
            // iterar hasta que se encuentre el estado final
            while (true)
            {
                // si la pila no esta vacia 
                if( ArbolBusqueda.PilaSuc.Count > 0)
                {
                    // sacar un elemento de la pila 
                    Estado EstadoExtraido = (Estado)ArbolBusqueda.PilaSuc.Pop();

                    if (EstadoExtraido != null)
                    {

                        // si el extraido es igual al estado final 
                        if (ArbolBusqueda.Comparar(EstadoExtraido, EstadoFinal))
                        {
                            
                            MessageBox.Show("solucion encontrada " + new String(EstadoExtraido.CosasLadoIzq) + " " + " " + new String(EstadoExtraido.CosasLadoDer));
                            this.GrafObliga(EstadoExtraido, 0, 200);
                            this.GTree.Refresh();
                            this.GetPapi(EstadoExtraido);

                            return;
                        }
                        else
                        {

                            // GENERAR SUCESPRES SOLO SI ES UN ESTADO VALIDO
                            if (ArbolBusqueda.Reglas(EstadoExtraido) && !ArbolBusqueda.BuscarEstadoUsado(EstadoExtraido))
                                ArbolBusqueda.GenerarSucesores(EstadoExtraido);

                            // meterlo a cola de usados
                            ArbolBusqueda.ColaUsados.Enqueue(EstadoExtraido);

                            // graficar sucesores
                            this.GraficarEstado(ArbolBusqueda.Raiz, 0, 0);



                            Thread.Sleep(200);
                            GTree.Refresh();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("la Pila esta Vacia!!!!");
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // limpiar radio buttons
            radDerFin.Checked = false;
            radIzqFin.Checked = false;

            radIzqIn.Checked = false;
            radDerIn.Checked = false;
            GTree.Controls.Clear();
            
            // BORRAR CADA UNO DE LOS CONTROLES 
            foreach( Control c in this.Controls)
            {
                if (c is TextBox)
                    c.Text = " ";
                else
                    if (c is GroupBox && c.Name == "GTree")
                    c.Controls.Clear();
                        

                        

                    
            }
        }

        private void GTree_Click(object sender, EventArgs e)
        {

        }
    }
}
