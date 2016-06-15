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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint ( object sender, DragEventArgs e)
        {
            // usar los constructores de font 
            Font fnt1 = new Font( "Arial",12,FontStyle.Bold | FontStyle.Italic );

        }
    }
}
