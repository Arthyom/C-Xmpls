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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        // mostrar al formulario como un mdi
        private void Form9_Load(object sender, EventArgs e)
        {
            

        }

        // mostrar formulario mdi
        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9MDI1 fh = new Form9MDI1();
            fh.MdiParent = this;
            fh.Show();

        }
    }
}
