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
    public partial class Form6 : Form
    {
        public string ruta;
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();

            

            // desplega cuadro de directorios 
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();

            string [] rutas = Directory.GetDirectories(fd.SelectedPath);








        }

        // llenar objetos del tvw
        private void Form6_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("Raiz");

            this.ConstruirArbol(treeView1.Nodes[0], 4, 0,5);
            
            

                


        }
        private void ConstruirArbol ( TreeNode NodoPadre, int numeroHijos, int maximun, int maxest )
        {
            maximun++;
            if ( maximun <= maxest)
            {
                for (int i = 0; i < numeroHijos; i++)
                {
                    for( int j = 0; j < numeroHijos; j ++) 
                        NodoPadre.Nodes.Add((j + 1).ToString());

                    NodoPadre = NodoPadre.Nodes[i];
                    this.ConstruirArbol(NodoPadre, numeroHijos, maximun, maxest);
                   
                }
            }  
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show(treeView1.SelectedNode.Text);
            MessageBox.Show(treeView1.SelectedNode.FullPath);
        }
    }
}
