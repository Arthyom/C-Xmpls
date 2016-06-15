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

        protected override void OnPaint ( PaintEventArgs e)
        {
            Graphics     gra = e.Graphics;
            SolidBrush clr1 = new SolidBrush(Color.Blue);
            SolidBrush clr2 = new SolidBrush(Color.Red);
            SolidBrush clr3 = new SolidBrush(Color.Yellow);

            // usar los constructores de font 
            Font fnt1 = new Font( "Arial",12,FontStyle.Bold | FontStyle.Italic );

            // usar los constructores de font 
            Font fnt2 = new Font("Times New Roman", 45, FontStyle.Bold | FontStyle.Italic);

            // usar los constructores de font 
            Font fnt3 = new Font("Tahoma", 12, FontStyle.Bold | FontStyle.Italic| FontStyle.Strikeout);

            gra.DrawString("este texto sera dibujado", fnt1, clr1, new Point(0,0) );
            gra.DrawString("este texto sera dibujado despues del anterior como ejemplo", fnt2, clr3, new Point(20, 30));
            gra.DrawString("este texto sera dibujado", fnt3, clr2, new Point(100, 20));

        }
    }
}
