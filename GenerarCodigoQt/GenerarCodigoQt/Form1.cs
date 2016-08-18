using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Gma.QrCodeNet.Encoding;
using System.IO;



namespace GenerarCodigoQt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            QrEncoder Codificador = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode Codigo = new QrCode();

            Codificador.TryEncode(textBox1.Text, out Codigo);
          
        }
    }
}
