﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
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
            textBox1.Text = "Alfredo gonzalez g";

            QrEncoder Codificador = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode Codigo = new QrCode();

            Codificador.TryEncode(textBox1.Text, out Codigo);
            GraphicsRenderer Re = new GraphicsRenderer(new FixedCodeSize(200, QuietZoneModules.Zero), Brushes.Black, Brushes.White);

            MemoryStream ms = new MemoryStream();
            Re.WriteToStream(Codigo.Matrix, ImageFormat.Png, ms);

            var imt = new Bitmap(ms);

            var img = new Bitmap(imt, new Size(250, 250));
            panel1.BackgroundImage = img;

        }
    }
}
