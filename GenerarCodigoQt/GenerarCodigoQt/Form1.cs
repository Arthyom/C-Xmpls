using System;
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

using MySql.Data.MySqlClient;
// el primer paso es enlazar la dll del conector que el paquete msi, agrego al sistema, hecho esto solo es necesario agregar el espacio de nombres


namespace GenerarCodigoQt
{
    public partial class Form1 : Form
    {
        void ConectarConMysql()
        {
            // crear cadena de conexion, se puede hacer a mano o creando un connectionbuilder
            MySqlConnection Conexion = new MySqlConnection("Server = localhost; Database=qr; Uid=root; Pwd= ;");

            // crear un comando para la base de datos
            MySqlCommand Comando = new MySqlCommand("INSERT INTO usuario( carrera ) VALUES ('victor');",Conexion);

            // abrir la conexion con la base de datos para ejecutar el comando 
            Conexion.Open();

            int a = 2, c = 43;

            if ( Convert.ToBoolean(Comando.ExecuteNonQuery() ) )
                 a = 2;
            else
                 c = 3;

           

            Conexion.Close();
        }
        



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConectarConMysql();

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

        private void button1_Click(object sender, EventArgs e)
        {
            /// generar un codigo QR para los elementos de la caja 

            // crear un encoder, codificador
            QrEncoder Codificador = new QrEncoder( ErrorCorrectionLevel.H );

            // crear un codigo QR
            QrCode Codigo = new QrCode();

            // generar generar  un codigo apartir de datos, y pasar el codigo por referencia
            Codificador.TryEncode(textBox1.Text, out Codigo);

            // generar un graficador 
            GraphicsRenderer Renderisado = new GraphicsRenderer(new FixedCodeSize(200, QuietZoneModules.Zero), Brushes.Black, Brushes.White);

            // generar un flujo de datos 
            MemoryStream ms = new MemoryStream();

            // escribir datos en el renderizado
            Renderisado.WriteToStream(Codigo.Matrix, ImageFormat.Png, ms);

            // generar controles para ponerlos en el form
            var ImagenQR = new Bitmap(ms);
            var ImgenSalida = new Bitmap(ImagenQR, new Size(200, 250));

            // asignar la imagen al panel 
            panel1.BackgroundImage = ImgenSalida;
            


                 
        }
    }
}
