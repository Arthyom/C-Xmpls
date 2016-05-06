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
    public partial class Form9MDI1 : Form
    {
        public Form9MDI1()
        {
            InitializeComponent();
        }

        private void Form9MDI1_Load(object sender, EventArgs e)
        {

            this.MdiParent = new Form9();

        }
    }
}
