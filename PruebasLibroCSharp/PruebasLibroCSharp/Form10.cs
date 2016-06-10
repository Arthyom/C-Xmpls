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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

            // crear picture box
            PictureBox pc = new PictureBox();

            pc.Size = new Size(200, 200);
            pc.Location = new Point(0, 0);
            pc.BackColor = Color.White;

            this.Controls.Add(pc);


            // crear botones 

            for ( int i = 0; i < 3; i ++ )
            {
                
            }





        }
    }
}
